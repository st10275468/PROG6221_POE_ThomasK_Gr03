using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Menu : Recipe
    {
        string[] MenuOptions = {"1..Create recipe","2..Display recipe","3..Scale recipe","4..Reset scale","5..Delete recipe","6..Exit" };
        
        public void menu()
        {
            
            Console.WriteLine();
            Console.WriteLine("--------RECIPE APPLICATION---------");
            Console.WriteLine();

            for (int i = 0; i < MenuOptions.Length; i++)
                 {
                    Console.WriteLine(MenuOptions[i]);
                 }

            Console.WriteLine();
            Console.WriteLine("Enter one of the options above: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                GetRecipeDetails();
                menu();
                
            }
            else if (choice == "2")
            {
                DisplayRecipe();
                Console.Clear();
                menu();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("----Scale a recipe----");
            }
            else if(choice == "4")
            {
                Console.Clear();
                Console.WriteLine("----Reset recipe scale----");
            }
            else if (choice == "5")
            {
                Console.Clear();
                Console.WriteLine("----Delete recipe----");
            }
            else if (choice == "6")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                Console.Beep();
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("------INVALID OPTION/FORMAT------");
                Console.ForegroundColor = ConsoleColor.Black;
                menu();
            }

        }




    }
}
