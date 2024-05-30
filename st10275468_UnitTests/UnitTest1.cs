using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using st10275468_PROG6221_PoePart1_ThomasK_Gr03;
namespace st10275468_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalCalories() //Unit test created to test my calculations on the total calories of each ingredient
        {
            var recipe = new Recipe("Test");

            var recipeIngredient1 = new Ingredient("Ingredient 1", 200,"ml", "Meat", 200);
            var recipeIngredient2 = new Ingredient("Ingredient 2", 2, "Spoons", "Dairy products", 100);
            recipe.AddIngredient(recipeIngredient1);
            recipe.AddIngredient(recipeIngredient2);

           
            Assert.AreEqual(300, recipe.recipeIngredients[0].ingredientCalories + recipe.recipeIngredients[1].ingredientCalories);
        }
    }
}
