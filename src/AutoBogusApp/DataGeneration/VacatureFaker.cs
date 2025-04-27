using AutoBogusApp.Vum;
using Bogus;
using static AutoBogusApp.DataGeneration.CommonFaker;

namespace AutoBogusApp.DataGeneration;

public class VacatureFaker
{
    private const float ShowWeight = 1.0f;
    private const string DateFormat = "yyyy-MM-dd";
        
    public Vacature FakeVacature()
    {
        var faker = new Faker<Vacature>("nl")
            .RuleFor(v => v.ArbeidsVoorwaarden, GenerateArbeidsVoorwaarden)
            .RuleFor(v => v.Beroep, f => f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f))
            .RuleFor(v => v.CodeWerkEnDenkniveauMinimaal, f => f.Random.Bool(ShowWeight) ? f.Random.Int(0, 7).ToString() : null)
            .RuleFor(v => v.Contractvorm, GenerateContractvorm)
            .RuleFor(v => v.Cursus, GenerateCursus)
            .RuleFor(v => v.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(v => v.IdVacature, f => f.Random.Bool(ShowWeight) ? f.Random.Uuid().ToString() : null)
            .RuleFor(v => v.Gedragscompetentie, GenerateGedragscompetentie)
            .RuleFor(v => v.NaamVacature, f => f.Random.Bool(ShowWeight) ? GenerateName(f, 3, 120) : null)
            .RuleFor(v => v.NummerVacature, f => f.Random.Bool(ShowWeight) ? f.Random.Int(1000, 9999).ToString() : null)
            .RuleFor(v => v.OmschrijvingVacature, f => f.Random.Bool(ShowWeight) ? f.Lorem.Sentence() : null)
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Opleiding, GenerateOpleiding)
            .RuleFor(v => v.Rijbewijs, GenerateRijbewijs)
            .RuleFor(v => v.Sector, GenerateSector)
            .RuleFor(v => v.SluitingsdatumVacature, GenerateDate)
            .RuleFor(v => v.Sollicitatiewijze, GenerateSollicitatiewijze)
            .RuleFor(v => v.Taalbeheersing, GenerateTaalbeheersing)
            .RuleFor(v => v.Vakvaardigheid, GenerateVakvaardigheid)
            .RuleFor(v => v.Vervoermiddel, GenerateVervoermiddel)
            .RuleFor(v => v.Werkervaring, GenerateWerkervaring)
            .RuleFor(v => v.Werkgever, GenerateWerkgever)
            .RuleFor(v => v.Werktijden, GenerateWerktijden);
            
        return faker.Generate();
    }

    public MPVacatureMatch FakeMpVacatureMatch()
    {
        var faker = new Faker<MPVacatureMatch>("nl")
            .RuleFor(v => v.ArbeidsVoorwaarden, GenerateArbeidsVoorwaarden)
            .RuleFor(v => v.Beroep, f => f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f))
            .RuleFor(v => v.CodeWerkEnDenkniveauMinimaal, f => f.Random.Bool(ShowWeight) ? f.Random.Int(0, 7).ToString() : null)
            .RuleFor(v => v.Contractvorm, GenerateContractvorm)
            .RuleFor(v => v.Cursus, GenerateCursus)
            .RuleFor(v => v.Mobiliteit, GenerateMobiliteit)
            .RuleFor(v => v.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(v => v.IdVacature, f => f.Random.Bool(ShowWeight) ? f.Random.Uuid().ToString() : null)
            .RuleFor(v => v.Gedragscompetentie, GenerateGedragscompetentie)
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Opleiding, GenerateMpOpleiding)
            .RuleFor(v => v.Rijbewijs, GenerateRijbewijs)
            .RuleFor(v => v.Sector, GenerateSector)
            .RuleFor(v => v.SluitingsdatumVacature, GenerateDate)
            .RuleFor(v => v.Sollicitatiewijze, GenerateSollicitatiewijze)
            .RuleFor(v => v.Taalbeheersing, GenerateTaalbeheersing)
            .RuleFor(v => v.Vakvaardigheid, GenerateVakvaardigheid)
            .RuleFor(v => v.Vervoermiddel, GenerateVervoermiddel)
            .RuleFor(v => v.Werkervaring, GenerateWerkervaring)
            .RuleFor(v => v.Werkgever, GenerateWerkgever)
            .RuleFor(v => v.Werktijden, GenerateWerktijden);
            
        return faker.Generate();
    }    
    
    private static ArbeidsVoorwaarden GenerateArbeidsVoorwaarden(Faker f)
    {
        return new ArbeidsVoorwaarden
        {
            DatumAanvangWerkzaamheden =  f.Random.Bool(ShowWeight) ? GenerateDate(f) : null,
            DatumEindeWerkzaamheden = f.Random.Bool(ShowWeight) ? GenerateDate(f) : null,
            OmschrijvingArbeidsvoorwaarden = f.Random.Bool(ShowWeight) ? f.Lorem.Sentence() : null,
            SalarisIndicatie = f.Random.Bool(ShowWeight) ? f.Finance.Amount(1000, 10000, 0).ToString("F0") : null,
        };
    }

    private static List<Contractvorm> GenerateContractvorm(Faker f)
    {
        string[] codeTypeArbeidscontractOptions = { "O", "B" };
        string[] codeTypeOvereenkomstOptions = { "O1", "02", "03", "04" };
        var properties = new List<Action<Contractvorm>>
        {
            c => c.CodeTypeArbeidscontract = f.Random.ArrayElement(codeTypeArbeidscontractOptions),
            c => c.CodeTypeOvereenkomst = f.Random.ArrayElement(codeTypeOvereenkomstOptions)
        };

        var results = new List<Contractvorm>();

        // Determine how many properties to enable (1 to all)
        int count = f.Random.Int(1, properties.Count);

        // Shuffle and take a random selection
        foreach (var contractvorm  in f.Random.Shuffle(properties).Take(count))
        {
            var contract = new Contractvorm();
            contractvorm(contract);
            results.Add(contract);
        }

        return results;
    }

    private static List<CursusVacature> GenerateCursus(Faker f)
    {
        var cursusFaker = new Bogus.Faker<CursusVacature>()
            .RuleFor(c => c.NaamCursus, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Department()}");

        var result = new List<CursusVacature>();

        // Generate random instances with unique seeds
        for (int i = 0; i < new Random().Next(1, 5); i++)
        {
            Bogus.Randomizer.Seed = new Random(i * DateTime.Now.Millisecond);
            result.Add(cursusFaker.Generate());
        }
        
        return result;
    }

    private static Opleidingsnaam GenerateOpleidingsnaamGecodeerd(Faker f)
    {
        return new Opleidingsnaam
        {
            OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd
            {
                CodeOpleidingsnaam = f.PickRandom(OpleidingCodes),
                OmschrijvingOpleidingsnaam = f.Lorem.Sentence(), 
            }

        };
    }

    private static MPOpleidingsnaam GenerateMpOpleidingsnaamGecodeerd(Faker f)
    {
        return new MPOpleidingsnaam
        {
            OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd
            {
                CodeOpleidingsnaam = f.PickRandom(OpleidingCodes),
                OmschrijvingOpleidingsnaam = f.Lorem.Sentence(), 
            }

        };
    }    
    
    private static Opleidingsnaam GenerateOpleidingsnaamOngecodeerd(Faker f)
    {
        return new Opleidingsnaam
        {
            OpleidingsnaamOngecodeerd = new OpleidingsnaamOngecodeerd
            {
                NaamOpleidingOngecodeerd = f.Random.Word().ToLower()
            }
        };
    }
    
    private static MPOpleidingsnaam GenerateMpOpleidingsnaamOngecodeerd(Faker f)
    {
        return new MPOpleidingsnaam
        {
            OpleidingsnaamOngecodeerd = new MPOpleidingsnaamOngecodeerd
            {
                NaamOpleidingOngecodeerd = f.Random.Word().ToLower()
            }
        };
    }    
    
    private static List<OpleidingVacature> GenerateOpleiding(Faker f)
    {
        var properties = new List<Action<OpleidingVacature>>
        {
            c => c.CodeNiveauOpleiding = f.Random.ListItem(NiveauOpleidingCodes),
            c => c.IndicatieDiploma = f.Random.ListItem(IndicatieDiploma),
            c => c.Opleidingsnaam = f.Random.Bool()
                ? GenerateOpleidingsnaamGecodeerd(f)
                : GenerateOpleidingsnaamOngecodeerd(f)
        };
        
        var result = new List<OpleidingVacature>();
        int count = f.Random.Int(1, properties.Count);

        // Generate random instances with unique seeds
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            var opleidingVacature = new OpleidingVacature();
            foreach (var opleiding  in f.Random.Shuffle(properties).Take(count))
            {
                opleiding(opleidingVacature);
            }
            result.Add(opleidingVacature);
        }

        return result;        
    }
    
    private static List<MPOpleidingVacature> GenerateMpOpleiding(Faker f)
    {
        var codeNiveauOpleiding = new List<int> { 1, 2, 3, 4, 5, 9 };
        var properties = new List<Action<MPOpleidingVacature>>
        {
            c => c.CodeNiveauOpleiding = f.Random.ListItem(codeNiveauOpleiding),
            c => c.IndicatieDiploma = f.Random.ListItem(IndicatieDiploma),
            c => c.Opleidingsnaam = f.Random.Bool()
                ? GenerateMpOpleidingsnaamGecodeerd(f)
                : GenerateMpOpleidingsnaamOngecodeerd(f)
        };
        
        var result = new List<MPOpleidingVacature>();
        int count = f.Random.Int(1, properties.Count);

        // Generate random instances with unique seeds
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            var mpOpleidingVacature = new MPOpleidingVacature();
            foreach (var opleiding  in f.Random.Shuffle(properties).Take(count))
            {
                opleiding(mpOpleidingVacature);
            }
            result.Add(mpOpleidingVacature);
        }

        return result;        
    }    

    private static List<Rijbewijs> GenerateRijbewijs(Faker f)
    {
        var rijbewijsCodes = new List<string> { "A", "A1", "A2", "AM", "B", "B+", "C1", "C", "D1", "D", "BE", "C1E", "CE", "D1E", "DE", "T" };    
        var rijbewijsFaker = new Faker<Rijbewijs>()
            .RuleFor(r => r.CodeSoortRijbewijs, f.Random.ListItem(rijbewijsCodes));
        
        return rijbewijsFaker.Generate(f.Random.Int(1, 5));
    }

    private static List<Sollicitatiewijze> GenerateSollicitatiewijze(Faker f)
    {
        var codeSollicitatiewijze = new List<string>{ "1", "2", "3", "4" };
        var result = new List<Sollicitatiewijze>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new Sollicitatiewijze()
            {
                CodeSollicitatiewijze = f.Random.ListItem(codeSollicitatiewijze)
            });
        }

        return result;
    }
    
    private static List<Taalbeheersing> GenerateTaalbeheersing(Faker f)
    {
        var taalbeheersingNiveaus = new List<int>{ 0, 1, 2, 3, 4, 8 };
        var codeNiveauTaalbeheersingLezen = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingLuisteren = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingMondeling = taalbeheersingNiveaus;
        var codeNiveauTaalbeheersingSchriftelijk = taalbeheersingNiveaus;

        var result = new List<Taalbeheersing>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
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
    
    private static List<Vakvaardigheid> GenerateVakvaardigheid(Faker f)
    {
        var result = new List<Vakvaardigheid>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new Vakvaardigheid()
            {
                Omschrijving = f.Lorem.Sentence(5, 10)
            });
        }

        return result;
    }
    
    private static List<WerkervaringVacature> GenerateWerkervaring(Faker f)
    {
        var result = new List<WerkervaringVacature>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new WerkervaringVacature()
            {
                AantalJarenWerkzaamInBeroep = f.Random.Int(0, 100)
            });
        }

        return result;
    }

    private static Werkgever GenerateWerkgever(Faker f)
    {
        var werkgever = new Werkgever()
        {
            AdresHouding = GenerateAdresHouding(f),
            Contactpersoon = GenerateContactPersoon(f, 3),
            HandelsnaamOrganisatie = GenerateName(f, 3, 500),
            Sector = GenerateSector(f, 3),
            Webadres = GenerateWebadres(f, 3) 
        };

        return werkgever;        

    }
    
    private static List<AdresHouding> GenerateAdresHouding(Faker f)
    {
        var codeFunctieAdres = new List<string> { "B", "W", "C", "L", "A", "V", "E" };
        var adresHouding = new List<AdresHouding>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            adresHouding.Add(new AdresHouding()
            {
                Adres = GenerateAdres(f),
                CodeFunctieAdres = f.PickRandom(codeFunctieAdres),
                DatumAanvangAdres = GenerateDate(f),
                DatumEindeAdres = GenerateDate(f)
            });
        }

        return adresHouding;        

    }

    private static AdresHoudingAdres GenerateAdres(Faker f)
    {
        var adres = new AdresHoudingAdres()
        {
            AdresNederland = GenerateAdresNederland(f),
            AdresBuitenland = GenerateAdresBuitenland(f)
        };

        return adres;
    }

    private static AdresNederland GenerateAdresNederland(Faker f)
    {
        var adresNederland = new AdresNederland()
        {
            AdresDetails = GenerateAdresDetails(f),
            CodeGemeente = GenerateCode(f, 1, 4),
            District = GenerateName(f, 3, 24),
            Gemeentedeel = GenerateName(f, 3, 24),
            Gemeentenaam = f.Address.City(),
            IdentificatiecodeNummeraanduiding = GenerateCode(f, 1, 16),
            IdentificatiecodeVerblijfplaats = GenerateCode(f, 1, 16),
            Locatieomschrijving = f.Lorem.Sentence(),
            Postcode = GeneratePostcode(f),
            Woonplaatsnaam = f.Address.City()
        };

        return adresNederland;
    }

    private static AdresNederlandAdresDetails GenerateAdresDetails(Faker f)
    {
        var adresDetails = new AdresNederlandAdresDetails()
        {
            Straatadres = GenerateStraatsdres(f),
            Postbusadres = GeneratePostbusadres(f),
            Antwoordnummeradres = GenerateAntwoordnummeradres(f)
        };

        return adresDetails;
    }

    private static Straatadres GenerateStraatsdres(Faker f)
    {
        var straatadres = new Straatadres()
        {
            AanduidingBijHuisnummer = f.Random.String2(1, UpperCase),
            Huisletter = f.Random.String2(1, UpperCase),
            Huisnummer = f.PickRandom(1, 1000),
            Huisnummertoevoeging = f.Random.String2(1, UpperCase),
            NaamOpenbareRuimte = GenerateName(f, 3, 80),
            Straatnaam = GenerateName(f, 3, 24),
            Woonbootverwijzing = "AB",
            Woonwagenverwijzing = "WW"
        };

        return straatadres;
    }

    private static Postbusadres GeneratePostbusadres(Faker f)
    {
        return new Postbusadres()
        {
            Postbusnummer = f.PickRandom(1000, 10000)
        };
    }

    private static Antwoordnummeradres GenerateAntwoordnummeradres(Faker f)
    {
        return new Antwoordnummeradres()
        {
            Antwoordnummer = f.PickRandom(1000, 10000)
        };
    }

    private static List<ContactpersoonAfdeling> GenerateContactPersoon(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var contactpersoonList = new List<ContactpersoonAfdeling>();
        for (int i = 0; i < length; i++)
        {
            contactpersoonList.Add(GenerateContactpersoon(f));
        }

        return contactpersoonList;
    }

    private static ContactpersoonAfdeling GenerateContactpersoon(Faker f)
    {
        var contactpersoon = new ContactpersoonAfdeling()
        {
            Emailadres = GenerateEmailAdresList(f, 3),
            NaamContactpersoonAfdeling = f.Name.LastName(),
            Telefoonnummer = GenerateTelefoonnummer(f, 3)
        };

        return contactpersoon;
    }

    private static AdresBuitenland GenerateAdresBuitenland(Faker f)
    {
        var adresBuitenland = new AdresBuitenland()
        {
            AdresDetailsBuitenland = GenerateAdresDetailsBuitenland(f),
        };

        return adresBuitenland;
    }
    
    private static AdresBuitenlandAdresDetailsBuitenland GenerateAdresDetailsBuitenland(Faker f)
    {
        var adresDetailsBuitenland = new AdresBuitenlandAdresDetailsBuitenland()
        {
            StraatadresBuitenland = GenerateStraatAdresBuitenland(f),
            PostbusadresBuitenland = GeneratePostbusadresBuitenland(f)
        };

        return adresDetailsBuitenland;
    }

    private static StraatadresBuitenland GenerateStraatAdresBuitenland(Faker f)
    {
        var straatadresBuitenland = new StraatadresBuitenland()
        {
            HuisnummerBuitenland = f.Random.String2(1, 9),
            StraatnaamBuitenland = GenerateName(f, 3, 24) 
        };

        return straatadresBuitenland;
    }

    private static PostbusadresBuitenland GeneratePostbusadresBuitenland(Faker f)
    {
        var postbusadresBuitenland = new PostbusadresBuitenland()
        {
            PostbusnummerBuitenland = f.Random.String2(1, 9)
        };

        return postbusadresBuitenland;
    }
    
    private static MobiliteitVacature GenerateMobiliteit(Faker f)
    {
        return new MobiliteitVacature()
        {
            Bemiddelingspostcode = GeneratePostcode(f),
            MaximaleReisafstand = f.Random.Int(min: 0, max: 999),
        };
    }
    
}
