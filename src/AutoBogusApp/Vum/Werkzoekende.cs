using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutoBogusApp.Vum
{
    // Werkzoekende model
    public class Werkzoekende
    {
        [JsonPropertyName("arbeidsmarktkwalificatie")]
        public Arbeidsmarktkwalificatie? Arbeidsmarktkwalificatie { get; set; }

        [JsonPropertyName("bemiddelingsberoep")]
        [OneOfBeroepsnaam(true, 2)]
        public List<Beroepsnaam>? Bemiddelingsberoep { get; set; }

        [JsonPropertyName("contactpersoon")]
        public List<WPContactpersoonAfdeling>? Contactpersoon { get; set; }

        [JsonPropertyName("contractvorm")]
        public List<Contractvorm>? Contractvorm { get; set; }

        [JsonPropertyName("eisAanWerk")]
        public EisAanWerk? EisAanWerk { get; set; }

        [JsonPropertyName("emailadres")]
        public List<string>? Emailadres { get; set; }

        [JsonPropertyName("flexibiliteit")]
        public Flexibiliteit? Flexibiliteit { get; set; }

        [JsonPropertyName("idWerkzoekende")]
        [UuidHyphenated]
        public string? IdWerkzoekende { get; set; }

        [JsonPropertyName("indicatieBeschikbaarheidContactgegevens")]
        [OneOf(1, 2)]
        public int? IndicatieBeschikbaarheidContactgegevens { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        [OneOf(1, 2)]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("mobiliteit")]
        public Mobiliteit? Mobiliteit { get; set; }

        [JsonPropertyName("persoonlijkePresentatie")]
        public string? PersoonlijkePresentatie { get; set; }

        [JsonPropertyName("sector")]
        public List<SectorBeroepsEnBedrijfsleven>? Sector { get; set; }

        [JsonPropertyName("telefoonnummer")]
        [DutchPhoneNumber(true, 3)]
        public List<string>? Telefoonnummer { get; set; }

        [JsonPropertyName("vervoermiddel")]
        public List<Vervoermiddel>? Vervoermiddel { get; set; }

        [JsonPropertyName("voorkeursland")]
        public List<Voorkeursland>? Voorkeursland { get; set; }

        [JsonPropertyName("webadres")]
        public List<Webadres>? Webadres { get; set; }

        [JsonPropertyName("werktijden")]
        public Werktijden? Werktijden { get; set; }
    }

    // Arbeidsmarktkwalificatie model
    public class Arbeidsmarktkwalificatie
    {
        [JsonPropertyName("codeWerkEnDenkniveauWerkzoekende")]
        [IntRange(0, 7)]
        public int? CodeWerkEnDenkniveauWerkzoekende { get; set; }

        [JsonPropertyName("cursus")]
        public List<Cursus>? Cursus { get; set; }

        [JsonPropertyName("gedragscompetentie")]
        public List<Gedragscompetentie>? Gedragscompetentie { get; set; }

        [JsonPropertyName("interesse")]
        public List<Interesse>? Interesse { get; set; }

        [JsonPropertyName("opleiding")]
        public List<Opleiding>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("taalbeheersing")]
        public List<Taalbeheersing>? Taalbeheersing { get; set; }

        [JsonPropertyName("vakvaardigheid")]
        public List<Vakvaardigheid>? Vakvaardigheid { get; set; }

        [JsonPropertyName("werkervaring")]
        public List<Werkervaring>? Werkervaring { get; set; }
    }

    // Interesse model
    public class Interesse
    {
        [JsonPropertyName("naamInteresse")]
        [Word]
        public string? NaamInteresse { get; set; }
    }

    // Opleiding model
    public class Opleiding
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        [OneOf(1, 2, 3, 4, 5, 6, 9)]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("codeStatusOpleiding")]
        [OneOf(1, 2, 3)]
        public int? CodeStatusOpleiding { get; set; }

        [JsonPropertyName("datumAanvangVolgenOpleiding")]
        [FormattedDate]
        public string? DatumAanvangVolgenOpleiding { get; set; }

        [JsonPropertyName("datumDiploma")]
        [FormattedDate]
        public string? DatumDiploma { get; set; }

        [JsonPropertyName("datumEindeVolgenOpleiding")]
        [FormattedDate]
        public string? DatumEindeVolgenOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        [OneOf(0, 1, 2, 8)]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("naamOpleidingsinstituut")]
        [Name]
        public string? NaamOpleidingsinstituut { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        [OneOfOpleidingsnaam]
        public Opleidingsnaam? Opleidingsnaam { get; set; }
    }

    // Mobiliteit model
    public class Mobiliteit
    {
        [JsonPropertyName("bemiddelingspostcode")]
        [Postcode]
        public string? Bemiddelingspostcode { get; set; }

        [JsonPropertyName("maximaleReisafstand")]
        [IntRange(0, 999)]
        public int? MaximaleReisafstand { get; set; }

        [JsonPropertyName("maximaleReistijd")]
        [IntRange(0, 999)]
        public int? MaximaleReistijd { get; set; }
    }

    // Voorkeursland model
    public class Voorkeursland
    {
        [JsonPropertyName("landencodeIso")]
        [RestrictedLengthString(1, 2)]
        public string? LandencodeIso { get; set; }
    }

    // WPContactpersoonAfdeling model
    public class WPContactpersoonAfdeling
    {
        [JsonPropertyName("emailadres")]
        [Email]
        public string? Emailadres { get; set; }

        [JsonPropertyName("naamContactpersoonAfdeling")]
        [Name]
        public string? NaamContactpersoonAfdeling { get; set; }

        [JsonPropertyName("telefoonnummer")]
        [DutchPhoneNumber]
        public string? Telefoonnummer { get; set; }
    }

    // ContactpersoonAfdeling model
    public class ContactpersoonAfdeling
    {
        [JsonPropertyName("emailadres")]
        [Email(true, 3)]
        public List<string>? Emailadres { get; set; }

        [JsonPropertyName("naamContactpersoonAfdeling")]
        [Name]
        public string? NaamContactpersoonAfdeling { get; set; }

        [JsonPropertyName("telefoonnummer")]
        [DutchPhoneNumber(true, 3)]
        public List<string>? Telefoonnummer { get; set; }
    }

    // EisAanWerk model
    public class EisAanWerk
    {
        [JsonPropertyName("indicatieAanpassingWerkomgeving")]
        [OneOf(0, 1, 2)]
        public int? IndicatieAanpassingWerkomgeving { get; set; }

        [OneOf(0, 1, 2)]
        [JsonPropertyName("indicatieBegeleiding")]
        public int? IndicatieBegeleiding { get; set; }

        [JsonPropertyName("indicatieWerkvariatie")]
        [OneOf(0, 1, 2)]
        public int? IndicatieWerkvariatie { get; set; }
    }
}