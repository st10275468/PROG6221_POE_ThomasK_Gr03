using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Recipe
    {
        //Creating all the neccassary variables and arrays needed for the methods that follow
        Dictionary<string, string> ingredients = new Dictionary<string, string>();//Stores the ingredient name and unit of measurement
        double[] ingredientQuantity; //Stores the quantity
        double[] ingredientQuantityBackup; //Quantity backup
        int numIngredients; 
        string[] stepDescription; //Stores the description of steps
        string ingredient ;
        string unit;
        int steps;
      
        /// <summary>
        /// Method GetRecipe will allow the user to create a new menu by prompting them for the name, quantity unit of measurement
        /// and the step description of each ingredient and step
        /// </summary>
        public void GetRecipe()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("----CREATE RECIPE----");
           
            var ingreInput = false;
            int expIng;
            while (!ingreInput)//Using a while loop for error handling. While their input is not valid format it will keep prompting them
                                //for another input
                 {
                Console.WriteLine("");
                Console.WriteLine("Enter the number of ingredients in this recipe: ");
                var numIngr = Console.ReadLine();

                ingreInput = int.TryParse(numIngr, out expIng); //If ingreInput is true then the user has entered a valid input and the while loop
                                                                //will stop and the number of ingredients will be saved.
                numIngredients = expIng;
                
                if (!ingreInput)        //If it is not true then it will prompt the user that their input is invalid and they will have to enter
                    {                   //another input.
                    Console.Clear();
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("INVALID FORMAT, try again!");
                    Console.ForegroundColor = ConsoleColor.Black;
                     }
                 }

            ingredientQuantity = new double[numIngredients];    //Setting the ingredientQuantity and ingredientQuantityBackup array with the length
            ingredientQuantityBackup = new double[numIngredients];//of numIngredients which we got from the user above.

            for (int i = 0; i < numIngredients; i++)    //Using a for loop to get the ingredient name, quantity and unit of measurement
                {                                       //of each ingredient
                Console.Clear() ;
                Console.WriteLine("");
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                ingredient = Console.ReadLine();    //Getting the ingredient name from the user

                var ingrQuant = false;
                int quantExp;
                while (!ingrQuant)//Using a while loop for error handling. While their input is not valid format it will keep prompting them
                                  //for another input
                {
                    Console.WriteLine("Enter the quantity of ingredient {0}: ", i + 1); //Asking the user for the quantity which must be a valid integer
                    var quantIngr = Console.ReadLine();
                    ingrQuant = int.TryParse(quantIngr, out quantExp); //If ingrQuant is true then the user has entered a valid input and the while loop
                                                                       //will stop and the quantity will be saved.
                    ingredientQuantity[i] = quantExp;                       //Quantities saved to both the arrays and the while loop will stop
                    ingredientQuantityBackup[i] = ingredientQuantity[i]; 

                    if (!ingrQuant) //If it is not a valid input it will keep prompting the user for another until it is valid.
                    {
                        Console.Clear();
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("INVALID FORMAT, try again!");
                        Console.ForegroundColor = ConsoleColor.Black;

                    }
                }
                                    //Getting the unit of measurement from the user
                Console.WriteLine("Enter the unit of measurement used for ingredient {0}: ", i+1);  
                unit = Console.ReadLine();
                ingredients.Add(ingredient, unit);  //Adding the name and unit of measurement into an array dictionary
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
//------------------------------------------------------------END OF FILE---------------------------------------------------------------------