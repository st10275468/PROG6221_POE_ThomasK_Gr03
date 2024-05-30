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
        public Menu()                   //creating a new list of recipes
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
                DeleteRecipe();
                Console.WriteLine("Press enter to go back to the menu: ");
                Console.ReadKey();
                Console.Clear();
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
        /// <summary>
        /// Method created that will get the information from the user on the recipe and store it in the recipe list
        /// </summary>
        public void AddRecipe()
        {

            Console.WriteLine("--------Create Recipe---------");
            Console.WriteLine();
            Console.WriteLine("Enter the name of this recipe: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe(recipeName);
            recipe.GetRecipeDetails(); //calling the method created in the recipe class to retrieve the input from the user
            recipe.ExceededCalories += Recipe_ExceededCalories; //Seeing if the calories are below 300
            Recipes.Add(recipe); //Adding the new recipe to the list of recipes

        }
        /// <summary>
        /// Method created which displays the recipe names and allows the user to choose which recipe details to display in full
        /// </summary>
        public void DisplayRecipes()
        {

            Console.Clear();
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes added yet");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("---------Recipes----------"); //Soring the names of the recipes in alphabetical order
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList();
            int j = 1;
            foreach (var recipe in sortedRecipes) //Using a foreach loop to print out the names of the recipes
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to display: "); //prompting the user to choose a recipe they want to display
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {       //using the choice they gave us to call the other method created to display the recipe details
                    sortedRecipes[choice - 1].DisplayRecipeDetails();

                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ForegroundColor = ConsoleColor.Black;
                    DisplayRecipes();   //Keeps prompting the user until a valid option is given

                }

        }
        /// <summary>
        /// Method created to allow the user to choose a recipe they want to scale, the choice is then used when the scalerecipe method is called from the recipe class
        /// </summary>
        public void RecipeScaleChoice()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes found to scale");
                Console.ReadLine(); //If there are no recipes it will show this
                return;
            }

            Console.WriteLine("---------Recipes----------");
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList(); //Soring the recipes into alphabetical order again
            int j = 1;
            foreach (var recipe in sortedRecipes) //Displaying the recipes using a foreach loop
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }   //Prompting the user to choose which recipe they want to scale
            Console.WriteLine("Choose a recipe to scale: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {                               //calling the scalerecipe method from the recipeclass to scale the recipe that the user chose
                    sortedRecipes[choice - 1].ScaleRecipe();

                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ForegroundColor = ConsoleColor.Black;
                    RecipeScaleChoice(); 
                }
        }
        /// <summary>
        /// Method created to get the recipe that the user wants to scale back to the original values
        /// </summary>
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
            foreach (var recipe in sortedRecipes) //Displaying the recipes
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to reset the quantities: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {
                    sortedRecipes[choice - 1].ResetQuantity(); //Allowing the user to choose which recipe they want to scale then calling the scalemethod
                                          //on the recipe that the user chose

                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ForegroundColor = ConsoleColor.Black;
                    ResetRecipeChoice();
                }
            
        }
        /// <summary>
        /// Method created to all the user to choose a recipe to completely delete
        /// </summary>
        public void DeleteRecipe()
        {
            
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes found to delete");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("---------Recipes----------");
            var sortedRecipes = Recipes.OrderBy(r => r.recipeName).ToList(); 
            int j = 1;
            foreach (var recipe in sortedRecipes) //Displaying the recipe names 
            {

                Console.WriteLine("Recipe " + j + ": " + recipe.recipeName);

                j++;

            }
            Console.WriteLine("Choose a recipe to delete: "); //prompting the user to choose which recipe they want to delete
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Recipes.Count)
                if (Recipes.Count >= choice)
                {
                    Recipes.RemoveAt(choice - 1); //Deleting all the recipe details including the ingredients, name and steps
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully deleted recipe");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.ForegroundColor = ConsoleColor.Black;
                    RecipeScaleChoice();
                }

        }
        //Delegate created to prompt the user when a recipe total calories exceed 300
        public void Recipe_ExceededCalories(object sender, EventArgs e)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total calories in this recipe exceed 300");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
//------------------------------------------------------------END OF FILE-------------------------------------------------------------------------------------