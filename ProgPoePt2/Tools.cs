using ProgPoePt2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoePt2
{
    public class Tools
    {
        
        public List<Recipe> Recipes = new List<Recipe>();
        public List<Recipe> BackUpRecipes = new List<Recipe>();


        public Tools()
        {
            // Ingrediants = new List<Ingrediant>();
            BackUpRecipes = new List<Recipe>();
            // BackUpIngrediants = new List<Ingrediant>();
            Recipes = new List<Recipe>();
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/



        public int Introduction()
        {
            int opt = 0;
            string welcome = "welcome to recipe maker:" +
                             "\n enter '1' to create new recipe" +
                             "\n enter '2' to change scale of a saved recipe" +
                             "\n enter '3' to display full recipe " +
                             "\n enter '4' calculate calories for a recipe" +
                             "\n enter '5' print recipes alphabetically" +
                             "\n enter '6' to exit";
            Console.WriteLine(welcome);
            opt = int.Parse(Console.ReadLine());
            return opt;
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/

        // made a delegate
        public delegate void CaloriesExceededDelegate(string recipeName, int totalCalories);

        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/

        public int CalculateTotalCalories(string recipeName)
        {
            // Find the recipe with the given name
            var recipe = Recipes.FirstOrDefault(r => r.name == recipeName);

           
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return 0;
            }

           

            // Calculate the total calories
            int totalCalories = 0;
            foreach (var ingredient in recipe.Ingrediants)
            {
                totalCalories += ingredient.cal;
            }

            // If the total calories exceed 300
            //if (totalCalories > 300)
            //{
                //CaloriesExceeded?.Invoke(recipeName, totalCalories);
            //}

            return totalCalories;
        }
        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


        public void ChangeQuantities(string recipeName, int factor)
        {
            // Find the recipe with the given name
            var recipe = Recipes.FirstOrDefault(r => r.name == recipeName);

            
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            // Scaling up the quantities of all ingredients in recipe
            foreach (var ing in recipe.Ingrediants)
            {
                ing.quanity = ing.quanity * factor;
                if (ing.uOm == "teaspoons" && ing.quanity > 3)
                {
                    ing.uOm = "tablespoons";
                    ing.quanity = ing.quanity / 3;
                }
                else if (ing.uOm == "tablespoons" && ing.quanity > 16)
                {
                    ing.uOm = "cups";
                    ing.quanity = ing.quanity / 16;
                }
            }
        }



        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


        public void RevertIngredients(Recipe rec)
        {
            rec.Ingrediants = new List<Ingrediant>(rec.BackUpIngrediants);
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


        public void PrintRecipesAlphabetically()
        {
            // Sort the Recipes list in alphabetical order by name
            var sortedRecipes = Recipes.OrderBy(r => r.name).ToList();

            // Print out the sorted recipes
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.name);
                foreach (var ingredient in recipe.Ingrediants)
                {
                    Console.WriteLine($"Ingredient: {ingredient.ingName}, Unit of Measurement: {ingredient.uOm}, Quantity: {ingredient.quanity}, Calories: {ingredient.cal}");
                }
                Console.WriteLine("--------------------");
            }
        }


        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


        public void PrintReciepe(Recipe rec)
        {


            foreach (var item in Recipes)
            {
                Console.WriteLine(item.name);

                foreach (var ing in rec.Ingrediants)
                {
                    Console.WriteLine(ing.ingName);
                    Console.WriteLine(ing.uOm);
                    Console.WriteLine(ing.cal);
                    Console.WriteLine(ing.quanity);
                    Console.WriteLine(ing.foodGroup);
                }


            }
        }
        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


        // Define a delegate that represents the signature of the event handler methods
        public delegate void CaloriesExceededEventHandler(string recipeName, int totalCalories);

        // Define an event that is triggered when a recipe has over 300 calories
        public event CaloriesExceededEventHandler CaloriesExceeded;

        // Call this method to check the total calories of a reci

        public void CheckCalories(Recipe recipe)
        {
            int totalCalories = recipe.Ingrediants.Sum(i => i.cal);

            if (totalCalories > 300)
            {
                // Trigger the event
                CaloriesExceeded?.Invoke(recipe.name, totalCalories);
            }
        }

        /*-----------------------------------------------------------------------------------------------------------------------*/
        /*-----------------------------------------------------------------------------------------------------------------------*/


    }

}

