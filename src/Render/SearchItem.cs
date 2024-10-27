

using DC_PourHomme.Models;
using System.Text;
using System.Threading.Channels;

namespace DC_PourHomme.Render
{
    public class SearchItem
    {
        List<Parfum> Data = new();
        public static List<Parfum> Search(List<Parfum> parfums) => new SearchItem().Render(parfums);


        private List<Parfum> Render(List<Parfum> parfums)
        {
            RenderSearchBar(parfums);
            return Data;
            //RenderControls();
        }


        private void RenderSearchBar(List<Parfum> parfums)
        {
            StringBuilder? sb = new();
            ConsoleKey? key;
            int ItemHeight = 5;
            int ItemWight = 11;
            List<string> parfumsPrinted = new();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");

            Console.SetCursorPosition(2, 2);
            Console.WriteLine("│Search:                                                       │");

            Console.SetCursorPosition(2, 3);
            Console.WriteLine("└──────────────────────────────────────────────────────────────┘");

            Console.SetCursorPosition(ItemWight, 2);
            while (true)
            {
                key = Console.ReadKey(true).Key;
                Console.SetCursorPosition(ItemWight, 2);
                if (key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    // Eliminar el último carácter del StringBuilder
                    sb.Remove(sb.Length - 1, 1);

                    // Mover el cursor una posición hacia atrás
                    int cursorPos = Console.CursorLeft;
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);

                    // Sobrescribir el último carácter con un espacio en blanco
                    Console.Write(" ");

                    // Mover el cursor de nuevo una posición hacia atrás para estar listo para más entrada
                    Console.SetCursorPosition(cursorPos - 1, Console.CursorTop);
                    ItemWight--;
                    foreach (var parfum in parfumsPrinted)
                    {
                        if (!parfum.ToLower().Contains(sb.ToString().ToLower())
                            && (sb.ToString() != null && sb.ToString() != string.Empty))
                        {
                            parfumsPrinted.Remove(parfum);
                            ItemHeight--;
                        }
                    }
                }
                else if (IsNotAControl(key.Value))
                {
                    // Almacenar el carácter presionado en el StringBuilder
                    sb.Append(key.Value);

                    // Imprimir el carácter en pantalla
                    Console.Write(key.Value.ToString().ToLowerInvariant());
                    ItemWight++;
                    foreach (var parfum in parfums)
                    {
                        if (parfum.Name.ToLower().Contains(sb.ToString().ToLower())
                            && (sb.ToString() != null && sb.ToString() != string.Empty)
                            && !parfumsPrinted.Contains(parfum.Name))
                        {
                            Console.SetCursorPosition(11, ItemHeight);
                            Console.WriteLine(parfum.Name);
                            parfumsPrinted.Add(parfum.Name);
                            ItemHeight++;
                        }
                    }
                }
                
            }



            
        }


        private void RenderControls()
        {
            throw new NotImplementedException();
        }


        private void ReprintListParfums()
        {

        }


        private bool IsNotAControl(ConsoleKey key)
        {
            return key != ConsoleKey.Enter && key != ConsoleKey.DownArrow
                && key != ConsoleKey.UpArrow && key != ConsoleKey.LeftArrow
                && key != ConsoleKey.Backspace;
        }

    }
}
