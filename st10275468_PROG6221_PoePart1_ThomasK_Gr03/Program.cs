using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
           
            Menu menu = new Menu();
            menu.menu();
        }

    }
}
