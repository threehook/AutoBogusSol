using Bogus;
using AutoBogusApp.Vum;
using static AutoBogusApp.DataGeneration.CommonFaker;

namespace AutoBogusApp.DataGeneration;

public class WerkzoekendeFaker
{
    public MpWerkzoekendeMatch FakeMpWerkzoekendeMatch()
    {
        var faker = new Faker<MpWerkzoekendeMatch>("nl")
            .RuleFor(w => w.Arbeidsmarktkwalificatie, GenerateMpArbeidsmarktkwalificatie)
            .RuleFor(w => w.Bemiddelingsberoep, GenerateBeroepsnaam)
            .RuleFor(w => w.Contractvorm, GenerateContractvorm)
            .RuleFor(w => w.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(w => w.IdWerkzoekende, f => f.Random.Uuid().ToString())
            .RuleFor(w => w.IndicatieBeschikbaarheidContactgegevens, f => f.PickRandom(1, 2))
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Mobiliteit, GenerateMobiliteit)
            .RuleFor(v => v.Sector, f => GenerateSector(f, 3))
            .RuleFor(v => v.Vervoermiddel, GenerateMpVervoermiddel)
            .RuleFor(v => v.Voorkeursland, GenerateVoorkeursland)
            .RuleFor(v => v.Werktijden, GenerateWerktijden);

        return faker.Generate();
    }      
    
    public Werkzoekende FakeWerkzoekende()
    {
        var faker = new Faker<Werkzoekende>("nl")
            .RuleFor(w => w.Arbeidsmarktkwalificatie, GenerateArbeidsmarktkwalificatie)
            .RuleFor(w => w.Bemiddelingsberoep, GenerateBeroepsnaam)
            .RuleFor(w => w.Contactpersoon, GenerateContactpersoon)
            .RuleFor(w => w.EisAanWerk, GenerateEisAanWerk)
            .RuleFor(w => w.Emailadres, f => GenerateEmailAdresList(f, 3))
            .RuleFor(w => w.Flexibiliteit, GenerateFlexibiliteit)
            .RuleFor(w => w.IdWerkzoekende, f => f.Random.Uuid().ToString())
            .RuleFor(w => w.IndicatieBeschikbaarheidContactgegevens, f => f.PickRandom(1, 2))
            .RuleFor(v => v.IndicatieLdrRegistratie, f => f.Random.Int(1, 2))
            .RuleFor(v => v.Mobiliteit, GenerateMobiliteit)
            .RuleFor(v => v.PersoonlijkePresentatie, f => f.Lorem.Sentence())
            .RuleFor(v => v.Sector, f => GenerateSector(f, 3))
            .RuleFor(v => v.Telefoonnummer, f => GenerateTelefoonnummer(f, 3))
            .RuleFor(v => v.Vervoermiddel, GenerateVervoermiddel)
            .RuleFor(v => v.Voorkeursland, GenerateVoorkeursland)
            .RuleFor(v => v.Webadres, f => GenerateWebadres(f, 3))
            .RuleFor(v => v.Werktijden, GenerateWerktijden);

        return faker.Generate();
    }  

    private static MpArbeidsmarktkwalificatie GenerateMpArbeidsmarktkwalificatie(Faker f)
    {
        return new MpArbeidsmarktkwalificatie()
        {
            CodeWerkEnDenkniveauWerkzoekende = f.Random.Int(0, 7),
            Cursus = GenerateMpCursus(f),
            Gedragscompetentie = GenerateGedragscompetentie(f),
            Opleiding = GenerateMpOpleiding(f),
            Rijbewijs = GenerateRijbewijs(f),
            Taalbeheersing = GenerateTaalbeheersing(f),
            Vakvaardigheid = GenerateVakvaardigheid(f),
            Werkervaring = GenerateMpWerkervaring(f)
        };
    }    
    
    private static Arbeidsmarktkwalificatie GenerateArbeidsmarktkwalificatie(Faker f)
    {
        return new Arbeidsmarktkwalificatie()
        {
            CodeWerkEnDenkniveauWerkzoekende = f.Random.Int(0, 7),
            Cursus = GenerateCursus(f),
            Gedragscompetentie = GenerateGedragscompetentie(f),
            Interesse = GenerateInteresse(f),
            Opleiding = GenerateOpleiding(f),
            Rijbewijs = GenerateRijbewijs(f),
            Taalbeheersing = GenerateTaalbeheersing(f),
            Vakvaardigheid = GenerateVakvaardigheid(f),
            Werkervaring = GenerateWerkervaring(f),
        };
    }

    private static List<MpCursus> GenerateMpCursus(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var cursusList = new List<MpCursus>();
        for (int i = 0; i < length; i++)
        {
            var cursus = new MpCursus()
            {
                DatumCertificaat = GenerateDate(f),
                NaamCursus = GenerateName(f, 3, 120)
            };
            cursusList.Add(cursus);
        }
        
        return cursusList;
    }    
    
    private static List<Cursus> GenerateCursus(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var cursusList = new List<Cursus>();
        for (int i = 0; i < length; i++)
        {
            var cursus = new Cursus()
            {
                DatumAanvangVolgenCursus = GenerateDate(f),
                DatumCertificaat = GenerateDate(f),
                DatumEindeVolgenCursus = GenerateDate(f),
                NaamCursus = GenerateName(f, 3, 120),
                NaamOpleidingsinstituut = GenerateName(f, 3, 500)
            };            
            
            cursusList.Add(cursus);
        }

        return cursusList;
    }

    private static List<Interesse> GenerateInteresse(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var interesseList = new List<Interesse>();
        for (int i = 0; i < length; i++)
        {
            var interesse = new Interesse()
            {
                NaamInteresse = GenerateName(f, 3, 120)
            };
            
            interesseList.Add(interesse);
        }

        return interesseList;
    } 

    private static List<MpOpleiding> GenerateMpOpleiding(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var opleidingList = new List<MpOpleiding>();
        for (int i = 0; i < length; i++)
        {
            var opleiding = new MpOpleiding()
            {
                CodeNiveauOpleiding = f.PickRandom(NiveauOpleidingCodes),
                DatumDiploma = GenerateDate(f),
                IndicatieDiploma = f.PickRandom(IndicatieDiploma),
                Opleidingsnaam = f.Random.Bool()
                    ? GeneratOpleidingsnaamGecodeerd(f)
                    : GenerateOpleidingsnaamOngecodeerd(f)
            };
            
            opleidingList.Add(opleiding);
        }

        return opleidingList;
    }    
    
    private static List<Opleiding> GenerateOpleiding(Faker f)
    {
        var codeStatusOpleiding = new List<int> { 1, 2, 3, 4, 5, 6, 9 };
        var length = f.Random.Int(min: 1, max: 3);
        var opleidingList = new List<Opleiding>();
        for (int i = 0; i < length; i++)
        {
            var opleiding = new Opleiding()
            {
                CodeNiveauOpleiding = f.PickRandom(NiveauOpleidingCodes),
                CodeStatusOpleiding = f.PickRandom(codeStatusOpleiding),
                DatumAanvangVolgenOpleiding = GenerateDate(f),
                DatumDiploma = GenerateDate(f),
                DatumEindeVolgenOpleiding = GenerateDate(f),
                IndicatieDiploma = f.PickRandom(IndicatieDiploma),
                NaamOpleidingsinstituut = GenerateName(f, 3, 500),
                Opleidingsnaam = f.Random.Bool()
                    ? GeneratOpleidingsnaamGecodeerd(f)
                    : GenerateOpleidingsnaamOngecodeerd(f)
            };
            
            opleidingList.Add(opleiding);
        }

        return opleidingList;
    }
    
    private static Opleidingsnaam GeneratOpleidingsnaamGecodeerd(Faker f)
    {
        return new Opleidingsnaam
        {
            OpleidingsnaamGecodeerd = new OpleidingsnaamGecodeerd
            {
                CodeOpleidingsnaam = f.PickRandom(OpleidingCodes),
                OmschrijvingOpleidingsnaam = GenerateName(f, 3, 120)
            }
        };
    }

    private static Opleidingsnaam GenerateOpleidingsnaamOngecodeerd(Faker f)
    {
        return new Opleidingsnaam
        {
            OpleidingsnaamOngecodeerd = new OpleidingsnaamOngecodeerd()
            {
                NaamOpleidingOngecodeerd = GenerateName(f, 3, 120),
                OmschrijvingOpleiding = f.Lorem.Sentence()
            }
        };
    }
    
    private static List<Beroepsnaam> GenerateBeroepsnaam(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var beroepsnaamList = new List<Beroepsnaam>();
        for (int i = 0; i < length; i++)
        {
            var beroepsnaam = f.Random.Bool()
                ? GenerateBeroepsnaamGecodeerd(f)
                : GenerateBeroepsnaamOngecodeerd(f);
            
            beroepsnaamList.Add(beroepsnaam);
        }

        return beroepsnaamList;
    } 
    
    private static List<WPContactpersoonAfdeling> GenerateContactpersoon(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var contactpersoonList = new List<WPContactpersoonAfdeling>();
        for (int i = 0; i < length; i++)
        {
            var contactpersoon = new WPContactpersoonAfdeling()
            {
                Emailadres = f.Internet.Email(),
                NaamContactpersoonAfdeling = GenerateName(f, 3, 35),
                Telefoonnummer = f.Phone.PhoneNumber()
            };
            
            contactpersoonList.Add(contactpersoon);
        }

        return contactpersoonList;
    }

    private static EisAanWerk GenerateEisAanWerk(Faker f)
    {
        var indicatieCodes = new List<int>() { 0, 1, 2 };
        return new EisAanWerk()
        {
            IndicatieAanpassingWerkomgeving = f.PickRandom(indicatieCodes),
            IndicatieBegeleiding = f.PickRandom(indicatieCodes),
            IndicatieWerkvariatie = f.PickRandom(indicatieCodes)
        };
    }

    private static Mobiliteit GenerateMobiliteit(Faker f)
    {
        return new Mobiliteit()
        {
            Bemiddelingspostcode = GeneratePostcode(f),
            MaximaleReisafstand = f.Random.Int(min: 0, max: 999),
        };
    }

    private static List<MpVervoermiddel> GenerateMpVervoermiddel(Faker f)
    {
        var indicatieBeschikbaarVoorUitvoeringWerk = new List<int> { 0, 1, 2 };
        var indicatieBeschikbaarVoorWoonWerkverkeer = new List<int> { 0, 1, 2 };
        
        var result = new List<MpVervoermiddel>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new MpVervoermiddel()
            {
                IndicatieBeschikbaarVoorUitvoeringWerk = f.Random.ListItem(indicatieBeschikbaarVoorUitvoeringWerk),
                IndicatieBeschikbaarVoorWoonWerkverkeer = f.Random.ListItem(indicatieBeschikbaarVoorWoonWerkverkeer),
            });
        }

        return result;
    }
    
    private static List<Voorkeursland> GenerateVoorkeursland(Faker f)
    {
        var length = f.Random.Int(min: 1, max: 3);
        var voorkeurslandList = new List<Voorkeursland>();
        for (int i = 0; i < length; i++)
        {
            var voorkeursland = new Voorkeursland()
            {
                LandencodeIso = f.Random.String2(2)
            };
            
            voorkeurslandList.Add(voorkeursland);
        }

        return voorkeurslandList;
    }

    private static List<MpWerkervaring> GenerateMpWerkervaring(Faker f)
    {
        var result = new List<MpWerkervaring>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new MpWerkervaring()
            {
                Beroep = f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f),
                DatumAanvangWerkzaamheden = GenerateDate(f),
                DatumEindeWerkzaamheden = GenerateDate(f),
                NaamOrganisatie = GenerateName(f,3, 70)
            });
        }

        return result;
    }    
    
    private static List<Werkervaring> GenerateWerkervaring(Faker f)
    {
        var result = new List<Werkervaring>();
        for (int i = 0; i < new Random().Next(1, 3); i++)
        {
            result.Add(new Werkervaring()
            {
                Beroep = f.Random.Bool() ? GenerateBeroepsnaamGecodeerd(f) : GenerateBeroepsnaamOngecodeerd(f),
                DatumAanvangWerkzaamheden = GenerateDate(f),
                DatumEindeWerkzaamheden = GenerateDate(f),
                NaamOrganisatie = GenerateName(f,3, 70),
                ToelichtingWerkervaring = f.Lorem.Sentence()
            });
        }

        return result;
    }
    
}

