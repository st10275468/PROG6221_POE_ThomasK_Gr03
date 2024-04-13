using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Recipe
    {

        Dictionary<string, string> ingredients = new Dictionary<string, string>();
        double[] ingredientQuantity;
        double[] ingredientQuantityBackup;
        int numIngredients;
        string[] stepDescription;
        string ingredient ;
        string unit;
        int steps;
        public void GetRecipe()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("----CREATE RECIPE----");
           
            var ingreInput = false;
            int expIng;
            while (!ingreInput)
                {
                Console.WriteLine("");
                Console.WriteLine("Enter the number of ingredients in this recipe: ");
                var numIngr = Console.ReadLine();

                ingreInput = int.TryParse(numIngr, out expIng);
                numIngredients = expIng;
                
                if (!ingreInput)
                    {
                    Console.Clear();
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("INVALID FORMAT, try again!");
                    Console.ForegroundColor = ConsoleColor.Black;
                     }
                 }

            ingredientQuantity = new double[numIngredients];
            ingredientQuantityBackup = new double[numIngredients];

            for (int i = 0; i < numIngredients; i++)
                {
                Console.Clear() ;
                Console.WriteLine("");
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                ingredient = Console.ReadLine();

                var ingrQuant = false;
                int quantExp;
                while (!ingrQuant)
                    {
                    Console.WriteLine("Enter the quantity of ingredient {0}: ", i + 1);
                    var quantIngr = Console.ReadLine();
                    ingrQuant = int.TryParse(quantIngr, out quantExp);
                    ingredientQuantity[i] = quantExp;
                    ingredientQuantityBackup[i] = ingredientQuantity[i];

                    if (!ingrQuant)
                    {
                        Console.Clear();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("INVALID FORMAT, try again!");
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                }

                Console.WriteLine("Enter the unit of measurement used for ingredient {0}: ", i+1);
                unit = Console.ReadLine();
                ingredients.Add(ingredient, unit);
                }

            Console.Clear();

            var stepInput = false;
            int expStep;
            while (!stepInput) {
               
                Console.WriteLine("");
                Console.WriteLine("Enter the number of steps in this recipe: ");
                var numStep = Console.ReadLine();

                stepInput = int.TryParse(numStep, out expStep);
                steps = expStep;

                if (!stepInput)
                    {
                    Console.Clear();
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("INVALID FORMAT, try again!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    }
            }

            stepDescription = new string[steps];
            for (int i = 0; i < steps; i++)
                {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Enter a description of step: {0}", i + 1);
                stepDescription[i] = Console.ReadLine() ;
                }

            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------Recipe details successfully recorded------");
            Console.ForegroundColor = ConsoleColor.Black;
            
        }
        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-----RECIPE DETAILS-----");
            Console.WriteLine();
            Console.WriteLine("---Ingredients---");
            Console.WriteLine();

            for (int i = 0; i < numIngredients; i++)
                {
                KeyValuePair<string, string> item = ingredients.ElementAt(i);
                Console.WriteLine("Ingredient {0}: {1} {2} of {3}", i+1, ingredientQuantity[i], item.Value, item.Key);
                }

            Console.WriteLine() ;
            Console.WriteLine("---Steps---");
            Console.WriteLine();

            for (int i = 0; i < steps; i++)
                {
                Console.WriteLine("Step {0}: {1}", i+1, stepDescription[i]);
                }

            Console.WriteLine();
            Console.WriteLine("Press enter to go back to the menu");
            Console.ReadLine();
            
         }

        
        
        public void ScaleRecipe()
        {
            
            string[] scaleOptions = {"1..Half(0.5)","2..Double(2)","3..Triple(3)" };
           
            Console.WriteLine();
            Console.WriteLine("-----SCALE RECIPE-----");
            Console.WriteLine();
            Console.WriteLine("Choose a scale below: ");
            Console.WriteLine();

            for (int i = 0; i <3; i++)
            {
                Console.WriteLine(scaleOptions[i]);
            }

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                for (int i = 0; i < numIngredients; i++)
                    {
                    ingredientQuantity[i] = ingredientQuantity[i] / 2; 
                    
                    }
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();

            }
            else if (choice == "2")
            {
                for (int i = 0; i < numIngredients; i++)
                    {
                    ingredientQuantity[i] = ingredientQuantity[i] * 2;
                    }

                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();
            }
            else if (choice == "3")
            {
                for (int i = 0; i < numIngredients; i++)
                    {
                    ingredientQuantity[i] = ingredientQuantity[i] * 3;

                    }
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {

                Console.Beep();
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------INVALID OPTION/FORMAT------");
                Console.ForegroundColor = ConsoleColor.Black;
                ScaleRecipe();

            }

        }
        public void ResetQuantity()
        {
            Console.Clear();
            Console.WriteLine();
            
            for (int i = 0; i < numIngredients; i++)
                {
                ingredientQuantity[i] = ingredientQuantityBackup[i];
                }
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Quantities reset successfully");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine() ;
            Console.WriteLine("Press any key to go back to the menu");
            Console.ReadKey();
            Console.Clear();
        }
        public void ClearRecipe()
        {
            
            Console.WriteLine();
            Console.WriteLine("Do you want to clear the recipe? ");
            Console.WriteLine("Type either YES/NO :");
            string clear = Console.ReadLine();

            if (clear == "YES")
                {
                Console.Clear();

                ingredients.Clear();
                ingredientQuantity = new double[0];
                ingredientQuantityBackup = new double[0];
                numIngredients = 0;
                stepDescription = new string[0];
                ingredient = null;
                unit = null;
                steps = 0;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe data has been deleted successfully");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                }
            else if (clear == "NO")
                {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe data has not been deleted");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                 }
            else
                {
                Console.Beep();
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------INVALID OPTION/FORMAT------");
                Console.ForegroundColor = ConsoleColor.Black;
                ClearRecipe();
            }


        }
    }
}
