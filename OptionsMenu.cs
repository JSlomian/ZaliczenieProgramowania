using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracZaliczeniowa
{
    public class OptionsMenu
    {
        int Option = 0;
        string OptionString = string.Empty;
        public OptionsMenu(string Prompt, string[] Options)
        {
            Menu(Prompt, Options);
        }
        public int getOption()
        {
            return Option;
        }

        public string getOptionString()
        {
            return OptionString;
        }
        private void Menu(string Prompt, string[] Options)
        {
            bool Menuloop = true;
            int IndexArray = 0;
            while (Menuloop)
            {
                Console.Clear();
                Console.WriteLine(Prompt);
                for (int i = 0; i < Options.Length; i++)
                {

                    if (IndexArray == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"* << {Options[i]} >> *");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine($"  << {Options[i]} >>  ");
                    }

                }
                ConsoleKeyInfo KP = Console.ReadKey(true);
                switch (KP.Key)
                {
                    case ConsoleKey.DownArrow:
                        IndexArray++;
                        if (IndexArray >= Options.Length)
                        {
                            IndexArray = 0;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        IndexArray--;
                        if (IndexArray < 0)
                        {
                            IndexArray = Options.Length - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Menuloop = false;
                        Option = IndexArray;
                        OptionString = Options[IndexArray];
                        break;
                }
            }
        }
    }
}