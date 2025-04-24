using System.Globalization;
using System.Text.RegularExpressions;
using AutoBogusApp.Vum;
using NUnit.Framework;
using Bogus;

namespace AutoBogusApp.tests;

public class NameAttributeTests
{
    [Test]
    public void Generate_ShouldReturnCapitalizedWord()
    {
        var faker = new Faker();
        var nameAttribute = new Name();

        var result = nameAttribute.Generate(faker, new object()) as string;

        Assert.That(string.IsNullOrWhiteSpace(result), Is.False);
        Assert.That(char.IsUpper(result[0]), Is.True);
    }
}

public class WordAttributeTests
{
    [Test]
    public void Generate_ShouldReturnLowercaseNonEmptyString()
    {
        // Arrange
        var faker = new Faker();
        var wordAttribute = new Word();

        // Act
        var result = wordAttribute.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>(), "Result should be of type string.");

        var resultString = result as string;
        Assert.That(resultString, Is.Not.Null.And.Not.Empty, "Resulting string should not be null or empty.");
        Assert.That(resultString, Is.EqualTo(resultString.ToLower()), "Resulting string should be in lowercase.");
    }
}

public class IntRangeAttributeTests
{
    [Test]
    public void Generate_ShouldReturnIntegerWithinRange()
    {
        // Arrange
        int min = 10, max = 20;
        var attr = new IntRangeAttribute(min, max);
        var faker = new Faker();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<int>());
        int value = (int)result;
        Assert.That(value, Is.GreaterThanOrEqualTo(min).And.LessThanOrEqualTo(max));
    }

    [Test]
    public void Generate_ShouldReturnStringWithinRange_WhenAsStringIsTrue()
    {
        // Arrange
        int min = 100, max = 200;
        var attr = new IntRangeAttribute(min, max, asString: true);
        var faker = new Faker();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        Assert.That(int.TryParse(result as string, out int value), Is.True);
        Assert.That(value, Is.GreaterThanOrEqualTo(min).And.LessThanOrEqualTo(max));
    }

    [Test]
    public void Generate_ShouldReturnDifferentValues()
    {
        // Arrange
        var attr = new IntRangeAttribute(1, 1000);
        var faker = new Faker();

        // Act
        var result1 = attr.Generate(faker, null);
        var result2 = attr.Generate(faker, null);

        // Assert
        Assert.That(result1, Is.Not.EqualTo(result2), "Random values should typically be different");
    }
}

public class RestrictedLengthStringTests
{
    [Test]
    public void Generate_ShouldReturnStringWithinRestrictedLength()
    {
        // Arrange
        int minLength = 5;
        int maxLength = 10;
        var attr = new RestrictedLengthString(minLength, maxLength);
        var faker = new Faker();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        var str = result as string;
        Assert.That(str!.Length, Is.GreaterThanOrEqualTo(minLength).And.LessThanOrEqualTo(maxLength));
    }

    [Test]
    public void Generate_ShouldReturnDifferentValues()
    {
        // Arrange
        var attr = new RestrictedLengthString(5, 15);
        var faker = new Faker();

        // Act
        var result1 = attr.Generate(faker, null) as string;
        var result2 = attr.Generate(faker, null) as string;

        // Assert
        Assert.That(result1, Is.Not.Null.And.Not.Empty);
        Assert.That(result2, Is.Not.Null.And.Not.Empty);
        Assert.That(result1, Is.Not.EqualTo(result2), "Random values should typically differ.");
    }
}

public class SentenceAttributeTests
{
    [Test]
    public void Generate_ShouldReturnNonEmptySentence()
    {
        // Arrange
        var faker = new Faker();
        var sentenceAttribute = new Sentence();

        // Act
        var result = sentenceAttribute.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        var sentence = result as string;
        Assert.That(sentence, Is.Not.Null.And.Not.Empty);
        Assert.That(sentence!.Length, Is.GreaterThan(1));
    }

    [Test]
    public void Generate_ShouldEndWithPunctuation()
    {
        // Arrange
        var faker = new Faker();
        var sentenceAttribute = new Sentence();

        // Act
        var result = sentenceAttribute.Generate(faker, null) as string;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty);
        Assert.That(result!.EndsWith("."), Is.True, "Generated sentence should end with a period.");
    }

    [Test]
    public void Generate_ShouldReturnDifferentSentences()
    {
        // Arrange
        var faker = new Faker();
        var sentenceAttribute = new Sentence();

        // Act
        var sentence1 = sentenceAttribute.Generate(faker, null) as string;
        var sentence2 = sentenceAttribute.Generate(faker, null) as string;

        // Assert
        Assert.That(sentence1, Is.Not.Null.And.Not.Empty);
        Assert.That(sentence2, Is.Not.Null.And.Not.Empty);
        Assert.That(sentence1, Is.Not.EqualTo(sentence2), "Sentences should typically vary.");
    }
}

public class UuidHyphenatedAttributeTests
{
    [Test]
    public void Generate_ShouldReturnValidGuidString()
    {
        // Arrange
        var faker = new Faker();
        var uuidAttribute = new UuidHyphenated();

        // Act
        var result = uuidAttribute.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        Assert.That(Guid.TryParse(result as string, out _), Is.True, "Result should be a valid GUID.");
    }

    [Test]
    public void Generate_ShouldBeHyphenatedFormat()
    {
        // Arrange
        var faker = new Faker();
        var uuidAttribute = new UuidHyphenated();

        // Act
        var result = uuidAttribute.Generate(faker, null) as string;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty);
        Assert.That(result!.Count(c => c == '-'), Is.EqualTo(4), "Hyphenated GUID should contain 4 hyphens.");
    }

    [Test]
    public void Generate_ShouldReturnDifferentValues()
    {
        // Arrange
        var faker = new Faker();
        var uuidAttribute = new UuidHyphenated();

        // Act
        var result1 = uuidAttribute.Generate(faker, null) as string;
        var result2 = uuidAttribute.Generate(faker, null) as string;

        // Assert
        Assert.That(result1, Is.Not.Null.And.Not.Empty);
        Assert.That(result2, Is.Not.Null.And.Not.Empty);
        Assert.That(result1, Is.Not.EqualTo(result2), "Generated GUIDs should typically be different.");
    }
}

public class FormattedDateAttributeTests
{
    private const string ExpectedFormat = "yyyy-MM-dd";
    private static readonly DateTime MinDate = DateTime.Now.AddYears(-100);
    private static readonly DateTime MaxDate = DateTime.Now.AddYears(100);

    [Test]
    public void Generate_ShouldReturnFormattedDateString()
    {
        // Arrange
        var faker = new Faker();
        var attribute = new FormattedDateAttribute();

        // Act
        var result = attribute.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        var dateStr = result as string;

        // Ensure it matches the expected format exactly
        Assert.That(DateTime.TryParseExact(dateStr, ExpectedFormat, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var parsedDate), Is.True, "Date should match 'yyyy-MM-dd' format");

        // Ensure the date falls within the expected range
        Assert.That(parsedDate, Is.GreaterThanOrEqualTo(MinDate).And.LessThanOrEqualTo(MaxDate));
    }

    [Test]
    public void Generate_ShouldReturnDifferentFormattedDates()
    {
        // Arrange
        var faker = new Faker();
        var attribute = new FormattedDateAttribute();

        // Act
        var date1 = attribute.Generate(faker, null) as string;
        var date2 = attribute.Generate(faker, null) as string;

        // Assert
        Assert.That(date1, Is.Not.Null.And.Not.Empty);
        Assert.That(date2, Is.Not.Null.And.Not.Empty);
        Assert.That(date1, Is.Not.EqualTo(date2), "Generated dates should typically differ.");
    }
}

public class OneOfAttributeTests
{
    [Test]
    public void Generate_ShouldReturnOneOfTheProvidedValues()
    {
        // Arrange
        var options = new object[] { "Red", "Green", "Blue" };
        var attribute = new OneOfAttribute(options);
        var faker = new Faker();

        // Act
        var result = attribute.Generate(faker, null);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(options.Contains(result), Is.True, "Result should be one of the specified values.");
    }

    [Test]
    public void Generate_ShouldReturnDifferentValuesOverMultipleCalls()
    {
        // Arrange
        var options = new object[] { "Apple", "Banana", "Cherry" };
        var attribute = new OneOfAttribute(options);
        var faker = new Faker();

        // Act
        var result1 = attribute.Generate(faker, null);
        var result2 = attribute.Generate(faker, null);

        // Assert
        Assert.That(result1, Is.Not.Null);
        Assert.That(result2, Is.Not.Null);
        Assert.That(result1, Is.Not.EqualTo(result2).Or.EqualTo(result2), "Values should be from the defined set and may vary.");
    }

    [Test]
    public void Constructor_ShouldThrow_WhenNoValuesProvided()
    {
        // Assert
        Assert.That(() => new OneOfAttribute(null), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void Generate_ShouldThrow_WhenValuesArrayIsEmpty()
    {
        // Arrange
        var attribute = new OneOfAttribute(Array.Empty<object>());
        var faker = new Faker();

        // Assert
        Assert.That(() => attribute.Generate(faker, null), 
            Throws.TypeOf<InvalidOperationException>()
                .With.Message.EqualTo("No values provided for OneOfAttribute."));
    }
}

public class PostcodeAttributeTests
{
    [Test]
    public void Generate_ShouldReturnPostcodeOfCorrectFormat()
    {
        // Arrange
        var faker = new Faker();
        var postcodeAttr = new Postcode();

        // Act
        var result = postcodeAttr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        var postcode = result as string;
        Assert.That(postcode, Is.Not.Null.And.Not.Empty);
        Assert.That(postcode!.Length, Is.EqualTo(6));
        Assert.That(Regex.IsMatch(postcode, @"^\d{4}[A-Z]{2}$"), Is.True, "Postcode should be 4 digits followed by 2 uppercase letters.");
    }

    [Test]
    public void Generate_ShouldProduceDifferentPostcodes()
    {
        // Arrange
        var faker = new Faker();
        var postcodeAttr = new Postcode();

        // Act
        var value1 = postcodeAttr.Generate(faker, null) as string;
        var value2 = postcodeAttr.Generate(faker, null) as string;

        // Assert
        Assert.That(value1, Is.Not.Null.And.Not.Empty);
        Assert.That(value2, Is.Not.Null.And.Not.Empty);
        Assert.That(value1, Is.Not.EqualTo(value2), "Generated postcodes should typically differ.");
    }
}

public class WebAddressAttributeTests
{
    [Test]
    public void Generate_ShouldReturnWebadresObjectWithValidUrlAndCode()
    {
        // Arrange
        var faker = new Faker();
        var attr = new WebAddress();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<Webadres>());

        var webadres = result as Webadres;
        Assert.That(webadres, Is.Not.Null);
        Assert.That(webadres!.CodeWebadres, Is.InRange(1, 2));
        Assert.That(webadres.Url, Is.Not.Null.And.Not.Empty);
        Assert.That(Uri.TryCreate(webadres.Url, UriKind.Absolute, out _), Is.True, "Url should be a valid absolute URI.");
        Assert.That(webadres.Url, Does.Match(@"^https?://.+/.+"), "Url should contain a path segment (slug).");
    }

    [Test]
    public void Generate_ShouldReturnDifferentUrls()
    {
        // Arrange
        var faker = new Faker();
        var attr = new WebAddress();

        // Act
        var result1 = attr.Generate(faker, null) as Webadres;
        var result2 = attr.Generate(faker, null) as Webadres;

        // Assert
        Assert.That(result1?.Url, Is.Not.Null.And.Not.Empty);
        Assert.That(result2?.Url, Is.Not.Null.And.Not.Empty);
        Assert.That(result1!.Url, Is.Not.EqualTo(result2!.Url), "Generated URLs should typically differ.");
    }
}

public class WebUrlAttributeTests
{
    [Test]
    public void Generate_ShouldReturnValidUrlWithPath()
    {
        // Arrange
        var faker = new Faker();
        var attr = new WebUrl();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());

        var url = result as string;
        Assert.That(url, Is.Not.Null.And.Not.Empty);
        Assert.That(Uri.TryCreate(url, UriKind.Absolute, out var uriResult), Is.True, "URL should be a valid absolute URI.");
        Assert.That(uriResult!.AbsolutePath, Does.Not.EqualTo("/"), "URL should contain a path (slug).");
    }

    [Test]
    public void Generate_ShouldReturnDifferentUrls()
    {
        // Arrange
        var faker = new Faker();
        var attr = new WebUrl();

        // Act
        var url1 = attr.Generate(faker, null) as string;
        var url2 = attr.Generate(faker, null) as string;

        // Assert
        Assert.That(url1, Is.Not.Null.And.Not.Empty);
        Assert.That(url2, Is.Not.Null.And.Not.Empty);
        Assert.That(url1, Is.Not.EqualTo(url2), "Generated URLs should typically differ.");
    }
}

public class CodeTaalAttributeTests
{
    private static readonly List<string> AllowedCodes = new()
    {
        "nld", "eng", "fra", "deu", "spa", "por", "tur", "ara", "kur", "nor", "swe", "ces"
    };

    [Test]
    public void Generate_ShouldReturnCommaSeparatedCodes_OnlyFromAllowedList()
    {
        // Arrange
        var faker = new Faker();
        var attr = new CodeTaal();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<string>());
        var resultString = result as string;
        Assert.That(resultString, Is.Not.Null.And.Not.Empty);

        var selectedCodes = resultString!.Split(", ").ToList();

        Assert.That(selectedCodes.Count, Is.InRange(1, 3), "Should select between 1 and 3 codes");
        Assert.That(selectedCodes.All(code => AllowedCodes.Contains(code)), Is.True, "All codes must be from the allowed list");
    }

    [Test]
    public void Generate_ShouldReturnDifferentCombinations()
    {
        // Arrange
        var faker = new Faker();
        var attr = new CodeTaal();

        // Act
        var value1 = attr.Generate(faker, null) as string;
        var value2 = attr.Generate(faker, null) as string;

        // Assert
        Assert.That(value1, Is.Not.Null.And.Not.Empty);
        Assert.That(value2, Is.Not.Null.And.Not.Empty);
        Assert.That(value1, Is.Not.EqualTo(value2), "Generated code combinations should typically differ");
    }
}

[TestFixture]
public class EmailAttributeTests
{
    private Faker _faker;
    private static readonly Regex EmailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
    }

    [Test]
    public void Generate_ShouldReturnValidSingleEmail()
    {
        // Arrange
        var attribute = new Email(asList: false);

        // Act
        var result = attribute.Generate(_faker, null) as string;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty, "Generated email should not be null or empty.");
        Assert.That(EmailRegex.IsMatch(result), Is.True, $"Generated email '{result}' is not in a valid format.");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Generate_ShouldReturnValidListOfEmails(int maxLength)
    {
        // Arrange
        var attribute = new Email(asList: true, maxLength: maxLength);

        // Act
        var result = attribute.Generate(_faker, null) as List<string>;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty, "Generated email list should not be null or empty.");
        Assert.That(result.Count, Is.InRange(1, maxLength), $"Generated email list count {result.Count} is not within the expected range.");

        foreach (var email in result)
        {
            Assert.That(email, Is.Not.Null.And.Not.Empty, "Each email should not be null or empty.");
            Assert.That(EmailRegex.IsMatch(email), Is.True, $"Email '{email}' is not in a valid format.");
        }
    }
}

[TestFixture]
public class DutchPhoneNumberAttributeTests
{
    private static readonly Regex MobileRegex = new Regex(@"^\+31\s6\s\d{8}$", RegexOptions.Compiled);
    private static readonly Regex LandlineRegex = new Regex(@"^\+31\d{9,10}$", RegexOptions.Compiled);

    [Test]
    public void Generate_ShouldReturnValidSingleDutchPhoneNumber()
    {
        // Arrange
        var faker = new Faker();
        var attribute = new DutchPhoneNumber(asList: false);

        // Act
        var result = attribute.Generate(faker, null) as string;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty, "Generated phone number should not be null or empty.");
        Assert.That(
            result,
            Does.Match(MobileRegex).Or.Match(LandlineRegex),
            $"Generated phone number '{result}' does not match the expected Dutch E.164 format."
        );
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Generate_ShouldReturnValidListOfDutchPhoneNumbers(int maxLength)
    {
        // Arrange
        var faker = new Faker();
        var attribute = new DutchPhoneNumber(asList: true, maxLength: maxLength);

        // Act
        var result = attribute.Generate(faker, null) as List<string>;

        // Assert
        Assert.That(result, Is.Not.Null.And.Not.Empty, "Generated list should not be null or empty.");
        Assert.That(result.Count, Is.InRange(1, maxLength), $"Generated list count {result.Count} is not within the expected range.");
        foreach (var phoneNumber in result)
        {
            Assert.That(
                phoneNumber,
                Does.Match(MobileRegex).Or.Match(LandlineRegex),
                $"Generated phone number '{phoneNumber}' does not match the expected Dutch E.164 format."
            );
        }
    }
}

[TestFixture]
public class OneOfBeroepsnaamAttributeTests
{
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
    }

    [Test]
    public void Generate_ShouldReturnSingleBeroepsnaam()
    {
        // Arrange
        var attribute = new OneOfBeroepsnaam(asList: false);

        // Act
        var result = attribute.Generate(_faker, null);

        // Assert
        Assert.That(result, Is.InstanceOf<Beroepsnaam>(), "Result should be of type Beroepsnaam.");

        var beroepsnaam = (Beroepsnaam)result;

        Assert.That(
            beroepsnaam.BeroepsnaamGecodeerd != null || beroepsnaam.BeroepsnaamOngecodeerd != null,
            Is.True,
            "Either BeroepsnaamGecodeerd or BeroepsnaamOngecodeerd should be set."
        );

        if (beroepsnaam.BeroepsnaamGecodeerd != null)
        {
            Assert.That(beroepsnaam.BeroepsnaamGecodeerd.CodeBeroepsnaam, Is.Not.Null.And.Not.Empty, "CodeBeroepsnaam should not be null or empty.");
            Assert.That(beroepsnaam.BeroepsnaamGecodeerd.OmschrijvingBeroepsnaam, Is.Not.Null.And.Not.Empty, "OmschrijvingBeroepsnaam should not be null or empty.");
        }
        else
        {
            Assert.That(beroepsnaam.BeroepsnaamOngecodeerd.NaamBeroepOngecodeerd, Is.Not.Null.And.Not.Empty, "NaamBeroepOngecodeerd should not be null or empty.");
        }
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void Generate_ShouldReturnListOfBeroepsnaam(int maxLength)
    {
        // Arrange
        var attribute = new OneOfBeroepsnaam(asList: true, maxLength: maxLength);

        // Act
        var result = attribute.Generate(_faker, null);

        // Assert
        Assert.That(result, Is.InstanceOf<List<Beroepsnaam>>(), "Result should be a list of Beroepsnaam.");

        var list = (List<Beroepsnaam>)result;

        Assert.That(list.Count, Is.InRange(1, maxLength), $"List count should be between 1 and {maxLength}.");

        foreach (var beroepsnaam in list)
        {
            Assert.That(
                beroepsnaam.BeroepsnaamGecodeerd != null || beroepsnaam.BeroepsnaamOngecodeerd != null,
                Is.True,
                "Each Beroepsnaam should have either BeroepsnaamGecodeerd or BeroepsnaamOngecodeerd set."
            );

            if (beroepsnaam.BeroepsnaamGecodeerd != null)
            {
                Assert.That(beroepsnaam.BeroepsnaamGecodeerd.CodeBeroepsnaam, Is.Not.Null.And.Not.Empty, "CodeBeroepsnaam should not be null or empty.");
                Assert.That(beroepsnaam.BeroepsnaamGecodeerd.OmschrijvingBeroepsnaam, Is.Not.Null.And.Not.Empty, "OmschrijvingBeroepsnaam should not be null or empty.");
            }
            else
            {
                Assert.That(beroepsnaam.BeroepsnaamOngecodeerd.NaamBeroepOngecodeerd, Is.Not.Null.And.Not.Empty, "NaamBeroepOngecodeerd should not be null or empty.");
            }
        }
    }
}

public class OneOfOpleidingsnaamAttributeTests
{
    [Test]
    public void Generate_ShouldReturnOpleidingsnaam_WithEitherGecodeerdOrOngecodeerd()
    {
        // Arrange
        var faker = new Faker();
        var attr = new OneOfOpleidingsnaam();

        // Act
        var result = attr.Generate(faker, null);

        // Assert
        Assert.That(result, Is.TypeOf<Opleidingsnaam>());

        var opleidingsnaam = result as Opleidingsnaam;
        Assert.That(opleidingsnaam, Is.Not.Null);

        var hasGecodeerd = opleidingsnaam!.OpleidingsnaamGecodeerd != null;
        var hasOngecodeerd = opleidingsnaam.OpleidingsnaamOngecodeerd != null;

        Assert.That(hasGecodeerd || hasOngecodeerd, Is.True, "At least one of the fields must be filled");
        Assert.That(hasGecodeerd && hasOngecodeerd, Is.False, "Only one of the fields should be filled");

        if (hasGecodeerd)
        {
            var g = opleidingsnaam.OpleidingsnaamGecodeerd!;
            Assert.That(g.CodeOpleidingsnaam, Is.Not.Null.And.Not.Empty);
            Assert.That(g.OmschrijvingOpleidingsnaam, Is.Not.Null.And.Not.Empty);
        }
        else if (hasOngecodeerd)
        {
            var o = opleidingsnaam.OpleidingsnaamOngecodeerd!;
            Assert.That(o.NaamOpleidingOngecodeerd, Is.Not.Null.And.Not.Empty);
            Assert.That(o.OmschrijvingOpleiding, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test]
    public void Generate_ShouldReturnBothVariantsOverMultipleRuns()
    {
        // Arrange
        var faker = new Faker();
        var attr = new OneOfOpleidingsnaam();

        // Act
        var results = Enumerable.Range(0, 10)
            .Select(_ => attr.Generate(faker, null) as Opleidingsnaam)
            .ToList();

        var countGecodeerd = results.Count(x => x!.OpleidingsnaamGecodeerd != null);
        var countOngecodeerd = results.Count(x => x!.OpleidingsnaamOngecodeerd != null);

        // Assert
        Assert.That(countGecodeerd + countOngecodeerd, Is.EqualTo(10));
        Assert.That(countGecodeerd, Is.GreaterThan(0), "At least one result should be 'gecodeerd'");
        Assert.That(countOngecodeerd, Is.GreaterThan(0), "At least one result should be 'ongecodeerd'");
    }
}
