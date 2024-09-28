
namespace DC_PourHomme.Models
{

    public enum ParfumType
    {
        EAU_DE_PARFUM,
        PARFUM,
        EAU_DE_TOILETTE,
        EAU_DE_COLOGNE,
        EAU_FRAICHE,
        NONE
    }

    public enum ParfumAgeSegment
    {
        KIDS = default,
        MAN,
        DELUXE_MAN,
        OLD_MAN,
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

    public class Parfum
    {
        public string Name { get; set; } = "Unknown";
        public string Description { get; set; } = string.Empty;
        public string OwnNote { get; set; } = string.Empty;
        public string Brand { get; set; } = "Unknown";
        public ParfumType Type { get; set; }
        public List<ParfumNotes> Notes { get; set; } = new();
        public ParfumAgeSegment AgeSegment { get; set; }
        public Occasion Occasion { get; set; }
        public Season Season { get; set; }
        int ReleaseYear { get; set; }
    }

}
