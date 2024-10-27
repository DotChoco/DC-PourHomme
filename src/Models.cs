
namespace DC_PourHomme.Models
{

    public enum ParfumType
    {
        EDP,
        PARFUM,
        EDT,
        COLOGNE,
        NONE
    }

    public enum ParfumAgeSegment
    {
        KIDS = default,
        MAN,
        DELUXE_MAN,
        OLD_MAN,
        ALL_AGES,
        NONE
    }
    
    public enum ParfumNotes
    {
        DESCONOCIDO = default,
        ALMISCLE,
        COSTOSO,
        MILLONARIO,
        CUERO,
        TABACO,
        AMBAR,
        MADERA,
        INCIENSO,
        OUD,
        BERGAMOTA,
        CARDAMOMO,
        PACHULI,
        CITRICOS,
        FRUTAL,
        MENTA,
        CIPRES,
        FRESCURA,
        HABA_TONKA,
        CAFE,
        DULCE,
        COCO,
        CREMOSURA,
        ACUATICO,
        MARINO,
        IRIS,
        PIMIENTA,
        NUEZ_MOSCADA,
        COMINO,
        ROMERO,
        SAL,
        LAVANDA,
        NONE
    }

    public enum Occasion
    {
        Dayly = default,
        CASUAL,
        SPORT,
        OFFICE,
        SPECIAL,
        FORMAL,
        PARTY,
        BEAST_MODE,
        NONE
    }

    public enum Season
    {
        SPRING = default,
        SUMMER,
        FALL,
        WINTER,
        HOT_SEASONS,
        COLD_SEASON,
        ALL_SEASONS,
        NONE
    }
    
    public class Brand
    {
        public string Name { get; set; } = "Unknown";
        public string Description { get; set; } = string.Empty;
    }

    public enum InCollection
    {
        NO,
        YES,
        PENDENT
    }

    public class Parfum
    {
        public string? Name { get; set; } = "Unknown";
        public string? Description { get; set; } = string.Empty;
        public string? Brand { get; set; } = "Unknown";
        public ParfumType? Type { get; set; }
        public List<ParfumNotes>? Notes { get; set; } = new();
        public ParfumAgeSegment? AgeSegment { get; set; } = ParfumAgeSegment.MAN;
        public Occasion? Occasion { get; set; } = Models.Occasion.NONE;
        public Season? Season { get; set; } = Models.Season.NONE;
        public InCollection? InCollection { get; set; } = Models.InCollection.NO;
        int? YearEdition { get; set; } = 2024;
    }

}
