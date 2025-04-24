using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace AutoBogusApp.Vum;

public interface ICustomAttributeGenerator
{
    object Generate(Faker faker, object obj);
}

[AttributeUsage(AttributeTargets.Property)]
public class IntRangeAttribute(int min, int max, bool asString = false) : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        var randomValue = faker.Random.Int(min, max);
        return asString ? randomValue.ToString() : randomValue;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class Name : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        var word = faker.Lorem.Word();
        word = char.ToUpper(word[0]) + word.Substring(1);

        return word;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class Word : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        var word = faker.Lorem.Word().ToLower();

        return word;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class RestrictedLengthString(int minLength, int maxLength) : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        int length = faker.Random.Int(minLength, maxLength);
        return faker.Random.String2(length);
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class Sentence : Attribute, ICustomAttributeGenerator
{
    // Generate a sentence
    public object Generate(Faker faker, object parentObject)
    {
        return faker.Lorem.Sentence();
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class UuidHyphenated : Attribute, ICustomAttributeGenerator
{
    // Generate a hyphenated uuid
    public object Generate(Faker faker, object parentObject)
    {
        return faker.Random.Guid().ToString("D");
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class FormattedDateAttribute : Attribute, ICustomAttributeGenerator
{
    // Hardcoded format (adjust as needed)
    private const string Format = "yyyy-MM-dd"; // Default format

    // Generate a formatted date without requiring a format parameter
    public object Generate(Faker faker, object parentObject)
    {
        return faker.Date
            .Between(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100))
            .ToString(Format);
    }
}

public class OneOfAttribute(params object[] values) : Attribute, ICustomAttributeGenerator
{
    private readonly object[] _values = values ?? throw new ArgumentNullException(nameof(values));

    // Constructor to accept possible values

    public object Generate(Faker faker, object instance)
    {
        if (_values.Length == 0)
        {
            throw new InvalidOperationException("No values provided for OneOfAttribute.");
        }

        // Return a random value from the specified options
        return faker.PickRandom(_values);
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class Postcode : Attribute, ICustomAttributeGenerator
{
    // Generate a formatted date without requiring a format parameter
    public object Generate(Faker faker, object parentObject)
    {
        var digits = faker.Random.Number(1000, 9999);
        var letters = $"{faker.Random.Char('A', 'Z')}{faker.Random.Char('A', 'Z')}";
        return $"{digits}{letters}";
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class WebAddress : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        var webAddress = new Webadres();
        webAddress.CodeWebadres = faker.PickRandom(1, 2);
        webAddress.Url = $"{faker.Internet.Url()}/{faker.Lorem.Slug()}";

        return webAddress;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class WebUrl : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        return $"{faker.Internet.Url()}/{faker.Lorem.Slug()}";
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class CodeTaal : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        var codeTaalTypes = new List<string> { "nld", "eng", "fra", "deu", "spa", "por", "tur", "ara", "kur", "nor", "swe", "ces" };

        return string.Join(", ", 
            codeTaalTypes.OrderBy(x => faker.Random.Int())
                .Take(faker.Random.Int(1, Math.Min(3, codeTaalTypes.Count))));
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class Email(bool asList = false, int maxLength = 3) : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        if (asList)
        {
            // Generate a list of emails
            var total = faker.Random.Int(1, maxLength);
            List<string> emails = new List<string>();
            for (int i = 0; i < total; i++)
            {
                var email = GenerateEmail(faker);
                emails.Add((string)email);
            }
            return emails;
        }
        // Generate a single email
        return GenerateEmail(faker);
    }
    
    private static object GenerateEmail(Faker faker)
    {
        // Generate an email
        var email = faker.Internet.Email().ToLower();

        return email;
    }      
}

[AttributeUsage(AttributeTargets.Property)]
public class DutchPhoneNumber(bool asList = false, int maxLength = 3) : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        if (asList)
        {
            // Generate a list of random E.164 formatted Dutch phone numbers
            var total = faker.Random.Int(1, maxLength);
            List<string> phoneNumbers = new List<string>();
            for (int i = 0; i < total; i++)
            {
                var phoneNr = GenerateDutchPhoneNumber(faker);
                phoneNumbers.Add((string)phoneNr);
            }
            return phoneNumbers;
        }
        // Generate a single random E.164 formatted Dutch phone number
        return GenerateDutchPhoneNumber(faker);
    }
    
    private static object GenerateDutchPhoneNumber(Faker faker)
    {
        // Generate a random E.164 formatted Dutch phone number
        var phoneNumber = faker.Random.Bool()
            ? faker.Phone.PhoneNumber("+316########") // Mobile number
            : faker.Phone.PhoneNumber("+31##########"); // Landline number

        return phoneNumber;
    }      
}

[AttributeUsage(AttributeTargets.Property)]
public class OneOfBeroepsnaam(bool asList = false, int maxLength = 3) : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        if (asList)
        {
            // Generate a list of beroepsnaam objects
            var total = faker.Random.Int(1, maxLength);
            List<Beroepsnaam> beroepsnamen = new List<Beroepsnaam>();
            for (int i = 0; i < total; i++)
            {
                var beroepsnaam = GenerateOneOfBeroepsnaam(faker);
                beroepsnamen.Add((Beroepsnaam)beroepsnaam);
            }
            return beroepsnamen;
        }
        // Generate a single beroepsnaam
        return GenerateOneOfBeroepsnaam(faker);
    }    
    private static object GenerateOneOfBeroepsnaam(Faker faker)
    {
        object result = faker.Random.Bool()
            ? new Beroepsnaam()
            {
                BeroepsnaamGecodeerd = new BeroepsnaamGecodeerd
                {
                    CodeBeroepsnaam = faker.Random.AlphaNumeric(5),
                    OmschrijvingBeroepsnaam = faker.Name.JobTitle()
                }
            }
            : new Beroepsnaam()
            {
                BeroepsnaamOngecodeerd = new BeroepsnaamOngecodeerd
                {
                    NaamBeroepOngecodeerd = faker.Name.JobTitle()
                }
            };

        return result;
    }  
}

[AttributeUsage(AttributeTargets.Property)]
public class OneOfOpleidingsnaam : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        object result = faker.Random.Bool()
            ? new Opleidingsnaam()
            {
                OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd()
                {
                    CodeOpleidingsnaam = faker.Random.AlphaNumeric(5),
                    OmschrijvingOpleidingsnaam = faker.Lorem.Sentence()
                }
            }
            : new Opleidingsnaam()
            {
                OpleidingsnaamOngecodeerd = new OpleidingsnaamOngecodeerd
                {
                    NaamOpleidingOngecodeerd = $"{faker.Commerce.ProductAdjective()} {faker.Commerce.Department()}",
                    OmschrijvingOpleiding = faker.Lorem.Sentence(),
                }
            };
        
        return result;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class OneOfMPOpleidingsnaam : Attribute, ICustomAttributeGenerator
{
    public object Generate(Faker faker, object parentObject)
    {
        object result = faker.Random.Bool()
            ? new MPOpleidingsnaam()
            {
                OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd()
                {
                    CodeOpleidingsnaam = faker.Random.AlphaNumeric(5),
                    OmschrijvingOpleidingsnaam = faker.Lorem.Sentence()
                }
            }
            : new MPOpleidingsnaam()
            {
                OpleidingsnaamOngecodeerd = new MPOpleidingsnaamOngecodeerd
                {
                    NaamOpleidingOngecodeerd = $"{faker.Commerce.ProductAdjective()} {faker.Commerce.Department()}",
                }
            };
        
        return result;
    }
}



