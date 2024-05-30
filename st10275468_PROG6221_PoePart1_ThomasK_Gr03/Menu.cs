using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    public class Menu
    {

        public List<Recipe> Recipes;
        public Menu()
        {
            Recipes = new List<Recipe>();
        }
        //A string array that holds all the options for the menu in the application
        string[] MenuOptions = { "1..Create recipe", "2..Display recipe", "3..Scale recipe", "4..Reset scale", "5..Delete recipe", "6..Exit" };

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

            //Using if else statements to choose what happens depending on the input from the user.
            //After the methods have run it takes the user back to the menu

            if (choice == "1")  //If the user chooses option 1, it will call a method GetRecipe which will allow them to create a recipe
            {
                Console.Clear();
                AddRecipe();
                menu();

            }
            else if (choice == "2") //If the user chooses option 2, it will call a method DisplayRecipe which will Display the ingredients
                                    //and steps in a neat format
            {
                Console.Clear();

                DisplayRecipes();
                Console.WriteLine("Press enter to go back to the menu: ");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            else if (choice == "3") //If the user chooses option 3, it will call a method ScaleRecipe which will allow them to scale
                                    //the recipe quantities
            {
                Console.Clear();
                RecipeScaleChoice();
                Console.WriteLine("Press enter to go back to the menu: ");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            else if (choice == "4") //If the user chooses option 4, it will call a method ResetQuantity which will
                                    //allow them to reset the scaled quantities to its original values
            {
                Console.Clear();
                ResetRecipeChoice();
                Console.WriteLine("Press enter to go back to the menu: ");
                Console.ReadKey();
                Console.Clear();
                menu();
            }
            else if (choice == "5") //If the user chooses option 5, it will call a method ClearRecipe which will allow the user to
                                    //delete the recipe if wanted.
            {
                Console.Clear();
                //  ClearRecipe();
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
        public void AddRecipe()
        {

            Console.WriteLine("--------Create Recipe---------");
            Console.WriteLine();
            Console.WriteLine("Enter the name of this recipe: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe(recipeName);
            recipe.GetRecipeDetails();
            recipe.ExceededCalories += Recipe_ExceededCalories;
            Recipes.Add(recipe);

        }
        public void DisplayRecipes()
        {

            Console.Clear();
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes added yet");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("---------Recipes----------");
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList();
            int j = 1;
            foreach (var recipe in sortedRecipes)
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to display: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {
                    sortedRecipes[choice - 1].DisplayRecipeDetails();

                }
                else
                {

                    Console.WriteLine("Invalid choice");
                    DisplayRecipes();

                }





        }
        public void RecipeScaleChoice()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes found to scale");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("---------Recipes----------");
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList();
            int j = 1;
            foreach (var recipe in sortedRecipes)
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to scale: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {
                    sortedRecipes[choice - 1].ScaleRecipe();

                }
                else
                {

                    Console.WriteLine("Invalid choice");
                    RecipeScaleChoice();
                }
        }
        public void ResetRecipeChoice()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes found to reset the scale");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("---------Recipes----------");
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList();
            int j = 1;
            foreach (var recipe in sortedRecipes)
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to reset the quantities: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {
                    sortedRecipes[choice - 1].ResetQuantity();

                }
                else
                {

                    Console.WriteLine("Invalid choice");
                    ResetRecipeChoice();
                }
        

        }
        public void Recipe_ExceededCalories(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("Total calories in this recipe exceed 300");
        }
    }
}
//------------------------------------------------------------END OF FILE-------------------------------------------------------------------------------------