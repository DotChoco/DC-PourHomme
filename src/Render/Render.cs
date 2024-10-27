
namespace DC_PourHomme.Render
{
    using Backend;
    using Models;

    public class Render
    {
        Backend? backend = new();
        (int, int) pageIndexer = default;
        int pageDivisor = default;
        const string Separator = "|---------------------|---------------------|----------------|----------------|----------------|";
        const char Roof = (char)45;
        const char Wall = (char)124;
        const char Space = (char)32;
        const int Min_Page = 1;
        const int Small_Field_Spaces = 16;
        const byte Large_Field_Spaces = 21;
        const int ParfumsPerPage = 10;


        public static void Init() => new Render().MainPage();

        public void MainPage()
        {
            Console.CursorVisible = false;
            Console.Title = "Pour Homme";
            Console.Clear();
            //Spaces:   21                    21                  16               16
            //|---------------------|---------------------|----------------|----------------|
            //|        Name         |        Brand        |     Season     |    Occasion    |
            //|---------------------|---------------------|----------------|----------------|
            //|---------------------|---------------------|----------------|----------------|
            //|  Le Male Le Parfum  |      Jean Paul      |  Cold_Seasons  |    Party &     |
            //|Eau De Parfum Intense|       Gultier       |                |    BeastMode   |
            //|---------------------|---------------------|----------------|----------------|
            //|     Aqua Di Gio     |    Gorgio Armani    |   Hot_Seasons  |    Party &     |
            //|   Profondo Parfum   |                     |                |    BeastMode   |
            //|---------------------|---------------------|----------------|----------------|
            Title();
            PrintControls();
            TableHead();

            //TestMultipleItems();

            

            LoadTable();
            PrintPageNumber();
            //backend.dataBase.Parfums = new();
            MainPageInputRaw();

        }


        private string FormatItemLine()
        {
                return Wall + FormatText("Name") + Wall + FormatText("Brand")
                    + Wall + FormatText("Season", Small_Field_Spaces) 
                    + Wall + FormatText("Occasion", Small_Field_Spaces)
                    + Wall + FormatText("InCollection", Small_Field_Spaces) + Wall;
        }

        private string FormatText(string data, byte fieldSpaces = Large_Field_Spaces)
        {
            int freeSpaces = fieldSpaces - data.Length;
            string restData = string.Empty;

            if (data == string.Empty || data == null)
                return new string(Space, fieldSpaces);
           
            if (freeSpaces % 2 == 0)
                return new string(Space, freeSpaces / 2) + data + new string(Space, freeSpaces / 2);
            return new string(Space, freeSpaces / 2) + data + new string(Space, (freeSpaces + 1) / 2);
        }

        private void Title()
        {
            string title =
               "   ▒░▒░░▓▒         \n" +
               "    █░░░░          \n" +
               "    █░░░░          \n" +
               "   ██▒░░▒██        \n" +
               " ██▓▒░░░░▒▓▓█      \n" +
               " ░▓▒░▒▒▒░▒▓▓░      \n" +
               " ░▓▒█▒░░░▒▓▓░        ____    ___   __ __ ____     __  __   ___   ___  ___ ___  ___  ____\n" +
              @" ░▓▒░▒  ░░▒▓░        || \\  // \\  || || || \\    ||  ||  // \\  ||\\//|| ||\\//|| ||     " + "\n" +
              @" ░▓▒░░░ ░░▒▓░        ||_// ((   )) || || ||_//    ||==|| ((   )) || \/ || || \/ || ||==   " + "\n" + 
              @" ░▒▒░░░░░░▒▓░        ||     \\_//  \\_// || \\    ||  ||  \\_//  ||    || ||    || ||___  " + "\n" +
               "█▓█▓░░░░░▒██▓█      \n\n\n";

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n" + title);
            Console.ForegroundColor = ConsoleColor.White;


        }

        private void PrintControls(bool SearchPage = false)
        {
            string addItem = "[A/a] Add Item";
            string searchItem = "[S/s] Search Item";
            string viewItem = "[Enter] View Item";
            string deleteItem = "[D/d] Delete Item";
            string updateItem = "[U/u] Update Item";
            string exit = "[E/e] Exit";

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (!SearchPage)
                Console.WriteLine($"\n\t   {addItem}\t{searchItem}\t{exit}\n");
            else
                Console.WriteLine($"\n\t\t{viewItem}\t{deleteItem}\t{updateItem}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    
        private void TableHead()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Separator);
            Console.WriteLine(FormatItemLine());
            Console.WriteLine(Separator);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Separator);
        }
        
        private void PrintParfumes(Parfum data, byte fieldSpaces = Large_Field_Spaces)
        {
            int freeSpaces = fieldSpaces - data.Name.Length,
                counter = default;
            string result = Wall.ToString();
            Tuple<Tuple<string, string>, bool>? tupleName = new(new(string.Empty,string.Empty),false),
                                                tupleBrand = new(new(string.Empty, string.Empty), false);


            tupleName = FormatParfumeData(data.Name);
            tupleBrand = FormatParfumeData(data.Brand);

            result += tupleName.Item1.Item1 + Wall;
            result += tupleBrand.Item1.Item1 + Wall;
            result += FormatText(data.Season.ToString(), Small_Field_Spaces) + Wall;
            result += FormatText(data.Occasion.ToString(), Small_Field_Spaces) + Wall;
            result += FormatText(data.InCollection.ToString(), Small_Field_Spaces) + Wall;

            while(true)
            {
                if (tupleName.Item2)
                    tupleName = FormatParfumeData(tupleName.Item1.Item2);
                else
                    tupleName = new(new(string.Empty,string.Empty),false);

                if(tupleBrand.Item2)
                    tupleBrand = FormatParfumeData(tupleBrand.Item1.Item2);
                else
                    tupleBrand = new(new(string.Empty, string.Empty), false);



                if (!tupleBrand.Item2 && !tupleName.Item2 
                    && (tupleName.Item1.Item1 == null || tupleName.Item1.Item1 == string.Empty)
                    && (tupleBrand.Item1.Item1 == null || tupleBrand.Item1.Item1 == string.Empty))
                    break;
                result += "\n" + Wall;

                
                
                if (tupleName.Item2 || counter == 0 || tupleName.Item1.Item1 != string.Empty)
                    result += tupleName.Item1.Item1 + Wall;
                else 
                    result += FormatText(string.Empty) + Wall;

                if (tupleBrand.Item2 || counter == 0 || tupleBrand.Item1.Item1 != string.Empty)
                    result += tupleBrand.Item1.Item1 + Wall;
                else 
                    result += FormatText(string.Empty) + Wall;



                result += FormatText(string.Empty, Small_Field_Spaces) + Wall;
                result += FormatText(string.Empty, Small_Field_Spaces) + Wall;
                result += FormatText(string.Empty, Small_Field_Spaces) + Wall;
                counter++;
                if (!tupleBrand.Item2 && !tupleName.Item2)
                    break;
            }


            Console.WriteLine(result);
            Console.WriteLine(Separator);
        }

        private Tuple<Tuple<string, string>, bool> FormatParfumeData(string data, byte fieldSpaces = Large_Field_Spaces)
        {
            string restData = string.Empty, newdata = string.Empty;
            int freeSpaces = fieldSpaces - data.Length;
            if (freeSpaces < 0)
            {
                for (byte i = fieldSpaces; i > 0; i--)
                {
                    if (data[i] == Space)
                    {
                        for (int j = i + 1; j < data.Length; j++)
                        {
                            restData += data[j];
                        }
                        for (int h = 0; h < i; h++)
                        {
                            newdata += data[h];
                        }

                        if (newdata[newdata.Length - 1] == Space)
                            newdata = newdata.Remove(data.Length - 1);

                        if (newdata.Length < fieldSpaces)
                        {
                            freeSpaces = fieldSpaces - newdata.Length;
                            if (freeSpaces % 2 == 0)
                                return new(new(new string(Space, freeSpaces / 2) + newdata + new string(Space, freeSpaces / 2), restData), true);
                            else
                                return new(new(new string(Space, freeSpaces / 2) + newdata + new string(Space, (freeSpaces + 1) / 2), restData), true);
                        }
                        return new(new(newdata, restData), true);
                    }
                }
            }

            if (freeSpaces % 2 == 0)
                return new(new(new string(Space, freeSpaces / 2) + data + new string(Space, freeSpaces / 2), restData), false);
            return new(new(new string(Space, freeSpaces / 2) + data + new string(Space, (freeSpaces + 1) / 2), restData), false);
        }

        private void PrintPage(Tuple<int, int> startEndIndexes)
        {
            for (int i = startEndIndexes.Item1; i < startEndIndexes.Item2; i++)
            {
                PrintParfumes(backend.dataBase.Parfums[i]);
            }
        }

        private void PrintPageNumber()
        {
            Console.WriteLine($"\n\t\t\t\t\t\t{pageIndexer.Item1} / {pageIndexer.Item2}");
        }

        private void MainPageInputRaw()
        {
            int index = default; 
            ConsoleKey? input = default;
            while (true)
            {
                input = Console.ReadKey().Key;

                Console.WriteLine("\x1b[3J");
                Console.Clear();

                if (input == ConsoleKey.E)
                    break;
                if (input == ConsoleKey.S)
                {
                    //Title();
                    //PrintControls(true);
                    backend.dataBase.Parfums = SearchItem.Search(backend.dataBase.Parfums);
                }
                if (input == ConsoleKey.A)
                {
                    Parfum data = AddItem.NewParfum();
                    if (data != null)
                        backend.AddItem(data);
                    Title();
                    PrintControls();
                    TableHead();
                    if (index == null || index == 0)
                        LoadTable();
                    else
                    {
                        if (pageIndexer.Item1 == pageIndexer.Item2)
                            PrintPage(new(index - ParfumsPerPage, backend.dataBase.Parfums.Count));
                        else
                            PrintPage(new(index - ParfumsPerPage, index));
                    }

                    PrintPageNumber();
                }
                if (input == ConsoleKey.LeftArrow)
                {
                    if(pageIndexer.Item1 > Min_Page)
                    {
                        Title();
                        PrintControls();
                        TableHead();
                        pageIndexer.Item1--;
                        index = pageIndexer.Item1 * ParfumsPerPage;
                        PrintPage(new(index - ParfumsPerPage, index));
                        PrintPageNumber();
                    }
                }
                if (input == ConsoleKey.RightArrow)
                {
                    if (pageIndexer.Item1 < pageIndexer.Item2)
                    {
                        Title();
                        PrintControls();
                        TableHead();
                        pageIndexer.Item1++;
                        index = pageIndexer.Item1 * ParfumsPerPage;
                        
                        if (pageIndexer.Item1 == pageIndexer.Item2)
                            PrintPage(new(index - ParfumsPerPage, backend.dataBase.Parfums.Count));
                        else
                            PrintPage(new(index - ParfumsPerPage, index ));

                        PrintPageNumber();
                    }
                }

            }

        }

        private void LoadTable()
        {
            if (backend.dataBase.Parfums != null)
            {
                if (backend.dataBase.Parfums.Count <= ParfumsPerPage)
                {
                    pageIndexer = new(Min_Page, Min_Page);
                    PrintPage(new(Min_Page - 1, backend.dataBase.Parfums.Count));
                }
                else
                {
                    pageIndexer = new(Min_Page, (backend.dataBase.Parfums.Count + ParfumsPerPage - 1) / ParfumsPerPage);
                    PrintPage(new(Min_Page - 1, ParfumsPerPage));
                }
            }
        }

    }

}
