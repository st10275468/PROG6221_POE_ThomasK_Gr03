using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace st10275468_PROG6221_PoePart1_ThomasK_Gr03
{
    public class Ingredient
    {
        public string ingredientName {  get; set; }
        public double ingredientQuantity { get; set; }
        public string unitOfMeasure { get; set; }
        public string ingredientgrouping { get; set; }
        public double ingredientCalories { get; set; }
       
        public Ingredient(string fName, double fQuantity, string fUnit, string fGroup, double fCalories) { 
            
            ingredientName = fName;
            ingredientQuantity = fQuantity;
            unitOfMeasure = fUnit;
            ingredientgrouping = fGroup;
            ingredientCalories = fCalories;
        }
        public string GetIngredient()
        {
            string ingredient = ingredientQuantity + unitOfMeasure + "'s" + ingredientName +". Food group: " + ingredientgrouping + ". Calories: " + ingredientCalories;
            return ingredient;
        }
    }



    public class Step
    {
        public string stepDescription { get; set; }
        public int stepNumber { get; set; }

        public Step(string fStepDescription, int fStepNumber) {
            stepDescription = fStepDescription;
            stepNumber = fStepNumber;

                }
        public string GetStep()
        {
            string step = "Step " + stepNumber + ": " + stepDescription;
            return step;
        } 

    }
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


            //INPUT VALIDATION:I learnt it from:(wertzui, 2022. c# input validation for strings and integers. [Online] 
            // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
            //  [Accessed 12 April 2024].
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
                 } //End of VALIDATION
                    
            ingredientQuantity = new double[numIngredients];    //Setting the ingredientQuantity and ingredientQuantityBackup array with the length
            ingredientQuantityBackup = new double[numIngredients];//of numIngredients which we got from the user above.

            for (int i = 0; i < numIngredients; i++)    //Using a for loop to get the ingredient name, quantity and unit of measurement
                {                                       //of each ingredient
                Console.Clear() ;
                Console.WriteLine("");
                Console.WriteLine("Enter the name of ingredient {0}: ", i + 1);
                ingredient = Console.ReadLine();    //Getting the ingredient name from the user

                //INPUT VALIDATION:I learnt it from:(wertzui, 2022. c# input validation for strings and integers. [Online] 
                // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
                //  [Accessed 12 April 2024].
                var ingrQuant = false;
                int quantExp;
                while (!ingrQuant)//Using a while loop for error handling. While their input is not valid format it will keep prompting them
                                  //for another input
                {
                    Console.WriteLine("Enter the quantity of ingredient {0}: ", i + 1); //Asking the user for the quantity which must be a valid integer
                    var quantIngr = Console.ReadLine();
                    ingrQuant = int.TryParse(quantIngr, out quantExp); //If ingrQuant is true, then the user has entered a valid input and the while loop
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
                }//End of VALIDATION

                 //Getting the unit of measurement from the user
                Console.WriteLine("Enter the unit of measurement used for ingredient {0}: ", i+1);  
                unit = Console.ReadLine();
                ingredients.Add(ingredient, unit);  //Adding the name and unit of measurement into an array dictionary
                }

            Console.Clear();

            //INPUT VALIDATION:I learnt it from:(wertzui, 2022. c# input validation for strings and integers. [Online] 
            // Available at: https://stackoverflow.com/questions/72400895/c-sharp-input-validation-for-strings-and-integers
            //  [Accessed 12 April 2024].
            var stepInput = false;
            int expStep;
            while (!stepInput) {    //Using a while loop to make sure that the user enters a valid input for the number of steps
               
                Console.WriteLine("");
                Console.WriteLine("Enter the number of steps in this recipe: ");//prompting user for the number of steps
                var numStep = Console.ReadLine();

                stepInput = int.TryParse(numStep, out expStep); //If the input is valid it becomes true and the while loop will stop
                steps = expStep; //The valid input is saved to the actual variable

                if (!stepInput) //If the input is invalid they will be prompted until the input is valid. The while loop will only stop 
                                //once a valid input has been added
                    {
                    Console.Clear();
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("INVALID FORMAT, try again!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    }
            }//End of VALIDATION

            stepDescription = new string[steps];    //Setting the stepDesctription array length to the number of steps
            for (int i = 0; i < steps; i++) //Using a for loop to enter the description of each step
                {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Enter a description of step: {0}", i + 1); //prompting for the description of eachs tep
                stepDescription[i] = Console.ReadLine() ; //Saving the description to its corresponding place in the array
                }

            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------Recipe details successfully recorded------"); 
            Console.ForegroundColor = ConsoleColor.Black;
            
        }

        /// <summary>
        /// The DisplayRecipe method will output all the data that was inputted above into a neat format on the page that makes
        /// the recipe easy to understand and follow.
        /// </summary>
        public void DisplayRecipe()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-----RECIPE DETAILS-----"); 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---Ingredients---");//All the ingredients names, quantities and unit of measurement will be displayed
            Console.WriteLine();                    //under this heading

            for (int i = 0; i < numIngredients; i++)    //Using a for loop to iterate through the dictonary and array and output
                {                                       //the data in a neat format

                //Learnt to get the values from the dictionary at: (VanBuskirk, A., 2023. How to iterate over a dictionary in C#?. [Online] 
               // Available at: https://blog.wordbot.io/tech/how-to-iterate-over-a-dictionary-in-c/#:~:text=Value)%3B%20%7D-,In%20this%20example%2C%20we%20define%20a%20Dictionary%3Cstring%2C%20int,out%20its%20key%20and%20value.
               // [Accessed 12 April 2024].)
                 KeyValuePair<string, string> item = ingredients.ElementAt(i); //Getting the input from the dictionary
                Console.WriteLine("Ingredient {0}: {1} {2} of {3}", i+1, ingredientQuantity[i], item.Value, item.Key);
                }
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine() ;
            Console.WriteLine("---Steps---");//The steps and step desctriptions will be displayed under this heading
            Console.WriteLine();

            for (int i = 0; i < steps; i++) //Using a for loop to iterate through the description array and display it in a neat format
                {
                Console.WriteLine("Step {0}: {1}", i+1, stepDescription[i]);
                }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Press enter to go back to the menu"); 
            Console.ReadLine();
            
         }

        
        /// <summary>
        ///Method ScaleRecipe created to allow the user to scale the recipe quantites either by
        ///half, double or triple the original value
        /// </summary>
        public void ScaleRecipe()
        {
            //Using an array for the scale options given to the user
            string[] scaleOptions = {"1..Half(0.5)","2..Double(2)","3..Triple(3)" };
           
            Console.WriteLine();
            Console.WriteLine("-----SCALE RECIPE-----");
            Console.WriteLine();
            Console.WriteLine("Choose a scale below: ");//Promting the user to choose what they want to scale the recipe by
            Console.WriteLine();

            for (int i = 0; i <3; i++)//Using a for loop to display the scale options array
            {
                Console.WriteLine(scaleOptions[i]);
            }

            string choice = Console.ReadLine(); //Getting the input from the user

            if (choice == "1") //If their choice is 1, the recipe will be scaled by 0.5
            {
                for (int i = 0; i < numIngredients; i++)//Using a for loop to iterate through ingredientQuantity array and divide 
                                                        //all the values by 2
                    {
                    ingredientQuantity[i] = ingredientQuantity[i] / 2; 
                    
                    }
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities"); //Prompting the user that the scale was successfull
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();

            }
            else if (choice == "2") //If their choice is 2, the recipe will be scaled by 2 times
            {
                for (int i = 0; i < numIngredients; i++) //Using a for loop to iterate through ingredientQuantity array and times 
                {                                         //all the values by 2

                    ingredientQuantity[i] = ingredientQuantity[i] * 2;
                    }

                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities"); //Prompting the user that the scale was successfull
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();
            }
            else if (choice == "3")//If their choice is 3, the recipe will be scaled by 3 times
            {
                for (int i = 0; i < numIngredients; i++)//Using a for loop to iterate through ingredientQuantity array and times 
                                                        //all the values by 3
                {
                    ingredientQuantity[i] = ingredientQuantity[i] * 3;

                    }
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully scaled recipe quantities");//Prompting the user that the scale was successfull
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press enter to go back to the menu");
                Console.ReadLine();
                Console.Clear();
            }
            else //Else if they did not input a valid option it will keep prompting them for another
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
        
        /// <summary>
        /// Method ResetQuantity created to reset the quantites of the ingredients back to the original values if they have been scaled
        /// </summary>
        public void ResetQuantity()
        {
            Console.Clear();
            Console.WriteLine();
            
            for (int i = 0; i < numIngredients; i++) //Using a for loop to iterate through the ingredientQuantity array and set the values
                                                     //to the values in the backup array which are the original ones.
                {
                ingredientQuantity[i] = ingredientQuantityBackup[i];
                }
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Quantities reset successfully");//Prompting the user that it was successful
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine() ;
            Console.WriteLine("Press any key to go back to the menu");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Method ClearRecipe created to delete all the data about the recipe that the user inputted previously
        /// </summary>
        public void ClearRecipe()
        {
            
            Console.WriteLine();
            Console.WriteLine("Do you want to clear the recipe? ");
            Console.WriteLine("Type either YES/NO :");//Prompting the user to type yes or no if they want to delete the recipe
            string clear = Console.ReadLine(); //Getting the users input

            if (clear == "YES")//If they type YES, the recipe details will be deleted
                {
                Console.Clear();
                //Below this, all the details of the arrays and variables are being deleted and reset to nothing
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
                Console.WriteLine("Recipe data has been deleted successfully");//Prompting that it was successful
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                }
            else if (clear == "NO") //If the user types NO, the recipe details will not be deleted
                {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe data has not been deleted");//Prompting the user that nothing was deleted.
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadKey();
                Console.Clear();
                 }
            else //If the user does not input a valid option it will keep prompting them for another until they input a valid one
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