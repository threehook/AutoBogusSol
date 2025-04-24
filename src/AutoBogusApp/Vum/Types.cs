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
        [OneOf("B", "O")]
        public string? CodeTypeArbeidscontract { get; set; }

        [JsonPropertyName("codeTypeOvereenkomst")]
        [OneOf("01", "02", "03", "04")]
        public string? CodeTypeOvereenkomst { get; set; }
    }

    // Cursus model
    public class Cursus
    {
        [JsonPropertyName("datumAanvangVolgenCursus")]
        [FormattedDate]
        public string? DatumAanvangVolgenCursus { get; set; }

        [JsonPropertyName("datumCertificaat")]
        [FormattedDate]
        public string? DatumCertificaat { get; set; }

        [JsonPropertyName("datumEindeVolgenCursus")]
        [FormattedDate]
        public string? DatumEindeVolgenCursus { get; set; }

        [JsonPropertyName("naamCursus")]
        [Name]
        public string? NaamCursus { get; set; }
        [Name]
        [JsonPropertyName("naamOpleidingsinstituut")]
        public string? NaamOpleidingsinstituut { get; set; }
    }

    // Flexibiliteit model
    public class Flexibiliteit
    {
        [JsonPropertyName("codeRegiostraal")]
        [IntRangeAttribute(1, 9, false)]
        public int? CodeRegiostraal { get; set; }

        [JsonPropertyName("datumAanvangBeschikbaarVoorWerk")]
        [FormattedDate]
        public string? DatumAanvangBeschikbaarVoorWerk { get; set; }

        [JsonPropertyName("datumEindeBeschikbaarVoorWerk")]
        [FormattedDate]
        public string? DatumEindeBeschikbaarVoorWerk { get; set; }

        [JsonPropertyName("indicatieOnregelmatigWerkOfPloegendienst")]
        [OneOf(0, 1, 2)]
        public int? IndicatieOnregelmatigWerkOfPloegendienst { get; set; }
    }

    // Gedragscompetentie model
    public class Gedragscompetentie
    {
        [JsonPropertyName("codeBeheersingGedragscompetentie")]
        [OneOf(1, 2, 3, 4, 5, 9)]
        public int? CodeBeheersingGedragscompetentie { get; set; }

        [JsonPropertyName("codeGedragscompetentie")]
        [OneOf("24100", "24101", "24102", "24104", "24105", "24106", "24107", "24108", "24109", "24110", "24111", "24112", "24113", "24114", "24115", "24116", "24118", "24119", "24120", "24121", "24122", "24123", "24124", "24125", "24126")]
        public string? CodeGedragscompetentie { get; set; }

        [JsonPropertyName("omschrijvingGedragscompetentie")]
        [OneOf("Beslissen en activiteiten initiëren", "Aansturen Begeleiden", "Aandacht en begrip tonen",
            "Samenwerken en overleggen", "Ethisch en integer handelen", "Relaties bouwen en netwerken",
            "Overtuigen en beïnvloeden", "Presenteren", "Formuleren en rapporteren", "Vakdeskundigheid toepassen",
            "Materialen en middelen inzetten", "Analyseren", "Onderzoeken", "Creeren en innoveren", "Leren",
            "Plannen en organiseren", "Op de behoeften en verwachtingen van de klant richten", "Kwaliteit leveren",
            "Instructies en procedures opvolgen", "Omgaan met verandering en aanpassen", "Met druk en tegenslag omgaan",
            "Gedrevenheid en ambitie tonen", "Ondernemend en commercieel handelen", "Bedrijfsmatig handelen")]
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
        [OneOf("A", "A1", "A2", "AM", "B", "B+", "C1", "C", "D1", "D", "BE", "C1E", "CE", "D1E", "DE", "T")]
        public string? CodeSoortRijbewijs { get; set; }
    }

    // SectorBeroepsEnBedrijfsleven model
    public class SectorBeroepsEnBedrijfsleven
    {
        [JsonPropertyName("codeSbi")]
        [IntRangeAttribute(0, 99999, false)]
        public int? CodeSbi { get; set; }
    }

    // Taalbeheersing model
    public class Taalbeheersing
    {
        [JsonPropertyName("codeNiveauTaalbeheersingLezen")]
        [OneOf(0, 1, 2, 3, 4, 8)]
        public int? CodeNiveauTaalbeheersingLezen { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingLuisteren")]
        [OneOf(0, 1, 2, 3, 4, 8)]
        public int? CodeNiveauTaalbeheersingLuisteren { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingMondeling")]
        [OneOf(0, 1, 2, 3, 4, 8)]
        public int? CodeNiveauTaalbeheersingMondeling { get; set; }
        
        [JsonPropertyName("codeNiveauTaalbeheersingSchriftelijk")]
        [OneOf(0, 1, 2, 3, 4, 8)]
        public int? CodeNiveauTaalbeheersingSchriftelijk { get; set; }
        
        [JsonPropertyName("codeTaal")]
        [CodeTaal]
        public string? CodeTaal { get; set; }
    }

    // Vakvaardigheid model
    public class Vakvaardigheid
    {
        [JsonPropertyName("omschrijving")]
        [Sentence]
        public string? Omschrijving { get; set; }
    }

    // Werkervaring model
    public class Werkervaring
    {
        [JsonPropertyName("beroep")]
        [OneOfBeroepsnaam]
        public Beroepsnaam? Beroep { get; set; }

        [JsonPropertyName("datumAanvangWerkzaamheden")]
        [FormattedDate]
        public string? DatumAanvangWerkzaamheden { get; set; }

        [JsonPropertyName("datumEindeWerkzaamheden")]
        [FormattedDate]
        public string? DatumEindeWerkzaamheden { get; set; }

        [JsonPropertyName("naamOrganisatie")]
        [Name]
        public string? NaamOrganisatie { get; set; }

        [JsonPropertyName("toelichtingWerkervaring")]
        public string? ToelichtingWerkervaring { get; set; }
    }

    // Werktijden model
    public class Werktijden
    {
        [JsonPropertyName("aantalWerkurenPerWeekMaximaal")]
        [IntRange(0, 99)]
        public int? AantalWerkurenPerWeekMaximaal { get; set; }

        [JsonPropertyName("aantalWerkurenPerWeekMinimaal")]
        [IntRange(0, 99)]
        public int? AantalWerkurenPerWeekMinimaal { get; set; }

        [JsonPropertyName("indicatieKantoortijden")]
        [OneOf(0, 1, 2)]
        public int? IndicatieKantoortijden { get; set; }
    }

    // Webadres model
    public class Webadres
    {
        [JsonPropertyName("codeWebadres")]
        [OneOf(1, 2)]
        public int? CodeWebadres { get; set; }

        [JsonPropertyName("url")]
        [WebUrl]
        public string? Url { get; set; }
    }

    // Vervoermiddel model
    public class Vervoermiddel
    {
        [JsonPropertyName("codeVervoermiddel")]
        [OneOf(1, 2, 3, 4, 5, 9)]
        public int? CodeVervoermiddel { get; set; }

        [JsonPropertyName("indicatieBeschikbaarVoorUitvoeringWerk")]
        [OneOf(0, 1, 2)]
        public int? IndicatieBeschikbaarVoorUitvoeringWerk { get; set; }

        [JsonPropertyName("indicatieBeschikbaarVoorWoonWerkverkeer")]
        [OneOf(0, 1, 2)]
        public int? IndicatieBeschikbaarVoorWoonWerkverkeer { get; set; }
    }
}