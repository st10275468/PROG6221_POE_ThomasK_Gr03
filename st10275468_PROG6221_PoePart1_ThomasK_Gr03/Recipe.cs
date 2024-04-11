using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    internal class Recipe
    {
        int numIngredients;
        Dictionary<double, string> ingredientQuantUnit = new Dictionary<double, string>();
        string[] ingredients;
        string[] stepDescription;
        string unit = null;
        double quantity = 0;
        int steps;
        public void GetRecipeDetails()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("----Create a recipe----");
            Console.WriteLine("");

            
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());
            ingredients = new string[numIngredients];

            
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Clear() ;
                Console.WriteLine("");
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                ingredients[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity of {0}: ", ingredients[i]);
                quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the unit of measurement used for {0}: ", ingredients[i]);
                unit = Console.ReadLine();

                ingredientQuantUnit.Add(quantity, unit);
            }
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Enter the number of steps: ");
            steps = int.Parse(Console.ReadLine());

            stepDescription = new string[steps];
            for (int i = 0; i < steps; i++)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Enter a description of step: {0}", i + 1);
                stepDescription[i] = Console.ReadLine() ;
            }

            Console.Clear();
          /*  for (int i = 0;i < steps; i++)
            {
                Console.WriteLine("Step {0}: {1}" , i + 1, stepDescription[i] );
            }
          /*  foreach (KeyValuePair <double, string> item in ingredientQuantUnit)
            {
                Console.WriteLine("U need {0}, {1}", item.Key, item.Value);
            }*/

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine("------Recipe details successfully recorded------");
            Console.ForegroundColor = ConsoleColor.Black;
            
        }
        public void DisplayRecipe()
        {

        }

        public void ScaleRecipe()
        {

        }
    }
}
