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
        public void GetRecipeDetails()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("----Create a recipe----");
            Console.WriteLine("");

            Console.WriteLine("Proceed through the following steps: ");
            Console.WriteLine("Enter the number of ingredients: ");
            numIngredients = int.Parse(Console.ReadLine());
            ingredients = new string[numIngredients];

            string unit = null;
            double quantity = 0;
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Clear() ;
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                ingredients[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity of {0}: ", ingredients[i]);
                quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the unit of measurement used for {0}: ", ingredients[i]);
                unit = Console.ReadLine();

                ingredientQuantUnit.Add(quantity, unit);
            }
               Console.WriteLine("Details recorded");
        }
        public void DisplayRecipe()
        {

        }

        public void ScaleRecipe()
        {

        }
    }
}
