using System.Text.Json.Serialization;

namespace AutoBogusApp.Vum
{
    // MPWerkzoekendeMatch model
    public class MpWerkzoekendeMatch
    {
        [JsonPropertyName("arbeidsmarktkwalificatie")]
        public MpArbeidsmarktkwalificatie? Arbeidsmarktkwalificatie { get; set; }

        [JsonPropertyName("bemiddelingsberoep")]
        public List<Beroepsnaam>? Bemiddelingsberoep { get; set; }

        [JsonPropertyName("contractvorm")]
        public List<Contractvorm>? Contractvorm { get; set; }

        [JsonPropertyName("flexibiliteit")]
        public Flexibiliteit? Flexibiliteit { get; set; }

        [JsonPropertyName("idWerkzoekende")]
        public string? IdWerkzoekende { get; set; }

        [JsonPropertyName("indicatieBeschikbaarheidContactgegevens")]
        public int? IndicatieBeschikbaarheidContactgegevens { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("mobiliteit")]
        public required Mobiliteit Mobiliteit { get; set; }

        [JsonPropertyName("sector")]
        public List<SectorBeroepsEnBedrijfsleven>? Sector { get; set; }

        [JsonPropertyName("vervoermiddel")]
        public List<MpVervoermiddel>? Vervoermiddel { get; set; }

        [JsonPropertyName("voorkeursland")]
        public List<Voorkeursland>? Voorkeursland { get; set; }

        [JsonPropertyName("werktijden")]
        public Werktijden? Werktijden { get; set; }
    }    
    
    
    // Werkzoekende model
    public class Werkzoekende
    {
        [JsonPropertyName("arbeidsmarktkwalificatie")]
        public Arbeidsmarktkwalificatie? Arbeidsmarktkwalificatie { get; set; }

        [JsonPropertyName("bemiddelingsberoep")]
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
        public string? IdWerkzoekende { get; set; }

        [JsonPropertyName("indicatieBeschikbaarheidContactgegevens")]
        public int? IndicatieBeschikbaarheidContactgegevens { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("mobiliteit")]
        public Mobiliteit? Mobiliteit { get; set; }

        [JsonPropertyName("persoonlijkePresentatie")]
        public string? PersoonlijkePresentatie { get; set; }

        [JsonPropertyName("sector")]
        public List<SectorBeroepsEnBedrijfsleven>? Sector { get; set; }

        [JsonPropertyName("telefoonnummer")]
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
    
    // MpArbeidsmarktkwalificatie model
    public class MpArbeidsmarktkwalificatie
    {
        [JsonPropertyName("codeWerkEnDenkniveauWerkzoekende")]
        public int? CodeWerkEnDenkniveauWerkzoekende { get; set; }

        [JsonPropertyName("cursus")]
        public List<MpCursus>? Cursus { get; set; }

        [JsonPropertyName("gedragscompetentie")]
        public List<Gedragscompetentie>? Gedragscompetentie { get; set; }

        [JsonPropertyName("opleiding")]
        public List<MpOpleiding>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("taalbeheersing")]
        public List<Taalbeheersing>? Taalbeheersing { get; set; }

        [JsonPropertyName("vakvaardigheid")]
        public List<Vakvaardigheid>? Vakvaardigheid { get; set; }

        [JsonPropertyName("werkervaring")]
        public List<MpWerkervaring>? Werkervaring { get; set; }
    }
    
    
    // Arbeidsmarktkwalificatie model
    public class Arbeidsmarktkwalificatie
    {
        [JsonPropertyName("codeWerkEnDenkniveauWerkzoekende")]
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

    // Cursus model
    public class MpCursus
    {
        [JsonPropertyName("datumCertificaat")]
        public string? DatumCertificaat { get; set; }

        [JsonPropertyName("naamCursus")]
        public string? NaamCursus { get; set; }
    }
    
    // Werkervaring model
    public class MpWerkervaring
    {
        [JsonPropertyName("beroep")]
        public Beroepsnaam? Beroep { get; set; }

        [JsonPropertyName("datumAanvangWerkzaamheden")]
        public string? DatumAanvangWerkzaamheden { get; set; }

        [JsonPropertyName("datumEindeWerkzaamheden")]
        public string? DatumEindeWerkzaamheden { get; set; }

        [JsonPropertyName("naamOrganisatie")]
        public string? NaamOrganisatie { get; set; }
    }
    
    // Interesse model
    public class Interesse
    {
        [JsonPropertyName("naamInteresse")]
        public string? NaamInteresse { get; set; }
    }

    // MPOpleiding model
    public class MpOpleiding
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("datumDiploma")]
        public string? DatumDiploma { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        public Opleidingsnaam? Opleidingsnaam { get; set; }
    }    
    
    // Opleiding model
    public class Opleiding
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("codeStatusOpleiding")]
        public int? CodeStatusOpleiding { get; set; }

        [JsonPropertyName("datumAanvangVolgenOpleiding")]
        public string? DatumAanvangVolgenOpleiding { get; set; }

        [JsonPropertyName("datumDiploma")]
        public string? DatumDiploma { get; set; }

        [JsonPropertyName("datumEindeVolgenOpleiding")]
        public string? DatumEindeVolgenOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("naamOpleidingsinstituut")]
        public string? NaamOpleidingsinstituut { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        public Opleidingsnaam? Opleidingsnaam { get; set; }
    }

    // Mobiliteit model
    public class Mobiliteit
    {
        [JsonPropertyName("bemiddelingspostcode")]
        public string? Bemiddelingspostcode { get; set; }

        [JsonPropertyName("maximaleReisafstand")]
        public int? MaximaleReisafstand { get; set; }

        [JsonPropertyName("maximaleReistijd")]
        public int? MaximaleReistijd { get; set; }
    }

    // Voorkeursland model
    public class Voorkeursland
    {
        [JsonPropertyName("landencodeIso")]
        public string? LandencodeIso { get; set; }
    }

    // WPContactpersoonAfdeling model
    public class WPContactpersoonAfdeling
    {
        [JsonPropertyName("emailadres")]
        public string? Emailadres { get; set; }

        [JsonPropertyName("naamContactpersoonAfdeling")]
        public string? NaamContactpersoonAfdeling { get; set; }

        [JsonPropertyName("telefoonnummer")]
        public string? Telefoonnummer { get; set; }
    }

    // ContactpersoonAfdeling model
    public class ContactpersoonAfdeling
    {
        [JsonPropertyName("emailadres")]
        public List<string>? Emailadres { get; set; }

        [JsonPropertyName("naamContactpersoonAfdeling")]
        public string? NaamContactpersoonAfdeling { get; set; }

        [JsonPropertyName("telefoonnummer")]
        public List<string>? Telefoonnummer { get; set; }
    }

    // EisAanWerk model
    public class EisAanWerk
    {
        [JsonPropertyName("indicatieAanpassingWerkomgeving")]
        public int? IndicatieAanpassingWerkomgeving { get; set; }

        [JsonPropertyName("indicatieBegeleiding")]
        public int? IndicatieBegeleiding { get; set; }

        [JsonPropertyName("indicatieWerkvariatie")]
        public int? IndicatieWerkvariatie { get; set; }
    }
}