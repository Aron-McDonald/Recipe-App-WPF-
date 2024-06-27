using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecipeAppWPF_2024_.Models
{
    public class Recipe
    {
        // Properties to store recipe details
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Delegate and event for notifying when a recipe exceeds 300 calories
        public delegate void ExceedCaloriesDelegate(string recipeName, int totalCalories);
        public event ExceedCaloriesDelegate ExceedCaloriesEvent;

        // Default constructor
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            ExceedCaloriesEvent += OnExceedCalories; // Subscribe to the event
        }

        // Copy constructor to create a new instance of the recipe with the same values
        public Recipe(Recipe other)
        {
            Name = other.Name;
            Ingredients = new List<Ingredient>(other.Ingredients.Select(i => new Ingredient(i.Name, i.Quantity, i.Unit, i.Calories, i.FoodGroup)));
            Steps = new List<string>(other.Steps);
            ExceedCaloriesEvent += OnExceedCalories; // Subscribe to the event
        }

        // Event handler for ExceedCaloriesEvent
        private void OnExceedCalories(string recipeName, int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n   Warning: Recipe '{recipeName}' exceeds 300 calories ({totalCalories} calories).");
            Console.ResetColor();
        }

        // Method to get recipe details from user input
        public void GetRecipeDetails()

        {

            Console.Write("   Enter the recipe name: ");

            Name = Console.ReadLine();

            Console.Write("\n   Enter the number of ingredients: ");

            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)

            {

                Console.Write($"\n   Enter ingredient {i + 1} name: ");

                string ingredientName = Console.ReadLine();

                Console.Write($"   Enter ingredient {i + 1} quantity: ");

                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"   Enter ingredient {i + 1} unit of measurement: ");

                string unit = Console.ReadLine();

                Console.Write($"   Enter ingredient {i + 1} calories: ");

                int calories = int.Parse(Console.ReadLine());

                Console.Write($"   Enter ingredient {i + 1} food group: ");

                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);

                Ingredients.Add(ingredient);

            }

            Console.Write("\n   Enter the number of steps: ");

            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)

            {

                Console.Write($"\n   Enter step {i + 1}: ");

                string step = Console.ReadLine();

                Steps.Add(step);

            }

        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            // Check if recipe details are available
            if (string.IsNullOrEmpty(Name) || Ingredients.Count == 0 || Steps.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   No recipe details available.");
                Console.ResetColor();
                return;
            }

            // Display recipe name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n   Recipe: {Name}\n");
            Console.ResetColor();

            // Display ingredients and calculate total calories
            Console.WriteLine("   Ingredients:");
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"     {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup} foodgroup)");
                totalCalories += (int)(ingredient.Quantity * ingredient.Calories);
            }

            Console.WriteLine($"\n   Total Calories: {totalCalories}");

            // Trigger event if total calories exceed 300
            if (ExceedCaloriesEvent != null && totalCalories > 300)
            {
                ExceedCaloriesEvent(Name, totalCalories);
            }

            // Display steps
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n   Steps:");
            Console.ResetColor();
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"     {i + 1}. {Steps[i]}");
            }
        }

        // Method to scale the recipe by a given factor
        public void ScaleRecipe(double factor)
        {
            if (Ingredients.Count == 0)
            {
                return;
            }

            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity * factor; // Scale the quantity based on the original quantity
            }
        }
    }
}