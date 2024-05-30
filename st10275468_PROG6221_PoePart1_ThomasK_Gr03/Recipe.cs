using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    public delegate void ExceededCalories(object sender, EventArgs e);

    public class Ingredient
    {

        public string ingredientName { get; set; }
        public double ingredientQuantity { get; set; }
        public string unitOfMeasure { get; set; }
        public string ingredientgrouping { get; set; }
        public double ingredientCalories { get; set; }

        public Ingredient(string fName, double fQuantity, string fUnit, string fGroup, double fCalories)
        {

            ingredientName = fName;
            ingredientQuantity = fQuantity;
            unitOfMeasure = fUnit;
            ingredientgrouping = fGroup;
            ingredientCalories = fCalories;
        }
        public string GetIngredient()
        {
            string ingredient = ingredientQuantity + unitOfMeasure + "'s" + ingredientName + ". Food group: " + ingredientgrouping + ". Calories: " + ingredientCalories;
            return ingredient;
        }
    }



    public class Step
    {
        public string stepDescription { get; set; }
        public int stepNumber { get; set; }

        public Step(string fStepDescription, int fStepNumber)
        {
            stepDescription = fStepDescription;
            stepNumber = fStepNumber;

        }
        public string GetStep()
        {
            string step = "Step " + stepNumber + ": " + stepDescription;
            return step;
        }

    }

    public class Recipe
    {
        public event ExceededCalories ExceededCalories;
        protected virtual void OnExceededCalories()
        {
            if (ExceededCalories != null)
            {
                ExceededCalories(this, EventArgs.Empty);
            }
        }
        public string recipeName { get; set; }
        public List<Ingredient> recipeIngredients { get; set; }
        public List<Ingredient> recipeIngredientsBackup { get; set; }
        public List<Step> recipeSteps { get; set; }

        public Recipe(string fRecipeName)
        {
            this.recipeName = fRecipeName;
            recipeIngredients = new List<Ingredient>();
            recipeIngredientsBackup = new List<Ingredient>();
            recipeSteps = new List<Step>();
        }


        public void AddIngredient(Ingredient ingredient)
        {
            recipeIngredients.Add(ingredient);
            recipeIngredientsBackup.Add(new Ingredient(ingredient.ingredientName, ingredient.ingredientQuantity, ingredient.unitOfMeasure, ingredient.ingredientgrouping, ingredient.ingredientCalories));
        }
        public void AddStep(Step step)
        {

            recipeSteps.Add(step);
        }

        public void GetIngredients(string recipeName)
        {
            bool ingreInput = false;
            int numIngredients = 0;
            Console.WriteLine("");
            Console.WriteLine("How many ingredients do you need to make: " + recipeName + "?");

            while (!ingreInput)
            {
                string numIngre = Console.ReadLine();
                ingreInput = int.TryParse(numIngre, out numIngredients);

                if (!ingreInput || numIngredients <= 0)
                {
                    Validation();
                    Console.WriteLine("How many ingredients do you need to make: " + recipeName + "?");
                }
            }

            for (int i = 0; i < numIngredients; i++)
            {

                Console.Clear();
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                string name = Console.ReadLine();

                double quantity = 0;
                bool fQuantity = false;
                Console.WriteLine("Enter the quantity of {0}: ", name);
                while (!fQuantity)
                {
                   string sQuantity = Console.ReadLine();
                   if (!double.TryParse(sQuantity, out quantity) || quantity <= 0)
                    {

                        Validation();
                        Console.WriteLine("Enter the quantity of {0}: ", name);
                    }
                     else
                    {
                        fQuantity = true;
                    }
                }
               
                Console.WriteLine("Enter the unit of measurement of used to measure {0}: ", name);
                string unit = Console.ReadLine();

                double calories = 0;
                bool fCalories = false;
                Console.WriteLine("Enter the amount of calories in {0}: ", name);
                while(!fCalories)
                {
                    string sCalories = Console.ReadLine();
                    if (!double.TryParse(sCalories, out calories) || calories <= 0)
                    {
                        Validation();
                        Console.WriteLine("Enter the amount of calories in {0}: ", name);
                    }
                    else
                    {
                        fCalories = true;
                    }
                }

                string group = GetFoodGroup(name);

                Ingredient ingredient = new Ingredient(name, quantity, unit, group, calories);
                AddIngredient(ingredient);
            }

        }
        public string GetFoodGroup(string name)
        {
            string group = null;
            Console.WriteLine("Select what food group {0} belongs to", name);
            string[] FoodGroup = { "1..Starchy foods", "2..Vegetables/fruits", "3..Meat", "4..Dairy products", "5..Fats/oils", "6..Dry Beans/peas/soya", "7..Water" };
            for (int i = 0; i <= 6; i++)
                {
                Console.WriteLine(FoodGroup[i]);
                }
            string choice = Console.ReadLine();
            if (choice == "1")
                {
                group = "Starchy foods";
                }
            else if (choice == "2")
            {
                group = "Vegetables/fruits";
            }
            else if (choice == "3")
            {
                group = "Meat";
            }
            else if (choice == "4")
            {
                group = "Dairy products";
            }
            else if (choice == "5")
            {
                group = "Fat/oils";
            }
            else if (choice == "6")
            {
                group = "Dry beans/peas/soya";
            }
            else if (choice == "7")
            {
                group = "Water";
            }
            else
            {
                Validation();
                GetFoodGroup(name);
            }
            return group;
        }

        public void GetSteps(string name)
        {
            bool fStep = false;
            int numSteps = 0;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("How many steps in the recipe: " + name + "?");

           while (!fStep)
            {
                string steps = Console.ReadLine();
                fStep = int.TryParse(steps, out numSteps);

                if (!fStep || numSteps <= 0)
                {
                    Validation();
                    Console.WriteLine("How many steps in the recipe: " + name + "?");
                }
               
                int stepNumber;
                string description = null;
                for (int i = 0; i < numSteps; i++)
                {
                    stepNumber = i + 1;

                    Console.WriteLine("Enter the description of step {0}: ", stepNumber);
                    description = Console.ReadLine();

                    Step step = new Step(description, stepNumber);
                    AddStep(step);
                }
            }
        }
            public void GetRecipeDetails()
            {
                Console.Clear();

                GetIngredients(recipeName);
                GetSteps(recipeName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe successfully captured!");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Press any key to go back: ");
                Console.ReadKey();
                Console.Clear();
             }
            public void DisplayRecipeDetails()
            {
                double totalCalories = 0;
                Console.Clear();
                Console.WriteLine("Recipe : {0}", recipeName);
                Console.WriteLine();
                Console.WriteLine("Ingredients: ");
                Console.WriteLine();
                foreach (var ingredient in recipeIngredients)
                {
                    Console.WriteLine(" > " + ingredient.ingredientName + " " + ingredient.ingredientQuantity + " " + ingredient.unitOfMeasure + ". " + "Food group: " + ingredient.ingredientgrouping + ".  " + "Calories: " + ingredient.ingredientCalories);
                    totalCalories = totalCalories + ingredient.ingredientCalories;
                }
                Console.WriteLine("Total calories: " + totalCalories);
                Console.WriteLine();
                Console.WriteLine("Steps: ");
                Console.WriteLine();
                foreach (var step in recipeSteps)
                {
                    Console.WriteLine("Step " + step.stepNumber + ": " + step.stepDescription);
                }
                if (totalCalories > 300)
                {
                    OnExceededCalories();
                }

            }

            public void ScaleRecipe()
            {
                string[] scaleOptions = { "1..Half(0.5)", "2..Double(2)", "3..Triple(3)" };
                double scale = 0;
                Console.WriteLine("Choose a scale below: ");
                Console.WriteLine();
                for (int i = 0; i < 3; i++)//Using a for loop to display the scale options array
                {
                    Console.WriteLine(scaleOptions[i]);
                }



                string choice = Console.ReadLine();
                if (choice == "1") //If their choice is 1, the recipe will be scaled by 0.5
                {
                    scale = 0.5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Recipe scaled successfully.");
                    Console.ForegroundColor = ConsoleColor.Black;
            }

                else if (choice == "2")
                {
                    scale = 2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Recipe scaled successfully.");
                    Console.ForegroundColor = ConsoleColor.Black;
            }
                else if (choice == "3")
                {
                    scale = 3;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Recipe scaled successfully.");
                    Console.ForegroundColor = ConsoleColor.Black;
            }
                else
                {
                
                     Validation();
                    ScaleRecipe();
                }
                foreach (var ingredient in recipeIngredients)
                {
                    ingredient.ingredientQuantity = ingredient.ingredientQuantity * scale;
                    ingredient.ingredientCalories = ingredient.ingredientCalories * scale;

                }
            

                }
            public void CaloriesLimit()
            {
                double totalCalories = recipeIngredients.Sum(i => i.ingredientCalories);
                if (totalCalories > 300)
                {
                    OnExceededCalories();
                }
            }
            public void ResetQuantity()
            {
                for (int i = 0; i < recipeIngredients.Count; i++)
                {
                    recipeIngredients[i].ingredientQuantity = recipeIngredientsBackup[i].ingredientQuantity;
                    recipeIngredients[i].ingredientCalories = recipeIngredientsBackup[i].ingredientCalories;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities"); //Prompting the user that the scale was successfull
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();


            }
            public void Validation()
            {
                Console.Clear();
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("INVALID FORMAT/VALUE, try again!");
                Console.ForegroundColor = ConsoleColor.Black;
            }



        }

    }
     // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
            //  [Accessed 12 April 2024].
          
        

//------------------------------------------------------------END OF FILE---------------------------------------------------------------------