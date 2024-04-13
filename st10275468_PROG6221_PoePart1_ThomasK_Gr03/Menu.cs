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
              
        /// <summary>
        /// menu method created so everytime I call it it will display the user with the options of what they can do in the program.
        /// It will allow them to choose an option and then proceed to it.
        /// </summary>
        public void menu()  
        {
            Console.WriteLine();
            Console.WriteLine("--------RECIPE APPLICATION---------");   //Heading of the page
            Console.WriteLine();

            for (int i = 0; i < MenuOptions.Length; i++)
                 {
                  Console.WriteLine(MenuOptions[i]);    //Printing out the array of options for the user to choose
                 }

            Console.WriteLine();
            Console.WriteLine("Enter one of the options above: ");
            string choice = Console.ReadLine(); //Getting the input from the user on what option they choose 

            //Using if else statements to choose what happens on what the input is from the user. After the methods have run it takes the user back to the menu

            if (choice == "1")  //If the user chooses option 1, it will call a method GetRecipe which will allow them to create a recipe
            {   
                GetRecipe();
                menu();
                
            }
            else if (choice == "2") //If the user chooses option 2, it will call a method DisplayRecipe which will Display the ingredients and steps in a neat format
            {
                DisplayRecipe();
                Console.Clear();
                menu();
            }
            else if (choice == "3") //If the user chooses option 3, it will call a method ScaleRecipe which will allow them to scale the recipe quantities
            {
                Console.Clear();
                ScaleRecipe();
                menu();
            }
            else if(choice == "4") //If the user chooses option 4, it will call a method ResetQuantity which will
                                   //allow them to reset the scaled quantities to its original values
            {
                Console.Clear();
                ResetQuantity();
                menu();
            }
            else if (choice == "5") //If the user chooses option 5, it will call a method ClearRecipe which will allow the user to delete the recipe if wanted.
            {
                Console.Clear();
                ClearRecipe();
                menu();
            }
            else if (choice == "6") ////If the user chooses option 6, it will allow them to exit the program
            {
                Console.Clear();
                Environment.Exit(0);
               
            }
            else //Else if the user doesn't choose one of the options above or the user input is invalid then it will prompt them and ask for an option again
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
