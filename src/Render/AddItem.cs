
using DC_PourHomme.Models;

namespace DC_PourHomme.Render
{
    public class AddItem
    {
        public static Parfum? NewParfum() => new AddItem().RenderForm();
        int BaseWith = 16;



        #region Bottles

        string bottleEmpty =
             "   ▒▒▒▒▒▓▒   \n" +
             "    ▒▒▒▒▒    \n" +
             "    ▒▒▒▒▒    \n" +
             "   ▒▒▒▒▒▒▒   \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             "▓▒▓▒▒▒▒▒▒▒▒▓▒";

        string bottleMin =
             "   ▒▒▒▒▒▓▒   \n" +
             "    ▒▒▒▒▒    \n" +
             "    ▒▒▒▒▒    \n" +
             "   ▒▒▒▒▒▒▒   \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             "▓▒▓▒▒▒▒▒▒▒▒▓▒";

        string bottleMed =
             "   ▒▒▒▒▒▓▒   \n" +
             "    ▒▒▒▒▒    \n" +
             "    ▒▒▒▒▒    \n" +
             "   ▒▒▒▒▒▒▒   \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             "▓▒▓▒▒▒▒▒▒▒▒▓▒";

        string bottleSemiFull =
             "   ▒▒▒▒▒▓▒   \n" +
             "    ▒▒▒▒▒    \n" +
             "    ▒▒▒▒▒    \n" +
             "   ▒▒▒▒▒▒▒   \n" +
             " ▒░░░░░░░░░▒ \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             "▓▒▓▒▒▒▒▒▒▒▒▓▒";

        string bottleFull =
             "   ▒▒▒▒▒▓▒   \n" +
             "    ▒▒▒▒▒    \n" +
             "    ▒▒▒▒▒    \n" +
             "   ▒▒▒▒▒▒▒   \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             " ▒▓▓▓▓▓▓▓▓▓▒  \n" +
             "▓▒▓▒▒▒▒▒▒▒▒▓▒";

        #endregion


        //string Name
        //string Description 
        //string OwnNote 
        //string Brand 
        //ParfumType Type 
        //List<ParfumNotes> Notes 
        //ParfumAgeSegment AgeSegment 
        //Occasion Occasion 
        //Season Season 
        //InCollection InCollection 
        private Parfum RenderForm()
        {
            Parfum? parfum = new();
            string? answer = string.Empty;


            RendeQuestion("Nombre de la Fragancia:", 1);
            parfum.Name = Console.ReadLine();


            RendeQuestion("Nombre de la Casa(Marca o Perfumeria):", 1);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.Brand = answer;
            else
                parfum.Brand = "Unknown";


            RendeQuestion("Da una descripcion corta de la fragancia(Sin Presionar 'Enter'):", 2);
            parfum.Description = Console.ReadLine();


            RendeQuestion("Tipo de Fragancia(EDP = 0 , PARFUM = 1, EDT = 2, COLOGNE = 3):", 2);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.Type = (ParfumType)int.Parse(answer);
            else
                parfum.Type = (ParfumType)int.Parse(((int)ParfumType.EDP).ToString());


            RendeQuestion("Segmento de Edad(KIDS = 0, MAN = 1, DELUXE_MAN = 2, OLD_MAN = 3, ALL_AGES = 4):", 3);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.AgeSegment = (ParfumAgeSegment)int.Parse(answer);
            else
                parfum.AgeSegment = (ParfumAgeSegment)int.Parse(((int)ParfumAgeSegment.MAN).ToString());


            RendeQuestion("Ocasion(Dayly = 0, CASUAL = 1, SPORT = 2, OFFICE = 3, SPECIAL = 4, FORMAL = 5, PARTY = 6, BEAST_MODE = 7):", 3);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.Occasion = (Occasion)int.Parse(answer);
            else
                parfum.Occasion = (Occasion)int.Parse(((int)Occasion.CASUAL).ToString());


            RendeQuestion("Temporada(SPRING = 0, SUMMER = 1, FALL = 2, WINTER = 3, HOT_SEASONS = 4, COLD_SEASON = 5, ALL_SEASONS = 6):", 4);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.Season = (Season)int.Parse(answer);
            else
                parfum.Season = (Season)int.Parse(((int)Season.HOT_SEASONS).ToString());


            RendeQuestion("Esta en la Colleccion(NO = 0, YES = 1, PENDENT = 2):", 4);
            answer = Console.ReadLine();
            if (answer != null && answer != string.Empty)
                parfum.InCollection = (InCollection)int.Parse(answer);
            else
                parfum.InCollection = (InCollection)int.Parse(((int)InCollection.NO).ToString());


            return parfum;
        }

        
        private void RendeQuestion(string Question, byte Bottle = 1)
        {
            int separator = 8;
            int height = 9;

            Console.WriteLine("\x1b[3J");
            Console.Clear();
            
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            switch (Bottle)
            {
                case 0: Console.Write(bottleEmpty); break;
                case 1: Console.Write(bottleMin); break;
                case 2: Console.Write(bottleMed); break;
                case 3: Console.Write(bottleSemiFull); break;
                case 4: Console.Write(bottleFull); break;
            } 
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(BaseWith, height);
            Console.Write($"\t{Question}");
            Console.SetCursorPosition(BaseWith + separator, height + 1);
        }

    }
}
