using AutoBogusApp.Vum;
using Bogus;
using static AutoBogusApp.DataGeneration.FakerCommons;

namespace AutoBogusApp.DataGeneration;

public class VacatureFaker
{
    private const string DateFormat = "yyyy-MM-dd";
        
    public MPVacatureMatch FakeMpVacatureMatch()
    {
        var faker = new Faker<MPVacatureMatch>("nl")
            .RuleFor(v => v.ArbeidsVoorwaarden, GenerateArbeidsVoorwaarden)
            .RuleFor(v => v.Beroep, f => f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f))
            .RuleFor(v => v.CodeWerkEnDenkniveauMinimaal, f => f.Random.Int(0, 7).ToString())
            .RuleFor(v => v.Contractvorm, f => GenerateContractvorm(f, 3))
            .RuleFor(v => v.Cursus, GenerateCursus)
            .RuleFor(v => v.Mobiliteit, GenerateMobiliteit)
            .RuleFor(v => v.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(v => v.IdVacature, f => f.Random.Uuid().ToString())
            .RuleFor(v => v.Gedragscompetentie, f => GenerateGedragscompetentie(f, 3))
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Opleiding, f => GenerateMpOpleiding(f, 3))
            .RuleFor(v => v.Rijbewijs, f => GenerateRijbewijs(f, 3))
            .RuleFor(v => v.Sector, GenerateSector)
            .RuleFor(v => v.SluitingsdatumVacature, GenerateDate)
            .RuleFor(v => v.Sollicitatiewijze, f => GenerateMpSollicitatiewijze(f, 3))
            .RuleFor(v => v.Taalbeheersing, f => GenerateTaalbeheersing(f, 3))
            .RuleFor(v => v.Vakvaardigheid, f => GenerateVakvaardigheid(f, 3))
            .RuleFor(v => v.Vervoermiddel, f => GenerateVervoermiddel(f, 3))
            .RuleFor(v => v.Werkervaring, f => GenerateWerkervaring(f, 3))
            .RuleFor(v => v.Werkgever, GenerateWerkgever)
            .RuleFor(v => v.Werktijden, GenerateWerktijden);
            
        return faker.Generate();
    }
    
    public Vacature FakeVacature()
    {
        var faker = new Faker<Vacature>("nl")
            .RuleFor(v => v.ArbeidsVoorwaarden, GenerateArbeidsVoorwaarden)
            .RuleFor(v => v.Beroep, f => f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f))
            .RuleFor(v => v.CodeWerkEnDenkniveauMinimaal, f => f.Random.Int(0, 7).ToString())
            .RuleFor(v => v.Contractvorm, f => GenerateContractvorm(f, 3))
            .RuleFor(v => v.Cursus, GenerateCursus)
            .RuleFor(v => v.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(v => v.IdVacature, f => f.Random.Uuid().ToString())
            .RuleFor(v => v.Gedragscompetentie, f => GenerateGedragscompetentie(f, 3))
            .RuleFor(v => v.NaamVacature, f => GenerateName(f, 3, 120))
            .RuleFor(v => v.NummerVacature, f => f.Random.Int(1000, 9999).ToString())
            .RuleFor(v => v.OmschrijvingVacature, f => f.Lorem.Sentence())
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Opleiding, f => GenerateOpleiding(f, 3))
            .RuleFor(v => v.Rijbewijs, f => GenerateRijbewijs(f, 3))
            .RuleFor(v => v.Sector, GenerateSector)
            .RuleFor(v => v.SluitingsdatumVacature, GenerateDate)
            .RuleFor(v => v.Sollicitatiewijze, f => GenerateSollicitatiewijze(f, 3))
            .RuleFor(v => v.Taalbeheersing, f => GenerateTaalbeheersing(f, 3))
            .RuleFor(v => v.Vakvaardigheid, f => GenerateVakvaardigheid(f, 3))
            .RuleFor(v => v.Vervoermiddel, f => GenerateVervoermiddel(f, 3))
            .RuleFor(v => v.Werkervaring, f => GenerateWerkervaring(f, 3))
            .RuleFor(v => v.Werkgever, GenerateWerkgever)
            .RuleFor(v => v.Werktijden, GenerateWerktijden);
            
        return faker.Generate();
    }

    private static ArbeidsVoorwaarden GenerateArbeidsVoorwaarden(Faker f)
    {
        return new ArbeidsVoorwaarden
        {
            DatumAanvangWerkzaamheden =  GenerateDate(f),
            DatumEindeWerkzaamheden = GenerateDate(f),
            OmschrijvingArbeidsvoorwaarden = f.Lorem.Sentence(),
            SalarisIndicatie = f.Finance.Amount(1000, 10000, 0).ToString("F0"),
        };
    }

    private static List<CursusVacature> GenerateCursus(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var cursusList = new List<CursusVacature>();
        for (int i = 0; i < length; i++)
        {
            var cursus = new CursusVacature()
            {
                NaamCursus = GenerateName(f, 3, 120)
            };
            cursusList.Add(cursus);
        }
        
        return cursusList;
    }    
    

    private static Opleidingsnaam GenerateOpleidingsnaamGecodeerd(Faker f)
    {
        return new Opleidingsnaam
        {
            OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd
            {
                CodeOpleidingsnaam = f.PickRandom(OpleidingCodes),
                OmschrijvingOpleidingsnaam = f.Lorem.Sentence(15, 120), 
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
                OmschrijvingOpleidingsnaam = f.Lorem.Sentence(15, 120), 
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
    
    private static List<OpleidingVacature> GenerateOpleiding(Faker f, int maxItems)
    {
        var result = new List<OpleidingVacature>();
        var length = f.Random.Int(min: 1, max: maxItems);
        for (int i = 0; i < length; i++)
        {
            result.Add(new OpleidingVacature()
            {
                CodeNiveauOpleiding = f.Random.ListItem(NiveauOpleidingCodes),
                IndicatieDiploma = f.Random.ListItem(IndicatieDiploma),
                Opleidingsnaam = f.Random.Bool()
                ? GenerateOpleidingsnaamGecodeerd(f)
                : GenerateOpleidingsnaamOngecodeerd(f)
            });
        }

        return result;        
    }
    
    private static List<MPOpleidingVacature> GenerateMpOpleiding(Faker f, int maxItems)
    {
        var codeNiveauOpleiding = new List<int> { 1, 2, 3, 4, 5, 9 };
        
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<MPOpleidingVacature>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new MPOpleidingVacature()
            {
                CodeNiveauOpleiding = f.Random.ListItem(codeNiveauOpleiding),
                IndicatieDiploma = f.Random.ListItem(IndicatieDiploma),
                Opleidingsnaam = f.Random.Bool()
                ? GenerateMpOpleidingsnaamGecodeerd(f)
                : GenerateMpOpleidingsnaamOngecodeerd(f)
            });
        }

        return result;
    }    

    private static List<MpSollicitatiewijze> GenerateMpSollicitatiewijze(Faker f, int maxItems)
    {
        var codeSollicitatiewijze = new List<string>{ "1", "2", "3", "4" };
        
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<MpSollicitatiewijze>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new MpSollicitatiewijze()
            {
                CodeSollicitatiewijze = f.Random.ListItem(codeSollicitatiewijze)
            });
        }
    
        return result;
    }    
    
    private static List<Sollicitatiewijze> GenerateSollicitatiewijze(Faker f, int maxItems)
    {
        var codeSollicitatiewijze = new List<string>{ "1", "2", "3", "4" };
        
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<Sollicitatiewijze>();
        for (int i = 0; i < length; i++)
        {
            result.Add(new Sollicitatiewijze()
            {
                CodeSollicitatiewijze = f.Random.ListItem(codeSollicitatiewijze),
                Webadres = GenerateWebadres(f)
            });
        }

        return result;
    }
    
    private static List<WerkervaringVacature> GenerateWerkervaring(Faker f, int maxItems)
    {
        var length = f.Random.Int(min: 1, max: maxItems);
        var result = new List<WerkervaringVacature>();
        for (int i = 0; i < length; i++)
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
            AdresHouding = GenerateAdresHouding(f, 3),
            Contactpersoon = GenerateContactPersoon(f, 3),
            HandelsnaamOrganisatie = GenerateName(f, 3, 500),
            Sector = GenerateSector(f, 3),
            Webadres = GenerateWebadres(f, 3) 
        };

        return werkgever;        

    }
    
    private static List<AdresHouding> GenerateAdresHouding(Faker f, int maxItems)
    {
        var codeFunctieAdres = new List<string> { "B", "W", "C", "L", "A", "V", "E" };
        
        var length = f.Random.Int(min: 1, max: maxItems);
        var adresHouding = new List<AdresHouding>();
        for (int i = 0; i < length; i++)
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
            Locatieomschrijving = f.Lorem.Sentence(15, 70),
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
        var streetName = f.Address.StreetName();
        var straatadres = new Straatadres()
        {
            AanduidingBijHuisnummer = f.Random.String2(1, UpperCase),
            Huisletter = f.Random.String2(1, UpperCase),
            Huisnummer = f.PickRandom(1, 1000),
            Huisnummertoevoeging = f.Random.String2(1, UpperCase),
            NaamOpenbareRuimte = GenerateName(f, 3, 80),
            Straatnaam = streetName.Length > 24 ? streetName[..24] : streetName,
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
            LandencodeIso = GenerateCode(f, 2, 2),
            Landsnaam = f.Address.Country(),
            LocatieomschrijvingBuitenland = f.Lorem.Sentence(15, 70),
            PostcodeBuitenland = GenerateCode(f, 3, 9),
            RegionaamBuitenland = GenerateName(f, 3, 24),
            WoonplaatsnaamBuitenland = new Faker("en").Address.City()
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
        var streetName = new Faker("en").Address.StreetName();
        var straatadresBuitenland = new StraatadresBuitenland()
        {
            HuisnummerBuitenland = f.Random.String2(1, 9),
            StraatnaamBuitenland = streetName.Length > 24 ? streetName[..24] : streetName
        };

        return straatadresBuitenland;
    }

    private static PostbusadresBuitenland GeneratePostbusadresBuitenland(Faker f)
    {
        var postbusadresBuitenland = new PostbusadresBuitenland()
        {
            PostbusnummerBuitenland = f.Random.String2(2, 9)
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
