using System.Globalization;
using AutoBogusApp.DataGeneration;
using AutoBogusApp.Vum;
using NUnit.Framework;
using Bogus;
using static AutoBogusApp.DataGeneration.CommonFaker;

namespace AutoBogusApp.Test
{
    public class MpWerkzoekendeMatchGeneratorTests
    {
        [Test]
        public void FakeMPWerkzoekendeMatch_ShouldGenerateMPWerkzoekendeMatchWithAllNestedObjects()
        {
            // Arrange
            WerkzoekendeFaker faker = new WerkzoekendeFaker();

            // Act
            var mpWerkzoekendeMatch = faker.FakeMpWerkzoekendeMatch();

            // Assert
            Assert.That(mpWerkzoekendeMatch, Is.Not.Null);

            // Check that nested objects are not null
            Assert.That(mpWerkzoekendeMatch.Arbeidsmarktkwalificatie, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Bemiddelingsberoep, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Contractvorm, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Flexibiliteit, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.IdWerkzoekende, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.IndicatieBeschikbaarheidContactgegevens, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.IndicatieLdrRegistratie, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Mobiliteit, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Sector, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Vervoermiddel, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Voorkeursland, Is.Not.Null);
            Assert.That(mpWerkzoekendeMatch.Werktijden, Is.Not.Null);            

            // Check that lists have elements
            Assert.That(mpWerkzoekendeMatch.Bemiddelingsberoep, Is.Not.Empty);
            Assert.That(mpWerkzoekendeMatch.Contractvorm, Is.Not.Empty);
            Assert.That(mpWerkzoekendeMatch.Sector, Is.Not.Empty);
            Assert.That(mpWerkzoekendeMatch.Vervoermiddel, Is.Not.Empty);
            Assert.That(mpWerkzoekendeMatch.Voorkeursland, Is.Not.Empty);
        }
    }    
    
    public class WerkzoekendeGeneratorTests
    {
        [Test]
        public void FakeWerkzoekende_ShouldGenerateWerkzoekendeWithAllNestedObjects()
        {
            // Arrange
            WerkzoekendeFaker faker = new WerkzoekendeFaker();

            // Act
            var werkzoekende = faker.FakeWerkzoekende();

            // Assert
            Assert.That(werkzoekende, Is.Not.Null);

            // Check that nested objects are not null
            Assert.That(werkzoekende.Arbeidsmarktkwalificatie, Is.Not.Null);
            Assert.That(werkzoekende.Bemiddelingsberoep, Is.Not.Null);
            Assert.That(werkzoekende.Contactpersoon, Is.Not.Null);
            Assert.That(werkzoekende.EisAanWerk, Is.Not.Null);
            Assert.That(werkzoekende.Emailadres, Is.Not.Null);
            Assert.That(werkzoekende.Flexibiliteit, Is.Not.Null);
            Assert.That(werkzoekende.IdWerkzoekende, Is.Not.Null);
            Assert.That(werkzoekende.IndicatieBeschikbaarheidContactgegevens, Is.Not.Null);
            Assert.That(werkzoekende.IndicatieLdrRegistratie, Is.Not.Null);
            Assert.That(werkzoekende.Mobiliteit, Is.Not.Null);
            Assert.That(werkzoekende.PersoonlijkePresentatie, Is.Not.Null);
            Assert.That(werkzoekende.Sector, Is.Not.Null);
            Assert.That(werkzoekende.Telefoonnummer, Is.Not.Null);
            Assert.That(werkzoekende.Vervoermiddel, Is.Not.Null);
            Assert.That(werkzoekende.Voorkeursland, Is.Not.Null);
            Assert.That(werkzoekende.Webadres, Is.Not.Null);
            Assert.That(werkzoekende.Werktijden, Is.Not.Null);            

            // Check that lists have elements
            Assert.That(werkzoekende.Bemiddelingsberoep, Is.Not.Empty);
            Assert.That(werkzoekende.Contactpersoon, Is.Not.Empty);
            Assert.That(werkzoekende.Emailadres, Is.Not.Empty);
            Assert.That(werkzoekende.Sector, Is.Not.Empty);
            Assert.That(werkzoekende.Telefoonnummer, Is.Not.Empty);
            Assert.That(werkzoekende.Voorkeursland, Is.Not.Empty);
            Assert.That(werkzoekende.Webadres, Is.Not.Empty);
        }
    }

    public class MpVacatureMatchGeneratorTests
    {
        [Test]
        public void FakeMPVacatureMatch_ShouldGenerateMPVacatureMatchWithAllNestedObjects()
        {
            // Arrange
            VacatureFaker faker = new VacatureFaker();

            // Act
            var mpVacatureMatch = faker.FakeMpVacatureMatch();

            // Assert
            Assert.That(mpVacatureMatch, Is.Not.Null);
            
            // Check that nested objects are not null
            Assert.That(mpVacatureMatch.ArbeidsVoorwaarden, Is.Not.Null);
            Assert.That(mpVacatureMatch.Beroep, Is.Not.Null);
            Assert.That(mpVacatureMatch.CodeWerkEnDenkniveauMinimaal, Is.Not.Null);
            Assert.That(mpVacatureMatch.Contractvorm, Is.Not.Null);
            Assert.That(mpVacatureMatch.Cursus, Is.Not.Null);
            Assert.That(mpVacatureMatch.Mobiliteit, Is.Not.Null);
            Assert.That(mpVacatureMatch.Flexibiliteit, Is.Not.Null);
            Assert.That(mpVacatureMatch.Gedragscompetentie, Is.Not.Null);
            Assert.That(mpVacatureMatch.IdVacature, Is.Not.Null);
            Assert.That(mpVacatureMatch.IndicatieLdrRegistratie, Is.Not.Null);
            Assert.That(mpVacatureMatch.Opleiding, Is.Not.Null);
            Assert.That(mpVacatureMatch.Rijbewijs, Is.Not.Null);
            Assert.That(mpVacatureMatch.Sector, Is.Not.Null);
            Assert.That(mpVacatureMatch.SluitingsdatumVacature, Is.Not.Null);
            Assert.That(mpVacatureMatch.Sollicitatiewijze, Is.Not.Null);                   
            Assert.That(mpVacatureMatch.Taalbeheersing, Is.Not.Null);
            Assert.That(mpVacatureMatch.Vakvaardigheid, Is.Not.Null);
            Assert.That(mpVacatureMatch.Vervoermiddel, Is.Not.Null);
            Assert.That(mpVacatureMatch.Werkervaring, Is.Not.Null);
            Assert.That(mpVacatureMatch.Werkgever, Is.Not.Null);
            Assert.That(mpVacatureMatch.Werktijden, Is.Not.Null);
            
            // Check that lists have elements
            Assert.That(mpVacatureMatch.Contractvorm, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Cursus, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Gedragscompetentie, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Opleiding, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Rijbewijs, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Sollicitatiewijze, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Taalbeheersing, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Vakvaardigheid, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Vervoermiddel, Is.Not.Empty);
            Assert.That(mpVacatureMatch.Werkervaring, Is.Not.Empty);
        }
    }        
    
    public class VacatureGeneratorTests
    {
        [Test]
        public void FakeVacature_ShouldGenerateVacatureWithAllNestedObjects()
        {
            // Arrange
            VacatureFaker faker = new VacatureFaker();

            // Act
            var vacture = faker.FakeVacature();

            // Assert
            Assert.That(vacture, Is.Not.Null);
            
            // Check that nested objects are not null
            Assert.That(vacture.ArbeidsVoorwaarden, Is.Not.Null);
            Assert.That(vacture.Beroep, Is.Not.Null);
            Assert.That(vacture.CodeWerkEnDenkniveauMinimaal, Is.Not.Null);
            Assert.That(vacture.Contractvorm, Is.Not.Null);
            Assert.That(vacture.Cursus, Is.Not.Null);
            Assert.That(vacture.Flexibiliteit, Is.Not.Null);
            Assert.That(vacture.Gedragscompetentie, Is.Not.Null);
            Assert.That(vacture.IdVacature, Is.Not.Null);
            Assert.That(vacture.IndicatieLdrRegistratie, Is.Not.Null);
            Assert.That(vacture.NaamVacature, Is.Not.Null);
            Assert.That(vacture.NummerVacature, Is.Not.Null);
            Assert.That(vacture.OmschrijvingVacature, Is.Not.Null);
            Assert.That(vacture.Opleiding, Is.Not.Null);
            Assert.That(vacture.Rijbewijs, Is.Not.Null);
            Assert.That(vacture.Sector, Is.Not.Null);
            Assert.That(vacture.SluitingsdatumVacature, Is.Not.Null);
            Assert.That(vacture.Sollicitatiewijze, Is.Not.Null);                   
            Assert.That(vacture.Taalbeheersing, Is.Not.Null);
            Assert.That(vacture.Vakvaardigheid, Is.Not.Null);
            Assert.That(vacture.Vervoermiddel, Is.Not.Null);
            Assert.That(vacture.Werkervaring, Is.Not.Null);
            Assert.That(vacture.Werkgever, Is.Not.Null);
            Assert.That(vacture.Werktijden, Is.Not.Null);
            
            // Check that lists have elements
            Assert.That(vacture.Contractvorm, Is.Not.Empty);
            Assert.That(vacture.Cursus, Is.Not.Empty);
            Assert.That(vacture.Gedragscompetentie, Is.Not.Empty);
            Assert.That(vacture.Opleiding, Is.Not.Empty);
            Assert.That(vacture.Rijbewijs, Is.Not.Empty);
            Assert.That(vacture.Sollicitatiewijze, Is.Not.Empty);
            Assert.That(vacture.Taalbeheersing, Is.Not.Empty);
            Assert.That(vacture.Vakvaardigheid, Is.Not.Empty);
            Assert.That(vacture.Vervoermiddel, Is.Not.Empty);
            Assert.That(vacture.Werkervaring, Is.Not.Empty);
        }
    }
    
    public class DateGeneratorTests
    {
        private const int DateMin = -100;
        private const int DateMax = 100;
        private const string Format = "yyyy-MM-dd"; // Updated format

        [Test]
        public void GenerateDate_ReturnsDateWithinRange()
        {
            // Arrange
            var faker = new Faker("nl");
        
            // Act
            string result = GenerateDate(faker);
            DateTime generatedDate = DateTime.ParseExact(result, Format, CultureInfo.InvariantCulture);
        
            // Assert
            DateTime minDate = DateTime.Now.AddYears(DateMin);
            DateTime maxDate = DateTime.Now.AddYears(DateMax);
        
            Assert.That(generatedDate, Is.GreaterThanOrEqualTo(minDate).And.LessThanOrEqualTo(maxDate));
            Assert.That(result, Does.Match(@"^\d{4}-\d{2}-\d{2}$"));
            Assert.That(DateTime.TryParseExact(result, Format, CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out _), Is.True, "String was not in correct format");
        }
    }

    public class TelefoonnummerGeneratorTests
    {
        private Faker faker;
        private const int MaxItems = 3;

        [SetUp]
        public void Setup()
        {
            faker = new Faker("nl");
        }

        [Test]
        public void GenerateTelefoonnummer_ReturnsListWithCorrectCount()
        {
            // Act
            var result = GenerateTelefoonnummer(faker, MaxItems);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(MaxItems));
            Assert.That(result, Is.All.Matches(@"^[\s\(\)]*(?:\d[\s\(\)]*){10}[\s\(\)]*$"));
            Assert.That(result.Count, Is.LessThanOrEqualTo(result.Count));
        }

        [Test]
        public void GenerateTelefoonnummer_ReturnsDifferentNumbers()
        {
            // Act - Run multiple times to check for uniqueness
            var result = new List<List<string>>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(GenerateTelefoonnummer(faker, MaxItems));
            }

            // Assert - At least some variation should exist
            Assert.That(result.SelectMany(x => x).Distinct().Count(), Is.GreaterThan(1));
        }
        
        [Test]
        public void GenerateTelefoonnummer_WithZeroMaxItems_ReturnsDefault()
        {
            // Arrange
            const int maxItems = 0;

            // Act
            var phoneNumbers = GenerateTelefoonnummer(faker, maxItems);

            // Assert
            Assert.That(phoneNumbers, Has.Exactly(1).Items);
        }

        [Test]
        public void GenerateTelefoonnummer_WithNegativeMaxItems_ThrowsException()
        {
            // Arrange
            const int maxItems = -1;

            // Act & Assert
            Assert.That(() => GenerateTelefoonnummer(faker, maxItems),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }    

    }

    public class CodeGeneratorTests
    {
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private Faker faker;

        [SetUp]
        public void Setup()
        {
            faker = new Faker("nl");
        }

        [Test]
        public void GenerateCode_ProducesValidOutput()
        {
            // Arrange
            const int minLength = 5;
            const int maxLength = 10;

            // Act
            var result = GenerateCode(faker, minLength, maxLength);

            // Assert
            Assert.Multiple(() =>
            {
                // Length validation
                Assert.That(result.Length, Is.GreaterThanOrEqualTo(minLength), 
                    "Result is shorter than minLength");
                Assert.That(result.Length, Is.LessThanOrEqualTo(maxLength), 
                    "Result exceeds maxLength");

                // Character validation
                Assert.That(result, Does.Not.Contain(" "), 
                    "Result contains spaces");
                Assert.That(result.All(char.IsLower), Is.True, 
                    "Result contains uppercase characters");

                // Randomness validation
                var secondResult = GenerateCode(faker, minLength, maxLength);
                Assert.That(result, Is.Not.EqualTo(secondResult), 
                    "Results should differ with subsequent calls");
            });
        }

        [Test]
        public void GenerateCode_EdgeCases()
        {
            Assert.Multiple(() =>
            {
                // Equal min and max length
                var fixedLengthResult = GenerateCode(faker, 7, 7);
                Assert.That(fixedLengthResult.Length, Is.EqualTo(7));
                
                // Minimum possible length
                var minFixedLengthResult = GenerateCode(faker, 1, 1);
                Assert.That(minFixedLengthResult.Length, Is.EqualTo(1));
                
                // Zero length is empty string
                var emptyResult = GenerateCode(faker, 0, 0);
                Assert.That(emptyResult, Is.Empty);
                
                // Minlength is greater than MaxLength
                var minResult = GenerateCode(faker, 2, 1);
                Assert.That(minResult.Length, Is.EqualTo(2));                
            });
        }
    }

    public class NameGeneratorTests
    {
        private Faker faker;

        [SetUp]
        public void Setup()
        {
            faker = new Faker("nl");
        }

        [Test]
        public void GenerateName_ProducesValidOutput()
        {
            // Arrange
            const int minLength = 10;
            const int maxLength = 30;

            // Act
            var result = GenerateName(faker, minLength, maxLength);

            // Assert - Combined validation
            Assert.Multiple(() =>
            {
                // Length validation
                Assert.That(result.Length, Is.GreaterThanOrEqualTo(minLength), 
                    "Name is shorter than minLength");
                Assert.That(result.Length, Is.LessThanOrEqualTo(maxLength), 
                    "Name exceeds maxLength");

                // Format validation
                Assert.That(char.IsUpper(result[0]), "First character not capitalized");
                Assert.That(result.Substring(1), Does.Not.Match("[A-Z]"), 
                    "Uppercase letters found after first character");
                
                Assert.That(result, Does.Not.Contain(" "), 
                    "Name contains spaces (should be concatenated words)");

                // Content validation (at least 4 words concatenated)
                Assert.That(result.Length, Is.GreaterThanOrEqualTo(4), 
                    "Name should combine multiple words");
            });
        }

        [Test]
        public void GenerateName_EdgeCases()
        {
            Assert.Multiple(() =>
            {
                // Test min boundary
                var minResult = GenerateName(faker, 5, 5);
                Assert.That(minResult.Length, Is.EqualTo(5));

                // Test max boundary
                var maxResult = GenerateName(faker, 30, 30);
                Assert.That(maxResult.Length, Is.EqualTo(30));
                
                // Test negatives
                Assert.That(() => GenerateName(faker, -10, -5),
                    Throws.TypeOf<ArgumentOutOfRangeException>());
            });
        }
    }
    
    public class PostcodeGeneratorTests
    {
        [Test]
        public void GeneratePostcode_ShouldReturnValidPostcode()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var postcode = GeneratePostcode(faker);

            // Assert
            Assert.That(postcode, Is.Not.Null.And.Not.Empty, "Postcode should not be null or empty");
            Assert.That(postcode.Length, Is.EqualTo(6), "Postcode should be exactly 6 characters long");
            Assert.That(postcode.Substring(0, 4), Is.All.InRange('0', '9'), "First 4 characters should be digits");
            Assert.That(postcode.Substring(4, 2), Does.Match(@"^[A-Z]{2}$"), "Last 2 characters should be uppercase letters");
        }
    }

    public class GedragscompetentieGeneratorTests
    {
        [Test]
        public void GenerateGedragscompetentie_ShouldReturnValidGedragscompetenties()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateGedragscompetentie(faker);

            // Assert
            Assert.That(result, Is.Not.Null.And.Not.Empty, "Result list should not be null or empty");
            Assert.That(result.Count, Is.InRange(1, 2), "Result should contain between 1 and 2 items");

            foreach (var gc in result)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(gc, Is.Not.Null, "Gedragscompetentie instance should not be null");

                    // If fields were set, check their validity
                    if (gc.CodeGedragscompetentie != null)
                    {
                        Assert.That(gc.CodeGedragscompetentie, Is.AnyOf(
                            "24100", "24101", "24102", "24104", "24105", "24106", "24107", "24108", "24109", "24110",
                            "24111", "24112", "24113", "24114", "24115", "24116", "24118", "24119", "24120", "24121",
                            "24122", "24123", "24124", "24125", "24126"
                        ), "CodeGedragscompetentie should be one of the allowed codes");
                    }

                    if (gc.CodeBeheersingGedragscompetentie != 0)
                    {
                        Assert.That(gc.CodeBeheersingGedragscompetentie, Is.AnyOf(1, 2, 3, 4, 5, 9),
                            "CodeBeheersing should be one of the allowed values");
                    }

                    if (gc.OmschrijvingGedragscompetentie != null)
                    {
                        Assert.That(gc.OmschrijvingGedragscompetentie, Is.AnyOf(
                            "Beslissen en activiteiten initiëren", "Aansturen Begeleiden", "Aandacht en begrip tonen",
                            "Samenwerken en overleggen", "Ethisch en integer handelen", "Relaties bouwen en netwerken",
                            "Overtuigen en beïnvloeden", "Presenteren", "Formuleren en rapporteren",
                            "Vakdeskundigheid toepassen", "Materialen en middelen inzetten", "Analyseren",
                            "Onderzoeken",
                            "Creëren en innoveren", "Leren", "Plannen en organiseren",
                            "Op de behoeften en verwachtingen van de klant richten", "Kwaliteit leveren",
                            "Instructies en procedures opvolgen", "Omgaan met verandering en aanpassen",
                            "Met druk en tegenslag omgaan", "Gedrevenheid en ambitie tonen",
                            "Ondernemend en commercieel handelen", "Bedrijfsmatig handelen"
                        ), "OmschrijvingGedragscompetentie should be one of the allowed descriptions");
                    }
                });
            }
        }
    }

    public class BeroepsnaamGeneratorTests
    {
        [Test]
        public void GenerateBeroepsnaamGecodeerd_ShouldReturnValidBeroepsnaam()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateBeroepsnaamGecodeerd(faker);

            // Assert
            Assert.That(result, Is.Not.Null, "Beroepsnaam should not be null");

            Assert.Multiple(() =>
            {
                Assert.That(result.BeroepsnaamGecodeerd, Is.Not.Null, "BeroepsnaamGecodeerd should not be null");
                Assert.That(result.BeroepsnaamGecodeerd?.CodeBeroepsnaam, Is.Not.Null.And.Not.Empty, "CodeBeroepsnaam should not be null or empty");
                Assert.That(result.BeroepsnaamGecodeerd?.OmschrijvingBeroepsnaam, Is.Not.Null.And.Not.Empty, "OmschrijvingBeroepsnaam should not be null or empty");
            });
        }
        
        [Test]
        public void GenerateBeroepsnaamOngecodeerd_ShouldReturnValidBeroepsnaam()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateBeroepsnaamOngecodeerd(faker);

            // Assert
            Assert.That(result, Is.Not.Null, "Result should not be null");

            Assert.Multiple(() =>
            {
                Assert.That(result.BeroepsnaamOngecodeerd, Is.Not.Null, "BeroepsnaamOngecodeerd should not be null");
                Assert.That(result.BeroepsnaamOngecodeerd?.NaamBeroepOngecodeerd, Is.Not.Null.And.Not.Empty, "NaamBeroepOngecodeerd should not be null or empty");
            });
        }        
    }    
    
    public class FlexibiliteitGeneratorTests
    {
        [Test]
        public void GenerateFlexibiliteit_ShouldReturnValidFlexibiliteit()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateFlexibiliteit(faker);

            // Assert
            Assert.That(result, Is.Not.Null, "Result should not be null");

            Assert.Multiple(() =>
            {
                Assert.That(result.CodeRegiostraal, Is.InRange(1, 9), "CodeRegiostraal should be between 1 and 9");
                Assert.That(result.DatumAanvangBeschikbaarVoorWerk, Is.InstanceOf<string>(), "DatumAanvangBeschikbaarVoorWerk should be a valid string");
                Assert.That(result.DatumEindeBeschikbaarVoorWerk, Is.InstanceOf<string>(), "DatumEindeBeschikbaarVoorWerk should be a valid string");
                Assert.That(result.IndicatieOnregelmatigWerkOfPloegendienst, Is.InRange(0, 2), "IndicatieOnregelmatigWerkOfPloegendienst should be 0, 1, or 2");
            });
        }
    }
    
    public class SectorGeneratorTests
    {
        [Test]
        public void GenerateSector_ShouldReturnValidSectorList()
        {
            // Arrange
            var faker = new Faker("nl");
            int maxItems = 3;

            // Act
            var result = GenerateSector(faker, maxItems);

            // Assert
            Assert.That(result, Is.Not.Null, "Result should not be null");
            Assert.That(result.Count, Is.InRange(1, maxItems), $"Result list should have between 1 and {maxItems} items");

            Assert.Multiple(() =>
            {
                foreach (var sector in result)
                {
                    Assert.That(sector, Is.Not.Null, "Sector should not be null");
                    Assert.That(sector, Is.InstanceOf<SectorBeroepsEnBedrijfsleven>(), "Each item in the list should be an instance of SectorBeroepsEnBedrijfsleven");
                }
            });
        }
        
        [Test]
        public void GenerateSector_ShouldReturnValidSector()
        {
            // Arrange
            var faker = new Faker("nl");

            // Act
            var result = GenerateSector(faker);

            // Assert
            Assert.That(result, Is.Not.Null, "Result should not be null");

            Assert.Multiple(() =>
            {
                Assert.That(result.CodeSbi, Is.Not.Null, "CodeSbi should not be null");
                Assert.That(SbiCodes, Does.Contain(result.CodeSbi), "CodeSbi should be a valid value from SbiCodes");
            });
        }        
    }
    
    public class VervoermiddelGeneratorTests
    {
        [Test]
        public void GenerateVervoermiddel_ShouldReturnValidList()
        {
            // Arrange
            var faker = new Faker("nl");
            var validCodeVervoermiddel = new List<int> { 1, 2, 3, 4, 5, 9 };
            var validIndicatie = new List<int> { 0, 1, 2 };

            // Act
            var result = GenerateVervoermiddel(faker);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null, "Result list should not be null");
                Assert.That(result.Count, Is.InRange(1, 2), "Result list should contain 1 or 2 items");

                foreach (var vervoermiddel in result)
                {
                    Assert.That(vervoermiddel, Is.Not.Null, "Vervoermiddel item should not be null");
                    Assert.That(validCodeVervoermiddel, Does.Contain(vervoermiddel.CodeVervoermiddel), "CodeVervoermiddel should be valid");
                    Assert.That(validIndicatie, Does.Contain(vervoermiddel.IndicatieBeschikbaarVoorUitvoeringWerk), "IndicatieBeschikbaarVoorUitvoeringWerk should be valid");
                    Assert.That(validIndicatie, Does.Contain(vervoermiddel.IndicatieBeschikbaarVoorWoonWerkverkeer), "IndicatieBeschikbaarVoorWoonWerkverkeer should be valid");
                }
            });
        }
    }

    public class WebadresGeneratorTests
    {
        [Test]
        public void GenerateWebadres_ShouldReturnValidList()
        {
            // Arrange
            var faker = new Faker("nl");
            int maxItems = 3;

            // Act
            var result = GenerateWebadres(faker, maxItems);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null, "Result should not be null");
                Assert.That(result.Count, Is.InRange(1, maxItems), $"Result list should have between 1 and {maxItems} items");

                foreach (var webadres in result)
                {
                    Assert.That(webadres, Is.Not.Null, "Webadres item should not be null");
                    Assert.That(webadres.Url, Is.Not.Null.And.Not.Empty, "Webadres.Url should not be null or empty");
                    Assert.That(webadres.Url, Does.StartWith("http").Or.StartWith("https"), "Webadres.Url should start with http or https");
                }
            });
        }
    }
    
    public class WerktijdenGeneratorTests
    {
        [Test]
        public void GenerateWerktijden_ShouldReturnValidWerktijden()
        {
            // Arrange
            var faker = new Faker();

            // Act
            var result = GenerateWerktijden(faker);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null, "Result should not be null");
                Assert.That(result.AantalWerkurenPerWeekMinimaal, Is.InRange(1, 99), "AantalWerkurenPerWeekMinimaal should be between 1 and 99");
                Assert.That(result.AantalWerkurenPerWeekMaximaal, Is.InRange(1, 99), "AantalWerkurenPerWeekMaximaal should be between 1 and 99");
                Assert.That(result.IndicatieKantoortijden, Is.InRange(0, 2), "IndicatieKantoortijden should be 0, 1, or 2");
            });
        }
    }    
}