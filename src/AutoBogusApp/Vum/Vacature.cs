using System.Text.Json.Serialization;

namespace AutoBogusApp.Vum
{
    public class MPVacatureMatch
    {
        [JsonPropertyName("arbeidsVoorwaarden")]
        public ArbeidsVoorwaarden? ArbeidsVoorwaarden { get; set; }

        [JsonPropertyName("beroep")]
        public Beroepsnaam? Beroep { get; set; }
       
        [JsonPropertyName("codeWerkEnDenkniveauMinimaal")]
        public string? CodeWerkEnDenkniveauMinimaal { get; set; }

        [JsonPropertyName("contractvorm")]
        public List<Contractvorm>? Contractvorm { get; set; }

        [JsonPropertyName("cursus")]
        public List<CursusVacature>? Cursus { get; set; }

        [JsonPropertyName("mobiliteit")]
        public MobiliteitVacature? Mobiliteit { get; set; }        
        
        [JsonPropertyName("flexibiliteit")]
        public Flexibiliteit? Flexibiliteit { get; set; }

        [JsonPropertyName("gedragscompetentie")]
        public List<Gedragscompetentie>? Gedragscompetentie { get; set; }

        [JsonPropertyName("idVacature")]
        public string? IdVacature { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("opleiding")]
        public List<MPOpleidingVacature>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("sector")]
        public SectorBeroepsEnBedrijfsleven? Sector { get; set; }

        [JsonPropertyName("sluitingsdatumVacature")]
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
        public Beroepsnaam? Beroep { get; set; }
       
        [JsonPropertyName("codeWerkEnDenkniveauMinimaal")]
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
        public string? IdVacature { get; set; }

        [JsonPropertyName("indicatieLdrRegistratie")]
        public int? IndicatieLdrRegistratie { get; set; }

        [JsonPropertyName("naamVacature")]
        public string? NaamVacature { get; set; }

        [JsonPropertyName("nummerVacature")]
        public string? NummerVacature { get; set; }

        [JsonPropertyName("omschrijvingVacature")]
        public string? OmschrijvingVacature { get; set; }

        [JsonPropertyName("opleiding")]
        public List<OpleidingVacature>? Opleiding { get; set; }

        [JsonPropertyName("rijbewijs")]
        public List<Rijbewijs>? Rijbewijs { get; set; }

        [JsonPropertyName("sector")]
        public SectorBeroepsEnBedrijfsleven? Sector { get; set; }

        [JsonPropertyName("sluitingsdatumVacature")]
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
        public string? DatumAanvangWerkzaamheden { get; set; }

        [JsonPropertyName("datumEindeWerkzaamheden")]
        public string? DatumEindeWerkzaamheden { get; set; }

        [JsonPropertyName("omschrijvingArbeidsvoorwaarden")]
        public string? OmschrijvingArbeidsvoorwaarden { get; set; }

        [JsonPropertyName("salarisIndicatie")]
        public string? SalarisIndicatie { get; set; }
    }

    // Sollicitatiewijze model
    public class Sollicitatiewijze
    {
        [JsonPropertyName("codeSollicitatiewijze")]
        public string? CodeSollicitatiewijze { get; set; }

        [JsonPropertyName("webadres")]
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
        public string? CodeFunctieAdres { get; set; }

        [JsonPropertyName("datumAanvangAdres")]
        public string? DatumAanvangAdres { get; set; }

        [JsonPropertyName("datumEindeAdres")]
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
    }

    // AdresNederland model
    public class AdresNederland
    {
        [JsonPropertyName("adresDetails")]
        public AdresNederlandAdresDetails? AdresDetails { get; set; }

        [JsonPropertyName("codeGemeente")]
        public string? CodeGemeente { get; set; }

        [JsonPropertyName("district")]
        public string? District { get; set; }

        [JsonPropertyName("gemeentedeel")]
        public string? Gemeentedeel { get; set; }

        [JsonPropertyName("gemeentenaam")]
        public string? Gemeentenaam { get; set; }

        [JsonPropertyName("identificatiecodeNummeraanduiding")]
        public string? IdentificatiecodeNummeraanduiding { get; set; }

        [JsonPropertyName("identificatiecodeVerblijfplaats")]
        public string? IdentificatiecodeVerblijfplaats { get; set; }

        [JsonPropertyName("locatieomschrijving")]
        public string? Locatieomschrijving { get; set; }

        [JsonPropertyName("postcode")]
        public string? Postcode { get; set; }

        [JsonPropertyName("woonplaatsnaam")]
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
        public int? Antwoordnummer { get; set; }
    }

    // Postbusadres model
    public class Postbusadres
    {
        [JsonPropertyName("postbusnummer")]
        public int? Postbusnummer { get; set; }
    }

    // Straatadres model
    public class Straatadres
    {
        [JsonPropertyName("aanduidingBijHuisnummer")]
        public string? AanduidingBijHuisnummer { get; set; }

        [JsonPropertyName("huisletter")]
        public string? Huisletter { get; set; }

        [JsonPropertyName("huisnummer")]
        public int? Huisnummer { get; set; }

        [JsonPropertyName("huisnummertoevoeging")]
        public string? Huisnummertoevoeging { get; set; }

        [JsonPropertyName("naamOpenbareRuimte")]
        public string? NaamOpenbareRuimte { get; set; }

        [JsonPropertyName("straatnaam")]
        public string? Straatnaam { get; set; }

        [JsonPropertyName("woonbootverwijzing")]
        public string? Woonbootverwijzing { get; set; }

        [JsonPropertyName("woonwagenverwijzing")]
        public string? Woonwagenverwijzing { get; set; }
    }

    // AdresBuitenland model
    public class AdresBuitenland
    {
        [JsonPropertyName("adresDetailsBuitenland")]
        public AdresBuitenlandAdresDetailsBuitenland? AdresDetailsBuitenland { get; set; }

        [JsonPropertyName("landencodeIso")]
        public string? LandencodeIso { get; set; }

        [JsonPropertyName("landsnaam")]
        public string? Landsnaam { get; set; }

        [JsonPropertyName("locatieomschrijvingBuitenland")]
        public string? LocatieomschrijvingBuitenland { get; set; }

        [JsonPropertyName("postcodeBuitenland")]
        public string? PostcodeBuitenland { get; set; }

        [JsonPropertyName("regionaamBuitenland")]
        public string? RegionaamBuitenland { get; set; }

        [JsonPropertyName("woonplaatsnaamBuitenland")]
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
        public string? HuisnummerBuitenland { get; set; }

        [JsonPropertyName("straatnaamBuitenland")]
        public string? StraatnaamBuitenland { get; set; }
    }

    // PostbusadresBuitenland model
    public class PostbusadresBuitenland
    {
        [JsonPropertyName("postbusnummerBuitenland")]
        public string? PostbusnummerBuitenland { get; set; }
    }

    // WerkervaringVacature model
    public class WerkervaringVacature
    {
        [JsonPropertyName("aantalJarenWerkzaamInBeroep")]
        public int? AantalJarenWerkzaamInBeroep { get; set; }
    }

    // MPOpleidingVacature model
    public class MPOpleidingVacature
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("opleidingsnaam")]
        public MPOpleidingsnaam? Opleidingsnaam { get; set; }
    }    
    
    // OpleidingVacature model
    public class OpleidingVacature
    {
        [JsonPropertyName("codeNiveauOpleiding")]
        public int? CodeNiveauOpleiding { get; set; }

        [JsonPropertyName("indicatieDiploma")]
        public int? IndicatieDiploma { get; set; }

        [JsonPropertyName("opleidingsnaam")]
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