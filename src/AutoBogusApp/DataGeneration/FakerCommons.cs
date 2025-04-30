using Bogus;
using AutoBogusApp.Vum;

namespace AutoBogusApp.DataGeneration;

public class FakerCommons
{
    public const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static readonly string[] OpleidingCodes = [
        "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120"
    ];
    public static readonly int[] NiveauOpleidingCodes = [ 1, 2, 3, 4, 5, 6, 9 ];
    public static readonly int[] IndicatieDiploma = [ 0, 1, 2, 8 ];

    private static readonly int[] SbiCodes = [
        101, 102, 103, 104, 105, 106, 107, 2013, 2014, 2015, 2016, 2017, 2020, 2030, 47762, 47763, 47781, 47782, 47783, 47789
    ];
    private const string Format = "yyyy-MM-dd";
    private const int DateMin = -100;
    private const int DateMax = 100;
    private static readonly string[] BeroepCodes = [
        "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "124", "125", "129", "134", "138", "140", "141"
    ];
    private static readonly string[] TaalCodes = [
        "ara", "ces", "deu", "eng", "fra", "kur", "mal", "nep", "nld", "nor", "por", "ron", "som", "spa", "srp", "swe", "tuk", "tur", "ukr", "zul"
    ];
    
    public static string GenerateDate(Faker f)
    {
        return f.Date.Between(DateTime.Now.AddYears(DateMin), DateTime.Now.AddYears(DateMax)).ToString(Format);
    }

    public static List<string> GenerateEmailAdresList(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var emailadresList = new List<string>();
        for (int i = 0; i < length; i++)
        {
            emailadresList.Add(f.Internet.Email());
        }

        return emailadresList;
    }
    
    public static List<string> GenerateTelefoonnummer(Faker f, int maxItems = 1)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var telefoonnummerList = new List<string>();
        for (int i = 0; i < length; i++)
        {
            telefoonnummerList.Add(f.Phone.PhoneNumber());
        }

        return telefoonnummerList;
    }    
    
    public static string GenerateCode(Faker faker, int minLength, int maxLength)
    {
        var length = faker.Random.Int(minLength, maxLength);
        return faker.Random.String2(length);
    }  
    
    public static string GenerateName(Faker faker, int minLength, int maxLength)
    {
        var randomLength = faker.Random.Int(minLength, maxLength);
        
        // Generate the name once
        string name = string.Concat(faker.Lorem.Words(int.Abs(maxLength/3)+1)).ToLower();
        name = char.ToUpper(name[0]) + name[1..];
        if (name.Length < randomLength)
        {
            randomLength = name.Length;
        }
        name = name.Substring(0, randomLength);

        return name;
    }

    public static string GeneratePostcode(Faker f)
    {
        var digits = f.Random.Number(1000, 9999);
        var letters = $"{f.Random.Char('A', 'Z')}{f.Random.Char('A', 'Z')}";

        return $"{digits}{letters}";
    }

    public static List<Gedragscompetentie> GenerateGedragscompetentie(Faker f, int maxItems)
    {
        var codeGedragscompetenties = new[]
        {
            "24100", "24101", "24102", "24104", "24105", "24106", "24107", "24108", "24109", "24110", "24111", "24112",
            "24113", "24114", "24115", "24116", "24118", "24119", "24120", "24121", "24122", "24123", "24124", "24125",
            "24126"
        };
        var codeBeheersingGedragscompetentie = new List<int> { 1, 2, 3, 4, 5, 9 };
        var omschrijvingGedragscompetentie = new[]
        {
            "Beslissen en activiteiten initiëren", "Aansturen Begeleiden", "Aandacht en begrip tonen",
            "Samenwerken en overleggen", "Ethisch en integer handelen", "Relaties bouwen en netwerken",
            "Overtuigen en beïnvloeden", "Presenteren", "Formuleren en rapporteren", "Vakdeskundigheid toepassen",
            "Materialen en middelen inzetten", "Analyseren", "Onderzoeken", "Creëren en innoveren", "Leren",
            "Plannen en organiseren", "Op de behoeften en verwachtingen van de klant richten", "Kwaliteit leveren",
            "Instructies en procedures opvolgen", "Omgaan met verandering en aanpassen", "Met druk en tegenslag omgaan",
            "Gedrevenheid en ambitie tonen", "Ondernemend en commercieel handelen", "Bedrijfsmatig handelen"
        };

        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<Gedragscompetentie>();
        for (int i = 0; i < length; i++)
        {
            var gedragscompetentie = new Gedragscompetentie()
            {
                CodeGedragscompetentie = f.Random.ArrayElement(codeGedragscompetenties),
                CodeBeheersingGedragscompetentie = f.Random.ListItem(codeBeheersingGedragscompetentie),
                OmschrijvingGedragscompetentie = f.Random.ArrayElement(omschrijvingGedragscompetentie)
            };
            result.Add(gedragscompetentie);
        }
        
        return result;
    }

    public static List<Rijbewijs> GenerateRijbewijs(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var rijbewijsList = new List<Rijbewijs>();
        for (int i = 0; i < length; i++)
        {
            rijbewijsList.Add(GenerateRijbewijs(f));
        }

        return rijbewijsList;
    }

    private static Rijbewijs GenerateRijbewijs(Faker f)
    {
        var rijbewijsCodes = new List<string> { "A", "A1", "A2", "AM", "B", "B+", "C1", "C", "D1", "D", "BE", "C1E", "CE", "D1E", "DE", "T" };
        return new Rijbewijs()
        {
            CodeSoortRijbewijs = f.PickRandom(rijbewijsCodes)
        };
    }
    
    public static List<Taalbeheersing> GenerateTaalbeheersing(Faker f, int maxItems)
    {
        var taalbeheersingNiveaus = new List<int>{ 0, 1, 2, 3, 4, 8 };
        var codeNiveauTaalbeheersingLezen = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingLuisteren = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingMondeling = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingSchriftelijk = taalbeheersingNiveaus;

        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<Taalbeheersing>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new Taalbeheersing()
            {
                CodeNiveauTaalbeheersingLezen = f.Random.ListItem(codeNiveauTaalbeheersingLezen),
                CodeNiveauTaalbeheersingLuisteren = f.Random.ListItem(codeNiveauTaalbeheersingLuisteren),
                CodeNiveauTaalbeheersingMondeling = f.Random.ListItem(codeNiveauTaalbeheersingMondeling),
                CodeNiveauTaalbeheersingSchriftelijk = f.Random.ListItem(codeNiveauTaalbeheersingSchriftelijk),
                CodeTaal = string.Join(", ", 
                    TaalCodes.OrderBy(x => f.Random.Int())
                        .Take(f.Random.Int(1, Math.Min(3, TaalCodes.Length))))
            });
        }

        return result;
    }
    
    public static List<Vakvaardigheid> GenerateVakvaardigheid(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<Vakvaardigheid>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new Vakvaardigheid()
            {
                Omschrijving = f.Lorem.Sentence(15, 120)
            });
        }

        return result;
    }
    
    public static Beroepsnaam GenerateBeroepsnaamGecodeerd(Faker f)
    {
        return new Beroepsnaam
        {
            BeroepsnaamGecodeerd = new BeroepsnaamGecodeerd
            {
                CodeBeroepsnaam = f.PickRandom(BeroepCodes),
                OmschrijvingBeroepsnaam = f.Name.JobTitle()
            }
        };
    }

    public static Beroepsnaam GenerateBeroepsnaamOngecodeerd(Faker f)
    {
        return new Beroepsnaam
        {
            BeroepsnaamOngecodeerd = new BeroepsnaamOngecodeerd()
            {
                NaamBeroepOngecodeerd = f.Name.JobTitle()
            }
        };
    }
    
    public static List<Contractvorm> GenerateContractvorm(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var contractvormList = new List<Contractvorm>();
        for (int i = 0; i < length; i++)
        {
            contractvormList.Add(GenerateContractvorm(f));
        }

        return contractvormList;
    }

    private static Contractvorm GenerateContractvorm(Faker f)
    {
        var codeTypeArbeidscontractOptions = new List<string> { "O", "B" };
        var codeTypeOvereenkomstOptions = new List<string> { "O1", "02", "03", "04" };

        return new Contractvorm()
        {
            CodeTypeArbeidscontract = f.PickRandom(codeTypeArbeidscontractOptions),
            CodeTypeOvereenkomst = f.PickRandom(codeTypeOvereenkomstOptions)
        };
    }

    public static Flexibiliteit GenerateFlexibiliteit(Faker f)
    {
        var flexibiliteit = new Flexibiliteit();

        // Always set all properties individually
        flexibiliteit.CodeRegiostraal = f.Random.Int(1, 9);
        flexibiliteit.DatumAanvangBeschikbaarVoorWerk = GenerateDate(f);
        flexibiliteit.DatumEindeBeschikbaarVoorWerk = GenerateDate(f);
        flexibiliteit.IndicatieOnregelmatigWerkOfPloegendienst = f.Random.Int(0, 2);

        return flexibiliteit;
    }

    public static List<SectorBeroepsEnBedrijfsleven> GenerateSector(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var sectorList = new List<SectorBeroepsEnBedrijfsleven>();
        for (int i = 0; i < length; i++)
        {
            sectorList.Add(GenerateSector(f));
        }

        return sectorList;
    }    
    
    public static SectorBeroepsEnBedrijfsleven GenerateSector(Faker f)
    {
        return new SectorBeroepsEnBedrijfsleven()
        {
            CodeSbi = f.PickRandom(SbiCodes)
        };
    }
    
    public static List<Vervoermiddel> GenerateVervoermiddel(Faker f, int maxItems)
    {
        var codeVervoermiddel = new List<int> { 1, 2, 3, 4, 5, 9 };
        var indicatieBeschikbaarVoorUitvoeringWerk = new List<int> { 0, 1, 2 };
        var indicatieBeschikbaarVoorWoonWerkverkeer = new List<int> { 0, 1, 2 };
        
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<Vervoermiddel>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new Vervoermiddel()
            {
                CodeVervoermiddel = f.Random.ListItem(codeVervoermiddel),
                IndicatieBeschikbaarVoorUitvoeringWerk = f.Random.ListItem(indicatieBeschikbaarVoorUitvoeringWerk),
                IndicatieBeschikbaarVoorWoonWerkverkeer = f.Random.ListItem(indicatieBeschikbaarVoorWoonWerkverkeer),
            });
        }

        return result;
    }

    public static List<Webadres> GenerateWebadres(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var webadresList = new List<Webadres>();
        for (int i = 0; i < length; i++)
        {
            webadresList.Add(GenerateWebadres(f));
        }

        return webadresList;
    }
    
    public static Webadres GenerateWebadres(Faker f)
    {
        var webadres = new Webadres()
        {
            CodeWebadres = f.PickRandom(1, 2, 3, 4),
            Url = f.Internet.UrlWithPath()
        };

        return webadres;
    }
    
    public static Werktijden GenerateWerktijden(Faker f)
    {
        var werktijden = new Werktijden()
        {
            AantalWerkurenPerWeekMinimaal = f.Random.Int(1, 99),
            AantalWerkurenPerWeekMaximaal = f.Random.Int(1, 99),
            IndicatieKantoortijden = f.PickRandom(0, 1, 2)
        };

        return werktijden;
    }    
}