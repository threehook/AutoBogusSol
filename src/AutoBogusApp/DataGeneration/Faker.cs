using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using AutoBogus;
using AutoBogusApp.Vum;
using Bogus;

namespace AutoBogusApp.DataGeneration;

public static class AutoFakerExtensions
{
    private interface IAutoFaker
    {
        object Generate();
    }

    public class CustomAutoFaker<T> : Faker<T>, IAutoFaker where T : class
    {
        object IAutoFaker.Generate() => this.Generate();
    }
    
    public static void ApplyCustomAttributeRules<T>(CustomAutoFaker<T> faker) where T : class
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            // Skip indexers and non-readable properties
            if (property.GetIndexParameters().Length > 0 || !property.CanRead)
                continue;

            // ✅ Handle properties with custom attributes
            var customAttribute = property.GetCustomAttributes()
                .FirstOrDefault(attr => attr is ICustomAttributeGenerator) as ICustomAttributeGenerator;

            if (customAttribute != null)
            {
                AddCustomAttributeRule(faker, property, customAttribute);
                continue; // Skip further processing for this property
            }

            // Handle generic collections
            if (property.PropertyType != typeof(string) && IsGenericCollection(property.PropertyType, out Type itemType))
            {
                if (IsComplexType(itemType))
                {
                    AddCollectionRule(faker, property, itemType);
                }
                continue;
            }


            // ✅ Handle nested complex objects
            if (property.PropertyType != typeof(string) && IsComplexType(property.PropertyType))
            {
                AddNestedObjectRule(faker, property);
                continue;
            }

            // 4. Finally, let AutoBogus handle primitives and simple types
            AddAutoBogusDefaultRule(faker, property);
        }
    }

    private static void AddAutoBogusDefaultRule<T>(CustomAutoFaker<T> faker, PropertyInfo property) where T : class
    {
        var propertyType = property.PropertyType;
        var propertyName = property.Name;

        // Generate a full instance with AutoFaker
        var tempInstance = new AutoFaker<T>().Generate();

        // Get the default value as AutoBogus would generate it
        var defaultValue = property.GetValue(tempInstance);

        // Build: faker.RuleFor(x => x.Property, (f, x) => defaultValue);
        var param = Expression.Parameter(typeof(T), "x");
        var propertyExpr = Expression.Property(param, property);
        var lambda = Expression.Lambda(propertyExpr, param);

        var fakerParam = Expression.Parameter(typeof(Faker), "f");
        var instanceParam = Expression.Parameter(typeof(T), "x");
        var constantExpr = Expression.Constant(defaultValue, propertyType);

        var valueLambdaExpr = Expression.Lambda(
            Expression.Convert(constantExpr, propertyType),
            fakerParam,
            instanceParam
        );

        var valueLambda = valueLambdaExpr.Compile();

        var ruleForMethod = faker.GetType().GetMethods()
            .FirstOrDefault(m =>
                m.Name == "RuleFor" &&
                m.IsGenericMethod &&
                m.GetParameters().Length == 2 &&
                m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>));

        if (ruleForMethod != null)
        {
            var genericMethod = ruleForMethod.MakeGenericMethod(propertyType);
            genericMethod.Invoke(faker, new object[] { lambda, valueLambda });
        }
    }
    
    private static void AddCustomAttributeRule<T>(CustomAutoFaker<T> faker, PropertyInfo property, 
        ICustomAttributeGenerator customAttribute) where T : class
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var propertyAccess = Expression.Property(parameter, property);
        var lambda = Expression.Lambda<Func<T, object>>(
            Expression.Convert(propertyAccess, typeof(object)),
            parameter);

        faker.RuleFor(lambda, (f, doc) => customAttribute.Generate(f, doc));
    }

    private static void AddCollectionRule<T>(CustomAutoFaker<T> faker, PropertyInfo property, Type itemType) 
        where T : class
    {
        var nestedFakerType = typeof(CustomAutoFaker<>).MakeGenericType(itemType);
        var nestedFaker = (IAutoFaker)Activator.CreateInstance(nestedFakerType);
        
        // Recursively apply rules to the item type
        typeof(AutoFakerExtensions)
            .GetMethod(nameof(ApplyCustomAttributeRules), BindingFlags.Public | BindingFlags.Static)
            .MakeGenericMethod(itemType)
            .Invoke(null, new[] { nestedFaker });

        var parameter = Expression.Parameter(typeof(T), "x");
        var propertyAccess = Expression.Property(parameter, property);
        var lambda = Expression.Lambda<Func<T, object>>(
            Expression.Convert(propertyAccess, typeof(object)),
            parameter);

        faker.RuleFor(lambda, f => 
        {
            var count = f.Random.Number(1, 3); // Generate 1-3 items
            var list = (IList)Activator.CreateInstance(
                typeof(List<>).MakeGenericType(itemType));
            
            for (int i = 0; i < count; i++)
            {
                list.Add(nestedFaker.Generate());
            }
            
            return list;
        });
    }

    private static void AddNestedObjectRule<T>(CustomAutoFaker<T> faker, PropertyInfo property) 
        where T : class
    {
        var nestedType = property.PropertyType;
        var nestedFakerType = typeof(CustomAutoFaker<>).MakeGenericType(nestedType);
        var nestedFaker = (IAutoFaker)Activator.CreateInstance(nestedFakerType);
        
        // Recursively apply rules to the nested type
        typeof(AutoFakerExtensions)
            .GetMethod(nameof(ApplyCustomAttributeRules), BindingFlags.Public | BindingFlags.Static)
            .MakeGenericMethod(nestedType)
            .Invoke(null, new[] { nestedFaker });

        var parameter = Expression.Parameter(typeof(T), "x");
        var propertyAccess = Expression.Property(parameter, property);
        var lambda = Expression.Lambda<Func<T, object>>(
            Expression.Convert(propertyAccess, typeof(object)),
            parameter);

        faker.RuleFor(lambda, f => nestedFaker.Generate());
    }

    private static bool IsGenericCollection(Type type, out Type itemType)
    {
        itemType = null;
        
        // Check for List<T>, ICollection<T>, etc.
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            itemType = type.GetGenericArguments()[0];
            return true;
        }

        var interfaces = type.GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            .ToList();

        if (interfaces.Count == 0)
            return false;

        itemType = interfaces[0].GetGenericArguments()[0];
        return true;
    }

    private static bool IsComplexType(Type type)
    {
        return type.IsClass && 
               type != typeof(string) && 
               !type.IsValueType &&
               !type.IsArray;
    }

}