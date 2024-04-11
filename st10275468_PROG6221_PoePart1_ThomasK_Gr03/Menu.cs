using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Menu
    {
        string[] MenuOptions = {"1..Create recipe","2..Display recipe","3..Scale recipe","4..Reset scale","5..Delete recipe","6..Exit" };
        
        public void menu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------Recipe Application---------");
            Console.WriteLine();

            for (int i = 0; i < MenuOptions.Length; i++)
            {

                Console.WriteLine(MenuOptions[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Please enter one of the options above: ");
            

        }



    }
}
