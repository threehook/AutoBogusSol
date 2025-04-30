using Xunit;
using Bogus;
using static AutoBogusApp.DataGeneration.FakerCommons;

namespace AutoBogusApp.Test
{
    public class DateGeneratorTests
    {
        private const int DateMin = -100;
        private const int DateMax = 100;
        private const string Format = "yyyy-MM-dd";

        [Fact]
        public void GenerateDate_ReturnsDateWithinRange()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            string result = GenerateDate(faker);
            DateTime generatedDate = DateTime.Parse(result);

            // Assert
            DateTime minDate = DateTime.Now.AddYears(DateMin);
            DateTime maxDate = DateTime.Now.AddYears(DateMax);

            Assert.InRange(generatedDate, minDate, maxDate);
            Assert.Matches(@"^\d{4}-\d{2}-\d{2}$", result);
        }
    }

    public class TelefoonnummerGeneratorTests : IDisposable
    {
        private Faker _faker;
        private const int MaxItems = 3;

        public TelefoonnummerGeneratorTests()
        {
            _faker = new Faker("nl");
        }

        public void Dispose() {}

        [Fact]
        public void GenerateTelefoonnummer_ReturnsListWithCorrectCount()
        {
            // Act
            var result = GenerateTelefoonnummer(_faker, MaxItems);

            // Assert
            Assert.NotNull(result);
            Assert.InRange(result.Count, 1, MaxItems);
            Assert.All(result, item => Assert.Matches(@"^[\s\(\)]*(?:\d[\s\(\)]*){10}[\s\(\)]*$", item));
        }

        [Fact]
        public void GenerateTelefoonnummer_ReturnsDifferentNumbers()
        {
            // Act - Run multiple times to check for uniqueness
            var result = new List<List<string>>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(GenerateTelefoonnummer(_faker, MaxItems));
            }

            // Assert - At least some variation should exist
            Assert.True(result.SelectMany(x => x).Distinct().Count() > 1);
        }

        [Fact]
        public void GenerateTelefoonnummer_WithZeroMaxItems_ReturnsDefault()
        {
            // Arrange
            const int maxItems = 0;

            // Act
            var phoneNumbers = GenerateTelefoonnummer(_faker, maxItems);

            // Assert
            Assert.Single(phoneNumbers);
        }

        [Fact]
        public void GenerateTelefoonnummer_WithNegativeMaxItems_ThrowsException()
        {
            // Arrange
            const int maxItems = -1;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => GenerateTelefoonnummer(_faker, maxItems));
        }

    }

    public class CodeGeneratorTests : IDisposable
    {
        private Faker _faker;

        public CodeGeneratorTests()
        {
            _faker = new Faker("nl");
        }

        public void Dispose() {}

        [Fact]
        public void GenerateCode_ProducesValidOutput()
        {
            // Arrange
            const int minLength = 5;
            const int maxLength = 10;

            // Act
            var result = GenerateCode(_faker, minLength, maxLength);

            // Assert
            // Length validation
            Assert.True(result.Length >= minLength);
            Assert.True(result.Length <= maxLength);

            // Character validation
            Assert.DoesNotContain(" ", result);
            Assert.True(result.All(char.IsLower));

            // Randomness validation
            var secondResult = GenerateCode(_faker, minLength, maxLength);
            Assert.NotEqual(result, secondResult);
        }

        [Fact]
        public void GenerateCode_EdgeCases()
        {
            // Equal min and max length
            var fixedLengthResult = GenerateCode(_faker, 7, 7);
            Assert.Equal(7, fixedLengthResult.Length);

            // Minimum possible length
            var minFixedLengthResult = GenerateCode(_faker, 1, 1);
            Assert.Equal(1, minFixedLengthResult.Length);

            // Zero length is empty string
            var emptyResult = GenerateCode(_faker, 0, 0);
            Assert.Empty(emptyResult);

            // Minlength is greater than MaxLength
            var minResult = GenerateCode(_faker, 2, 1);
            Assert.Equal(2, minResult.Length);
        }
    }

    public partial class NameGeneratorTests : IDisposable
    {
        private Faker _faker;

        public NameGeneratorTests()
        {
            _faker = new Faker("nl");
        }

        public void Dispose() {}

        [Fact]
        public void GenerateName_ProducesValidOutput()
        {
            // Arrange
            const int minLength = 10;
            const int maxLength = 30;
            
            // Act
            var result = GenerateName(_faker, minLength, maxLength);

            // Assert - Combined validation
            Assert.Multiple(() =>
            {
                // Length validation
                Assert.True(result.Length >= minLength);
                Assert.True(result.Length <= maxLength);

                // Format validation
                Assert.True(char.IsUpper(result[0]));
                Assert.DoesNotMatch("[A-Z]", result[1..]);
                Assert.DoesNotContain($" ", result);

                // Content validation
                Assert.True(result.Length >= 10);
            });
        }

        [Fact]
        public void GenerateName_EdgeCases()
        {
            // Test min boundary
            var minResult = GenerateName(_faker, 5, 5);
            Assert.Equal(5, minResult.Length);
    
            // Test max boundary
            var maxResult = GenerateName(_faker, 30, 30);
            Assert.Equal(30, maxResult.Length);
            
            // Zero length is empty string
            var emptyResult = GenerateName(_faker, 0, 0);
            Assert.Empty(emptyResult);                
    
            // Test negatives
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => GenerateName(_faker, -10, -5));
            Assert.Contains("negative", ex.Message, StringComparison.OrdinalIgnoreCase);
        }
    }
    
    public class PostcodeGeneratorTests
    {
        [Fact]
        public void GeneratePostcode_ShouldReturnValidPostcode()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var postcode = GeneratePostcode(faker);

            // Assert
            Assert.NotNull(postcode);
            Assert.NotEmpty(postcode);
            Assert.Equal(6, postcode.Length);
        
            // Verify first 4 characters are digits
            var digitsPart = postcode.Substring(0, 4);
            Assert.True(digitsPart.All(char.IsDigit));
        
            // Verify last 2 characters are uppercase letters
            var lettersPart = postcode.Substring(4, 2);
            Assert.Matches(@"^[A-Z]{2}$", lettersPart);
        }
    }

    public class GedragscompetentieGeneratorTests
    {
        [Fact]
        public void GenerateGedragscompetentie_ShouldReturnValidGedragscompetenties()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateGedragscompetentie(faker, 2);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.InRange(result.Count, 1, 2);

            var allowedCodes = new HashSet<string> {
                "24100", "24101", "24102", "24104", "24105", "24106", "24107", "24108", "24109", "24110", "24111", "24112", "24113", "24114", "24115", "24116", 
                "24118", "24119", "24120", "24121", "24122", "24123", "24124", "24125", "24126"
            };

            var allowedBeheersingCodes = new HashSet<int?> { 1, 2, 3, 4, 5, 9 };

            var allowedDescriptions = new HashSet<string> {
                "Beslissen en activiteiten initiëren", "Aansturen Begeleiden", "Aandacht en begrip tonen", "Samenwerken en overleggen", 
                "Ethisch en integer handelen", "Relaties bouwen en netwerken", "Overtuigen en beïnvloeden", "Presenteren", "Formuleren en rapporteren",
                "Vakdeskundigheid toepassen", "Materialen en middelen inzetten", "Analyseren", "Onderzoeken", "Creëren en innoveren", "Leren", "Plannen en organiseren",
                "Op de behoeften en verwachtingen van de klant richten", "Kwaliteit leveren", "Instructies en procedures opvolgen", "Omgaan met verandering en aanpassen",
                "Met druk en tegenslag omgaan", "Gedrevenheid en ambitie tonen", "Ondernemend en commercieel handelen", "Bedrijfsmatig handelen"
            };

            foreach (var gc in result)
            {
                Assert.NotNull(gc);
                Assert.Contains(gc.CodeGedragscompetentie, allowedCodes!);
                Assert.Contains(gc.CodeBeheersingGedragscompetentie, allowedBeheersingCodes);
                Assert.Contains(gc.OmschrijvingGedragscompetentie, allowedDescriptions!);
            }
        }
    }
    
    public class BeroepsnaamGeneratorTests
    {
        [Fact]
        public void GenerateBeroepsnaamGecodeerd_ShouldReturnValidBeroepsnaam()
        {
            var result = GenerateBeroepsnaamGecodeerd(new Faker("nl"));

            Assert.False(string.IsNullOrEmpty(result?.BeroepsnaamGecodeerd?.CodeBeroepsnaam));
            Assert.False(string.IsNullOrEmpty(result?.BeroepsnaamGecodeerd?.OmschrijvingBeroepsnaam));
        }

        [Fact]
        public void GenerateBeroepsnaamOngecodeerd_ShouldReturnValidBeroepsnaam()
        {
            var result = GenerateBeroepsnaamOngecodeerd(new Faker("nl"));
            
            Assert.False(string.IsNullOrEmpty(result?.BeroepsnaamOngecodeerd?.NaamBeroepOngecodeerd));
        }
    }
    
    public class FlexibiliteitGeneratorTests
    {
        [Fact]
        public void GenerateFlexibiliteit_ShouldReturnValidFlexibiliteit_WithMessages()
        {
            var result = GenerateFlexibiliteit(new Faker("nl"));
            var regexDateFormat = @"^\d{4}-\d{2}-\d{2}$";
            
            Assert.NotNull(result);
            Assert.True(result.CodeRegiostraal is >= 1 and <= 9);
            Assert.Matches(regexDateFormat, result.DatumAanvangBeschikbaarVoorWerk!);
            Assert.Matches(regexDateFormat, result.DatumEindeBeschikbaarVoorWerk!);
            Assert.True(result.IndicatieOnregelmatigWerkOfPloegendienst is >= 0 and <= 2);
        }
    }

    public class SectorGeneratorTests
    {
        [Fact]
        public void GenerateSector_ShouldReturnValidSectorList()
        {
            // Arrange
            var faker = new Faker("nl");
            int maxItems = 3;

            // Act
            var result = GenerateSector(faker, maxItems);

            // Assert
            Assert.NotNull(result);
            Assert.InRange(result.Count, 1, maxItems);
        }

        [Fact]
        public void GenerateSector_ShouldReturnValidSector()
        {
            var sbiCodes = new HashSet<int?>
            {
                101, 102, 103, 104, 105, 106, 107, 2013, 2014, 2015, 2016, 2017, 2020, 2030, 47762, 47763, 47781, 47782, 47783, 47789
            };
            
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateSector(faker);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.CodeSbi);
            Assert.Contains(result.CodeSbi, sbiCodes);
        }
    }
    
    public class VervoermiddelGeneratorTests
    {
        [Fact]
        public void GenerateVervoermiddel_ShouldReturnValidList()
        {
            // Arrange
            var faker = new Faker("nl");
            var validCodeVervoermiddel = new HashSet<int?> { 1, 2, 3, 4, 5, 9 };
            var validIndicatie = new HashSet<int?> { 0, 1, 2 };

            // Act
            var result = GenerateVervoermiddel(faker, 2);

            // Assert
            Assert.NotNull(result);
            Assert.InRange(result.Count, 1, 2);

            // Assert: Validate each item in the result list
            foreach (var vervoermiddel in result)
            {
                Assert.NotNull(vervoermiddel);
                Assert.Contains(vervoermiddel.CodeVervoermiddel, validCodeVervoermiddel);
                Assert.Contains(vervoermiddel.IndicatieBeschikbaarVoorUitvoeringWerk, validIndicatie);
                Assert.Contains(vervoermiddel.IndicatieBeschikbaarVoorWoonWerkverkeer, validIndicatie);
            }
        }
    }
    
    public class WebadresGeneratorTests
    {
        [Fact]
        public void GenerateWebadres_ShouldReturnValidList()
        {
            // Arrange
            var faker = new Faker("nl");
            int maxItems = 3;

            // Act
            var result = GenerateWebadres(faker, maxItems);

            // Assert
            Assert.NotNull(result);
            Assert.InRange(result.Count, 1, maxItems);

            // Assert: Validate each item in the result list
            foreach (var webadres in result)
            {
                Assert.NotNull(webadres);
                Assert.False(string.IsNullOrEmpty(webadres.Url));
                Assert.True(webadres.Url.StartsWith("http") || webadres.Url.StartsWith("https"));
            }
        }
    }

    public class WerktijdenGeneratorTests
    {
        [Fact]
        public void GenerateWerktijden_ShouldReturnValidWerktijden()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateWerktijden(faker);

            // Assert
            Assert.NotNull(result); // Result should not be null

            // Validate AantalWerkurenPerWeekMinimaal
            Assert.InRange(result.AantalWerkurenPerWeekMinimaal!.Value, 1, 99);

            // Validate AantalWerkurenPerWeekMaximaal
            Assert.InRange(result.AantalWerkurenPerWeekMaximaal!.Value, 1, 99);

            // Validate IndicatieKantoortijden
            Assert.InRange(result.IndicatieKantoortijden!.Value, 0, 2);
        }
    }
}
