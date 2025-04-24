using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AutoBogusApp.Vum
{
    public class MPVacatureMatch
    {
        [JsonPropertyName("arbeidsVoorwaarden")]
        public ArbeidsVoorwaarden? ArbeidsVoorwaarden { get; set; }

        [JsonPropertyName("beroep")]
        [OneOfBeroepsnaam]
        public Beroepsnaam? Beroep { get; set; }
       
        [JsonPropertyName("codeWerkEnDenkniveauMinimaal")]
        [OneOf("0", "1", "2", "3", "4", "5", "6", "7")]
        public string? CodeWerkEnDenkniveauMinimaal { get; set; }

        [JsonPropertyName("contractvorm")]
        public List<Contractvorm>? Contractvorm { get; set; }

        [JsonPropertyName("cursus")]
        public List<CursusVacature>? Cursus { get; set; }

        [JsonPropertyName("flexibiliteit")]
        public Flexibiliteit? Flexibiliteit { get; set; }

        [JsonPropertyName("gedragscompetentie")]
        public List<Gedragscompetentie>? Gedragscompetentie { get; set; }

        [JsonPropertyName("idVacature")]
        [UuidHyphenated]
        public string? IdVacature { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        [OneOf(1, 2)]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("opleiding")]
        public List<MPOpleidingVacature>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("sector")]
        public SectorBeroepsEnBedrijfsleven? Sector { get; set; }

        [JsonPropertyName("sluitingsdatumVacature")]
        [FormattedDate]
        public string? SluitingsdatumVacature { get; set; }

        [JsonPropertyName("sollicitatiewijze")]
        public List<Sollicitatiewijze>? Sollicitatiewijze { get; set; }

        [JsonPropertyName("taalbeheersing")]
        public List<Taalbeheersing>? Taalbeheersing { get; set; }

        [JsonPropertyName("vakvaardigheid")]
        public List<Vakvaardigheid>? Vakvaardigheid { get; set; }

        [JsonPropertyName("vervoermiddel")]
        public List<Vervoermiddel>? Vervoermiddel { get; set; }

        [JsonPropertyName("werkervaring")]
        public List<WerkervaringVacature>? Werkervaring { get; set; }

        [JsonPropertyName("werkgever")]
        public Werkgever? Werkgever { get; set; }

        [JsonPropertyName("werktijden")]
        public Werktijden? Werktijden { get; set; }
    }    
    
    public class Vacature
    {
        [JsonPropertyName("arbeidsVoorwaarden")]
        public ArbeidsVoorwaarden? ArbeidsVoorwaarden { get; set; }

        [JsonPropertyName("beroep")]
        [OneOfBeroepsnaam]
        public Beroepsnaam? Beroep { get; set; }
       
        [JsonPropertyName("codeWerkEnDenkniveauMinimaal")]
        [OneOf("0", "1", "2", "3", "4", "5", "6", "7")]
        public string? CodeWerkEnDenkniveauMinimaal { get; set; }

        [JsonPropertyName("contractvorm")]
        public List<Contractvorm>? Contractvorm { get; set; }

        [JsonPropertyName("cursus")]
        public List<CursusVacature>? Cursus { get; set; }

        [JsonPropertyName("flexibiliteit")]
        public Flexibiliteit? Flexibiliteit { get; set; }

        [JsonPropertyName("gedragscompetentie")]
        public List<Gedragscompetentie>? Gedragscompetentie { get; set; }

        [JsonPropertyName("idVacature")]
        [UuidHyphenated]
        public string? IdVacature { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        [OneOf(1, 2)]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("naamVacature")]
        public string? NaamVacature { get; set; }

        [JsonPropertyName("nummerVacature")]
        [IntRange(1000, 9999, true)]
        public string? NummerVacature { get; set; }

        [JsonPropertyName("omschrijvingVacature")]
        [Sentence]
        public string? OmschrijvingVacature { get; set; }

        [JsonPropertyName("opleiding")]
        public List<OpleidingVacature>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("sector")]
        public SectorBeroepsEnBedrijfsleven? Sector { get; set; }

        [JsonPropertyName("sluitingsdatumVacature")]
        [FormattedDate]
        public string? SluitingsdatumVacature { get; set; }

        [JsonPropertyName("sollicitatiewijze")]
        public List<Sollicitatiewijze>? Sollicitatiewijze { get; set; }

        [JsonPropertyName("taalbeheersing")]
        public List<Taalbeheersing>? Taalbeheersing { get; set; }

        [JsonPropertyName("vakvaardigheid")]
        public List<Vakvaardigheid>? Vakvaardigheid { get; set; }

        [JsonPropertyName("vervoermiddel")]
        public List<Vervoermiddel>? Vervoermiddel { get; set; }

        [JsonPropertyName("werkervaring")]
        public List<WerkervaringVacature>? Werkervaring { get; set; }

        [JsonPropertyName("werkgever")]
        public Werkgever? Werkgever { get; set; }

        [JsonPropertyName("werktijden")]
        public Werktijden? Werktijden { get; set; }
    }
    
    // ArbeidsVoorwaarden model
    public class ArbeidsVoorwaarden
    {
        [JsonPropertyName("datumAanvangWerkzaamheden")]
        [FormattedDate]
        public string? DatumAanvangWerkzaamheden { get; set; }

        [JsonPropertyName("datumEindeWerkzaamheden")]
        [FormattedDate]        
        public string? DatumEindeWerkzaamheden { get; set; }

        [JsonPropertyName("omschrijvingArbeidsvoorwaarden")]
        [Sentence]
        public string? OmschrijvingArbeidsvoorwaarden { get; set; }

        [JsonPropertyName("salarisIndicatie")]
        [IntRangeAttribute(1000, 10000, true)]
        public string? SalarisIndicatie { get; set; }
    }

    // Sollicitatiewijze model
    public class Sollicitatiewijze
    {
        [JsonPropertyName("codeSollicitatiewijze")]
        [OneOf("1", "2", "3", "4")]
        public string? CodeSollicitatiewijze { get; set; }

        [JsonPropertyName("webadres")]
        [WebAddress]
        public Webadres? Webadres { get; set; }
    }

    // Werkgever model
    public class Werkgever
    {
        [JsonPropertyName("adresHouding")]
        public List<AdresHouding>? AdresHouding { get; set; }

        [JsonPropertyName("contactpersoon")]
        public List<ContactpersoonAfdeling>? Contactpersoon { get; set; }
        
        [JsonPropertyName("handelsnaamOrganisatie")]
        public string? HandelsnaamOrganisatie { get; set; }
        
        [JsonPropertyName("sector")]
        public List<SectorBeroepsEnBedrijfsleven>? Sector { get; set; }
        
        [JsonPropertyName("webadres")]
        public List<Webadres>? Webadres { get; set; }
        
        public List<AdresHouding>? GetAdresHouding() => AdresHouding;
    }

    // AdresHouding model
    public class AdresHouding
    {
        [JsonPropertyName("adres")]
        public AdresHoudingAdres? Adres { get; set; }

        [JsonPropertyName("codeFunctieAdres")]
        [OneOf("B", "W", "C", "L", "A", "V", "E")]
        public string? CodeFunctieAdres { get; set; }

        [JsonPropertyName("datumAanvangAdres")]
        [FormattedDate]
        public string? DatumAanvangAdres { get; set; }

        [JsonPropertyName("datumEindeAdres")]
        [FormattedDate]
        public string? DatumEindeAdres { get; set; }

        public AdresHoudingAdres? GetAdres() => Adres;
    }

    // AdresHoudingAdres model
    public class AdresHoudingAdres
    {
        [JsonPropertyName("adresNederland")]
        public AdresNederland? AdresNederland { get; set; }

        [JsonPropertyName("adresBuitenland")]
        public AdresBuitenland? AdresBuitenland { get; set; }

        public AdresNederland? GetAdresNederland() => AdresNederland;
    }

    // AdresNederland model
    public class AdresNederland
    {
        [JsonPropertyName("adresDetails")]
        public AdresNederlandAdresDetails? AdresDetails { get; set; }

        [JsonPropertyName("codeGemeente")]
        [RestrictedLengthString(4, 4)]
        public string? CodeGemeente { get; set; }

        [JsonPropertyName("district")]
        [RestrictedLengthString(24, 24)]
        public string? District { get; set; }

        [JsonPropertyName("gemeentedeel")]
        [RestrictedLengthString(4, 4)]
        public string? Gemeentedeel { get; set; }

        [JsonPropertyName("gemeentenaam")]
        [Name]
        public string? Gemeentenaam { get; set; }

        [JsonPropertyName("identificatiecodeNummeraanduiding")]
        [RestrictedLengthString(2, 2)]
        public string? IdentificatiecodeNummeraanduiding { get; set; }

        [JsonPropertyName("identificatiecodeVerblijfplaats")]
        [RestrictedLengthString(2, 2)]
        public string? IdentificatiecodeVerblijfplaats { get; set; }

        [JsonPropertyName("locatieomschrijving")]
        [Sentence]
        public string? Locatieomschrijving { get; set; }

        [JsonPropertyName("postcode")]
        [Postcode]
        public string? Postcode { get; set; }

        [JsonPropertyName("woonplaatsnaam")]
        [Name]
        public string? Woonplaatsnaam { get; set; }
    }

    // AdresNederlandAdresDetails model
    public class AdresNederlandAdresDetails
    {
        [JsonPropertyName("straatadres")]
        public Straatadres? Straatadres { get; set; }

        [JsonPropertyName("postbusadres")]
        public Postbusadres? Postbusadres { get; set; }

        [JsonPropertyName("antwoordnummeradres")]
        public Antwoordnummeradres? Antwoordnummeradres { get; set; }
    }

    // Antwoordnummeradres model
    public class Antwoordnummeradres
    {
        [JsonPropertyName("antwoordnummer")]
        [IntRange(1000, 10000)]
        public int? Antwoordnummer { get; set; }
    }

    // Postbusadres model
    public class Postbusadres
    {
        [JsonPropertyName("postbusnummer")]
        [IntRange(1000, 10000)]
        public int? Postbusnummer { get; set; }
    }

    // Straatadres model
    public class Straatadres
    {
        [JsonPropertyName("aanduidingBijHuisnummer")]
        [RestrictedLengthString(1, 1)]
        public string? AanduidingBijHuisnummer { get; set; }

        [JsonPropertyName("huisletter")]
        [RestrictedLengthString(1, 1)]
        public string? Huisletter { get; set; }

        [JsonPropertyName("huisnummer")]
        [IntRangeAttribute(1, 100, false)]
        public int? Huisnummer { get; set; }

        [JsonPropertyName("huisnummertoevoeging")]
        [RestrictedLengthString(1, 1)]
        public string? Huisnummertoevoeging { get; set; }

        [JsonPropertyName("naamOpenbareRuimte")]
        [Name]
        public string? NaamOpenbareRuimte { get; set; }

        [JsonPropertyName("straatnaam")]
        [Name]
        public string? Straatnaam { get; set; }

        [JsonPropertyName("woonbootverwijzing")]
        [OneOf("AB")]
        public string? Woonbootverwijzing { get; set; }

        [JsonPropertyName("woonwagenverwijzing")]
        [OneOf("WW")]
        public string? Woonwagenverwijzing { get; set; }
    }

    // AdresBuitenland model
    public class AdresBuitenland
    {
        [JsonPropertyName("adresDetailsBuitenland")]
        public AdresBuitenlandAdresDetailsBuitenland? AdresDetailsBuitenland { get; set; }

        [JsonPropertyName("landencodeIso")]
        [RestrictedLengthString(1, 2)]
        public string? LandencodeIso { get; set; }

        [JsonPropertyName("landsnaam")]
        [Name]
        public string? Landsnaam { get; set; }

        [JsonPropertyName("locatieomschrijvingBuitenland")]
        [RestrictedLengthString(5, 10)]
        public string? LocatieomschrijvingBuitenland { get; set; }

        [JsonPropertyName("postcodeBuitenland")]
        [Postcode]
        public string? PostcodeBuitenland { get; set; }

        [JsonPropertyName("regionaamBuitenland")]
        [Name]
        public string? RegionaamBuitenland { get; set; }

        [JsonPropertyName("woonplaatsnaamBuitenland")]
        [Name]
        public string? WoonplaatsnaamBuitenland { get; set; }
    }

    // AdresBuitenlandAdresDetailsBuitenland model
    public class AdresBuitenlandAdresDetailsBuitenland
    {
        [JsonPropertyName("straatadresbuitenland")]
        public StraatadresBuitenland? StraatadresBuitenland { get; set; }

        [JsonPropertyName("postbusadresbuitenland")]
        public PostbusadresBuitenland? PostbusadresBuitenland { get; set; }
    }

    // StraatadresBuitenland model
    public class StraatadresBuitenland
    {
        [JsonPropertyName("huisnummerBuitenland")]
        [RestrictedLengthString(1,9)]
        public string? HuisnummerBuitenland { get; set; }

        [JsonPropertyName("straatnaamBuitenland")]
        [Name]
        public string? StraatnaamBuitenland { get; set; }
    }

    // PostbusadresBuitenland model
    public class PostbusadresBuitenland
    {
        [JsonPropertyName("postbusnummerBuitenland")]
        [RestrictedLengthString(1, 9)]
        public string? PostbusnummerBuitenland { get; set; }
    }

    // WerkervaringVacature model
    public class WerkervaringVacature
    {
        [JsonPropertyName("aantalJarenWerkzaamInBeroep")]
        [IntRangeAttribute(0, 100, false)]
        public int? AantalJarenWerkzaamInBeroep { get; set; }
    }

    // MPOpleidingVacature model
    public class MPOpleidingVacature
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        [OneOf(1, 2, 3, 4, 5, 6, 9)]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        [OneOf(1, 2, 8)]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        [OneOfMPOpleidingsnaam]
        public MPOpleidingsnaam? Opleidingsnaam { get; set; }
    }    
    
    // OpleidingVacature model
    public class OpleidingVacature
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        [OneOf(1, 2, 3, 4, 5, 6, 9)]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        [OneOf(1, 2, 8)]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        [OneOfOpleidingsnaam]
        public Opleidingsnaam? Opleidingsnaam { get; set; }
    }

    // CursusVacature model
    public class CursusVacature
    {
        [JsonPropertyName("naamCursus")]
        public string? NaamCursus { get; set; }
    }

    // MobiliteitVacature model
    public class MobiliteitVacature
    {
        [JsonPropertyName("bemiddelingspostcode")]
        public string? Bemiddelingspostcode { get; set; }

        [JsonPropertyName("maximaleReisafstand")]
        public int? MaximaleReisafstand { get; set; }
    }
}