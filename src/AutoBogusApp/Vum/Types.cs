using System.Text.Json.Serialization;

namespace AutoBogusApp.Vum
{
    // Beroepsnaam model
    public class Beroepsnaam
    {
        [JsonPropertyName("beroepsnaamGecodeerd")]
        public BeroepsnaamGecodeerd? BeroepsnaamGecodeerd { get; set; }

        [JsonPropertyName("beroepsnaamOngecodeerd")]
        public BeroepsnaamOngecodeerd? BeroepsnaamOngecodeerd { get; set; }
    }

    // BeroepsnaamGecodeerd model
    public class BeroepsnaamGecodeerd
    {
        [JsonPropertyName("codeBeroepsnaam")]
        public string? CodeBeroepsnaam { get; set; }

        [JsonPropertyName("omschrijvingBeroepsnaam")]
        public string? OmschrijvingBeroepsnaam { get; set; }
    }

    // BeroepsnaamOngecodeerd model
    public class BeroepsnaamOngecodeerd
    {
        [JsonPropertyName("naamBeroepOngecodeerd")]
        public string? NaamBeroepOngecodeerd { get; set; }
    }

    // Contractvorm model
    public class Contractvorm
    {
        [JsonPropertyName("codeTypeArbeidscontract")]
        public string? CodeTypeArbeidscontract { get; set; }

        [JsonPropertyName("codeTypeOvereenkomst")]
        public string? CodeTypeOvereenkomst { get; set; }
    }

    // Cursus model
    public class Cursus
    {
        [JsonPropertyName("datumAanvangVolgenCursus")]
        public string? DatumAanvangVolgenCursus { get; set; }

        [JsonPropertyName("datumCertificaat")]
        public string? DatumCertificaat { get; set; }

        [JsonPropertyName("datumEindeVolgenCursus")]
        public string? DatumEindeVolgenCursus { get; set; }

        [JsonPropertyName("naamCursus")]
        public string? NaamCursus { get; set; }
        
        [JsonPropertyName("naamOpleidingsinstituut")]
        public string? NaamOpleidingsinstituut { get; set; }
    }

    // Flexibiliteit model
    public class Flexibiliteit
    {
        [JsonPropertyName("codeRegiostraal")]
        public int? CodeRegiostraal { get; set; }

        [JsonPropertyName("datumAanvangBeschikbaarVoorWerk")]
        public string? DatumAanvangBeschikbaarVoorWerk { get; set; }

        [JsonPropertyName("datumEindeBeschikbaarVoorWerk")]
        public string? DatumEindeBeschikbaarVoorWerk { get; set; }

        [JsonPropertyName("indicatieOnregelmatigWerkOfPloegendienst")]
        public int? IndicatieOnregelmatigWerkOfPloegendienst { get; set; }
    }

    // Gedragscompetentie model
    public class Gedragscompetentie
    {
        [JsonPropertyName("codeBeheersingGedragscompetentie")]
        public int? CodeBeheersingGedragscompetentie { get; set; }

        [JsonPropertyName("codeGedragscompetentie")]
        public string? CodeGedragscompetentie { get; set; }

        [JsonPropertyName("omschrijvingGedragscompetentie")]
        public string? OmschrijvingGedragscompetentie { get; set; }
    }

    // MPOpleidingsnaam model
    public class MPOpleidingsnaam
    {
        [JsonPropertyName("opleidingsnaamGecodeerd")]
        public OpleidingsnaamGecodeerd? OpleidingsnaamGecodeerd { get; set; }

        [JsonPropertyName("opleidingsnaamOngecodeerd")]
        public MPOpleidingsnaamOngecodeerd? OpleidingsnaamOngecodeerd { get; set; }
    }    
    
    // Opleidingsnaam model
    public class Opleidingsnaam
    {
        [JsonPropertyName("opleidingsnaamGecodeerd")]
        public OpleidingsnaamGecodeerd? OpleidingsnaamGecodeerd { get; set; }

        [JsonPropertyName("opleidingsnaamOngecodeerd")]
        public OpleidingsnaamOngecodeerd? OpleidingsnaamOngecodeerd { get; set; }
    }

    // OpleidingsnaamGecodeerd model
    public class OpleidingsnaamGecodeerd
    {
        [JsonPropertyName("codeOpleidingsnaam")]
        public string? CodeOpleidingsnaam { get; set; }

        [JsonPropertyName("omschrijvingOpleidingsnaam")]
        public string? OmschrijvingOpleidingsnaam { get; set; }
    }

    // OpleidingsnaamOngecodeerd model
    public class OpleidingsnaamOngecodeerd
    {
        [JsonPropertyName("naamOpleidingOngecodeerd")]
        public string? NaamOpleidingOngecodeerd { get; set; }

        [JsonPropertyName("omschrijvingOpleiding")]
        public string? OmschrijvingOpleiding { get; set; }
    }
    
    // MPOpleidingsnaamOngecodeerd model
    public class MPOpleidingsnaamOngecodeerd
    {
        [JsonPropertyName("naamOpleidingOngecodeerd")]
        public string? NaamOpleidingOngecodeerd { get; set; }
    }    

    // Rijbewijs model
    public class Rijbewijs
    {
        [JsonPropertyName("codeSoortRijbewijs")]
        public string? CodeSoortRijbewijs { get; set; }
    }

    // SectorBeroepsEnBedrijfsleven model
    public class SectorBeroepsEnBedrijfsleven
    {
        [JsonPropertyName("codeSbi")]
        public int? CodeSbi { get; set; }
    }

    // Taalbeheersing model
    public class Taalbeheersing
    {
        [JsonPropertyName("codeNiveauTaalbeheersingLezen")]
        public int? CodeNiveauTaalbeheersingLezen { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingLuisteren")]
        public int? CodeNiveauTaalbeheersingLuisteren { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingMondeling")]
        public int? CodeNiveauTaalbeheersingMondeling { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingSchriftelijk")]
        public int? CodeNiveauTaalbeheersingSchriftelijk { get; set; }
        
        [JsonPropertyName("codeTaal")]
        public string? CodeTaal { get; set; }
    }

    // Vakvaardigheid model
    public class Vakvaardigheid
    {
        [JsonPropertyName("omschrijving")]
        public string? Omschrijving { get; set; }
    }

    // Werkervaring model
    public class Werkervaring
    {
        [JsonPropertyName("beroep")]
        public Beroepsnaam? Beroep { get; set; }

        [JsonPropertyName("datumAanvangWerkzaamheden")]
        public string? DatumAanvangWerkzaamheden { get; set; }

        [JsonPropertyName("datumEindeWerkzaamheden")]
        public string? DatumEindeWerkzaamheden { get; set; }

        [JsonPropertyName("naamOrganisatie")]
        public string? NaamOrganisatie { get; set; }

        [JsonPropertyName("toelichtingWerkervaring")]
        public string? ToelichtingWerkervaring { get; set; }
    }

    // Werktijden model
    public class Werktijden
    {
        [JsonPropertyName("aantalWerkurenPerWeekMaximaal")]
        public int? AantalWerkurenPerWeekMaximaal { get; set; }

        [JsonPropertyName("aantalWerkurenPerWeekMinimaal")]
        public int? AantalWerkurenPerWeekMinimaal { get; set; }

        [JsonPropertyName("indicatieKantoortijden")]
        public int? IndicatieKantoortijden { get; set; }
    }

    // Webadres model
    public class Webadres
    {
        [JsonPropertyName("codeWebadres")]
        public int? CodeWebadres { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }

    // Vervoermiddel model
    public class MpVervoermiddel
    {
        [JsonPropertyName("indicatieBeschikbaarVoorUitvoeringWerk")]
        public int? IndicatieBeschikbaarVoorUitvoeringWerk { get; set; }

        [JsonPropertyName("indicatieBeschikbaarVoorWoonWerkverkeer")]
        public int? IndicatieBeschikbaarVoorWoonWerkverkeer { get; set; }
    }    
    
    // Vervoermiddel model
    public class Vervoermiddel
    {
        [JsonPropertyName("codeVervoermiddel")]
        public int? CodeVervoermiddel { get; set; }

        [JsonPropertyName("indicatieBeschikbaarVoorUitvoeringWerk")]
        public int? IndicatieBeschikbaarVoorUitvoeringWerk { get; set; }

        [JsonPropertyName("indicatieBeschikbaarVoorWoonWerkverkeer")]
        public int? IndicatieBeschikbaarVoorWoonWerkverkeer { get; set; }
    }
}