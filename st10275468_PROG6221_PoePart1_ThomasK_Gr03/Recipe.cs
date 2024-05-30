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
    {                                               //Creating a new object ingredient

        public string ingredientName { get; set; }
        public double ingredientQuantity { get; set; }
        public string unitOfMeasure { get; set; }
        public string ingredientgrouping { get; set; }
        public double ingredientCalories { get; set; }

        public Ingredient(string fName, double fQuantity, string fUnit, string fGroup, double fCalories)
        {
                                                //Giving the object properties
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
        public string stepDescription { get; set; }  //Creating a new step object
        public int stepNumber { get; set; }

        public Step(string fStepDescription, int fStepNumber)
        {                                           //Giving the object properties
            stepDescription = fStepDescription;
            stepNumber = fStepNumber;

        }
        public string GetStep()
        {
            string step = "Step " + stepNumber + ": " + stepDescription;
            return step;
        }

    }

    public class Recipe         //Creating a new object recipe
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
        public List<Ingredient> recipeIngredients { get; set; }     //Storing a list of ingredients in each recipe
        public List<Ingredient> recipeIngredientsBackup { get; set; }
        public List<Step> recipeSteps { get; set; } //Storing a list of steps in each recipe

        public Recipe(string fRecipeName)
        {
            this.recipeName = fRecipeName;       //Giving the recipe object its properties
            recipeIngredients = new List<Ingredient>();
            recipeIngredientsBackup = new List<Ingredient>();
            recipeSteps = new List<Step>();
        }

      /// <summary>
      /// Method created to add each ingredient into the ingredient list for each recipe.
      /// </summary>
      /// <param name="ingredient"></param>      
        public void AddIngredient(Ingredient ingredient)
        {
            recipeIngredients.Add(ingredient);
            recipeIngredientsBackup.Add(new Ingredient(ingredient.ingredientName, ingredient.ingredientQuantity, ingredient.unitOfMeasure, ingredient.ingredientgrouping, ingredient.ingredientCalories));
        }   //Backup list to restore the scaled values to the original ones if needed.
       
        /// <summary>
       /// Method created to add each step of the recipe to the step list.
       /// </summary>
       /// <param name="step"></param>
        public void AddStep(Step step)
        {
            recipeSteps.Add(step);
        }
    /// <summary>
    /// method created to prompt the user to input all the neccassary ingredient information for the recipe they are creating
    /// </summary>
    /// <param name="recipeName"></param>
        public void GetIngredients(string recipeName)
        {
            bool ingreInput = false;
            int numIngredients = 0;
            Console.WriteLine("");
            Console.WriteLine("How many ingredients do you need to make: " + recipeName + "?");

            while (!ingreInput) //Using a while loop to ensure that the user inputs a valid double for the amount of ingredients
            {                   // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
                                //  [Accessed 12 April 2024].
                string numIngre = Console.ReadLine();
                ingreInput = int.TryParse(numIngre, out numIngredients);

                if (!ingreInput || numIngredients <= 0)
                {
                    Validation();   //Will keep prompting them to input another input until its a valid double
                    Console.WriteLine("How many ingredients do you need to make: " + recipeName + "?");
                }
            }
                //using a for loop to iterate through the number of ingredients and get all the information of each ingredient
            for (int i = 0; i < numIngredients; i++)
            {
                        
                Console.Clear();    //prompting the user for the name of the ingredient
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                string name = Console.ReadLine();

                double quantity = 0;
                bool fQuantity = false; //prompting the user for the quantity of the ingredient
                Console.WriteLine("Enter the quantity of {0}: ", name);

                while (!fQuantity)//Using a while loop to ensure that the user inputs a valid double for the quantity of each ingredient
                {                   // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
                                    //  [Accessed 12 April 2024].
                    string sQuantity = Console.ReadLine();
                   if (!double.TryParse(sQuantity, out quantity) || quantity <= 0)
                    {

                        Validation();//If it is not valid it will keep prompting the user for another input
                        Console.WriteLine("Enter the quantity of {0}: ", name);
                    }
                     else
                    {
                        fQuantity = true;
                    }
                }
               //prompting the user for the unit of measurement used for each ingredient
                Console.WriteLine("Enter the unit of measurement of used to measure {0}: ", name);
                string unit = Console.ReadLine();

                double calories = 0;
                bool fCalories = false;//Using a while loop to ensure that the user inputs a valid double for the calories of each ingredient
                Console.WriteLine("Enter the amount of calories in {0}: ", name);
                while(!fCalories) // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
                                  //  [Accessed 12 April 2024].
                {
                    string sCalories = Console.ReadLine();
                    if (!double.TryParse(sCalories, out calories) || calories <= 0)
                    {
                        Validation();//If it is not valid it will keep prompting the user for another input
                        Console.WriteLine("Enter the amount of calories in {0}: ", name);
                    }
                    else
                    {
                        fCalories = true;
                    }
                }

                string group = GetFoodGroup(name); //Calling a method to retrieve the food group of the ingredient

                Ingredient ingredient = new Ingredient(name, quantity, unit, group, calories); //Creating a new ingredient with the details given by the user
                AddIngredient(ingredient);//Adding the ingredient created above to our list of ingredients
            }

        }
        /// <summary>
        /// Method created to diplay 7 food groups which the user can then choose what food group that ingredient belongs too
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetFoodGroup(string name)
        {
            string group = null;
            Console.WriteLine("Select what food group {0} belongs to", name);
            string[] FoodGroup = { "1..Starchy foods", "2..Vegetables/fruits", "3..Meat", "4..Dairy products", "5..Fats/oils", "6..Dry Beans/peas/soya", "7..Water" };
            for (int i = 0; i <= 6; i++)
                {
                Console.WriteLine(FoodGroup[i]);
                }
            string choice = Console.ReadLine(); //Printing out the array of food groups and letting the user choose which one is relavent to their ingredient.
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
            {                                       //Once the user has chosen the corrosponding number it will save that food group into the specific ingredient
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
                Validation(); //If they don't choose a valid option it will keep prompting them
                GetFoodGroup(name);
            }
            return group;
        }

        /// <summary>
        /// Method created to get all the information on each step of the recipe
        /// </summary>
        /// <param name="name"></param>
        public void GetSteps(string name)
        {
            bool fStep = false;
            int numSteps = 0;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("How many steps in the recipe: " + name + "?");

           while (!fStep) //Using a while loop to ensure that the user inputs a valid double for the number of steps in each recipe
            {             // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
                          //  [Accessed 12 April 2024].
                string steps = Console.ReadLine(); 
                fStep = int.TryParse(steps, out numSteps);

                if (!fStep || numSteps <= 0)
                {
                    Validation(); //If it is not valid it will keep prompting the user for another input
                    Console.WriteLine("How many steps in the recipe: " + name + "?");
                }
               
                int stepNumber;
                string description = null; //Using a for loop to iterate the number of steps and get the description of each step
                for (int i = 0; i < numSteps; i++)
                {
                    stepNumber = i + 1;

                    Console.WriteLine("Enter the description of step {0}: ", stepNumber);
                    description = Console.ReadLine();

                    Step step = new Step(description, stepNumber); //Creating a new step with the information given from the user
                    AddStep(step); //Adding the step created to out list of steps
                }
            }
        }
        /// <summary>
        /// Method created that calls the methods above that will allow us to get all the information needed to create a recipe
        /// </summary>
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
        /// <summary>
        /// Method created that will display the recipe details of a chosen recipe
        /// </summary>        
        public void DisplayRecipeDetails()
            {
                double totalCalories = 0;
                Console.Clear();
                Console.WriteLine("Recipe : {0}", recipeName);
                Console.WriteLine();
                Console.WriteLine("Ingredients: ");
                Console.WriteLine();
                foreach (var ingredient in recipeIngredients) //Using a foreach loop to iterate through the ingredient list and display all the ingredients and the 
                {                                             //ingredients information for the specific recipe chosen by the user
                    Console.WriteLine(" > " + ingredient.ingredientName + " " + ingredient.ingredientQuantity + " " + ingredient.unitOfMeasure + ". " + "Food group: " + ingredient.ingredientgrouping + ".  " + "Calories: " + ingredient.ingredientCalories);
                    totalCalories = totalCalories + ingredient.ingredientCalories; //Calculating the total calories for the recipe
                }
                Console.WriteLine("Total calories: " + totalCalories);
                Console.WriteLine();
                Console.WriteLine("Steps: ");
                Console.WriteLine();
                foreach (var step in recipeSteps) //Using a foreach loop to iterate through the step list and get the description of each step
                {
                    Console.WriteLine("Step " + step.stepNumber + ": " + step.stepDescription); //Displaying the information of each step for the specific recipe
                }
                if (totalCalories > 300)
                {
                    OnExceededCalories();   //If the total calories exceed 300 then it invokes the OnExceededCalories delegate
                }

            }

        /// <summary>
        /// Method created to diplay the scaling options and allowing the user to choose one
        /// </summary>
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
                {                           //If their choice is 2 the recipe will be doubled
                    scale = 2;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Recipe scaled successfully.");
                    Console.ForegroundColor = ConsoleColor.Black;
            }
                else if (choice == "3")     //If their choice is 3 the recipe will be tripled
            {
                    scale = 3;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Recipe scaled successfully.");
                    Console.ForegroundColor = ConsoleColor.Black;
            }
                else
                {
                    //If they dont choose one of the given options they will be prompted to try again
                     Validation();
                    ScaleRecipe();
                }
                foreach (var ingredient in recipeIngredients)   //Using a foreach loop to iterate through the ingredient list and scale the quantity and
                {                                               //the calories of each ingredient for the specific recipe
                    ingredient.ingredientQuantity = ingredient.ingredientQuantity * scale;
                    ingredient.ingredientCalories = ingredient.ingredientCalories * scale;

                }
            

                }
        /// <summary>
        /// Method called to invoke the delegate if the total calories are over 300
        /// </summary>
            public void CaloriesLimit()
            {
                double totalCalories = recipeIngredients.Sum(i => i.ingredientCalories);
                if (totalCalories > 300)
                {
                    OnExceededCalories();
                }
            }
        /// <summary>
        /// Method created to reset the quantities that were scaled back to the original values
        /// </summary>
            public void ResetQuantity()
            {
                for (int i = 0; i < recipeIngredients.Count; i++)
                {           //Using a for loop to go through the list of ingredients and change them to the backed up original ones
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
        /// <summary>
        /// Method created to alert the user when they input incorrect data
        /// </summary>
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