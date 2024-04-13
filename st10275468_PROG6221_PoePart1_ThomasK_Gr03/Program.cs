using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run(); 
        }
        static void Run() //Run method created so that we could keep the main clean. This method brings up the menu and changes the console colour
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Menu menu = new Menu(); //Instantiating a new menu object
            menu.menu();
        }

    }
}
//------------------------------------------------------------END OF FILE---------------------------------------------------------------------