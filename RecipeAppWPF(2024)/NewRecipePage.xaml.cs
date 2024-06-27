using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecipeAppWPF_2024_.Models;

namespace RecipeAppWPF
{
    public partial class NewRecipePage : UserControl
    {
        // List to store all recipes
        private List<Recipe> recipes;
        // List to store ingredients for the current recipe
        private List<Ingredient> ingredients;
        // List to store steps for the current recipe
        private List<string> steps;

        // Constructor for NewRecipePage
        public NewRecipePage(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            // Initialize ingredients and steps lists
            ingredients = new List<Ingredient>();
            steps = new List<string>();

            // Set the ItemsSource for the ListBoxes
            ingredientsListBox.ItemsSource = ingredients;
            stepsListBox.ItemsSource = steps;
        }

        // Event handler for Save Recipe button click
        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Get recipe details from UI elements
            string recipeName = recipeNameTextBox.Text.Trim();
            List<Ingredient> ingredients = new List<Ingredient>(ingredientsListBox.Items.Cast<Ingredient>());
            List<string> steps = new List<string>(stepsListBox.Items.Cast<string>());

            // Validate recipe name
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.", "Missing Recipe Name", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate ingredients
            if (ingredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.", "No Ingredients", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate steps
            if (steps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.", "No Steps", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Calculate total calories of the recipe
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);

            // Create a new Recipe object
            Recipe newRecipe = new Recipe();
            newRecipe.Name = recipeName;
            newRecipe.Ingredients = ingredients;
            newRecipe.Steps = steps;

            // Add the new recipe to the list of all recipes
            recipes.Add(newRecipe);

            // Show a success message
            MessageBox.Show($"Recipe '{recipeName}' has been saved successfully!");

            // Check if total calories exceed 300 and show a warning if so
            if (totalCalories > 300)
            {
                MessageBox.Show($"Warning: This recipe exceeds 300 calories. Total calories: {totalCalories}", "High Calorie Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Clear the form after saving
            ClearForm();
        }

        // Method to clear the form after saving a recipe
        private void ClearForm()
        {
            recipeNameTextBox.Text = string.Empty;
            ingredients.Clear();
            steps.Clear();
            ingredientsListBox.Items.Refresh();
            stepsListBox.Items.Refresh();
        }

        // Event handler for Add Ingredient button click
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a dialog to enter ingredient details
            IngredientDialog dialog = new IngredientDialog();
            if (dialog.ShowDialog() == true)
            {
                // If dialog is confirmed, add the new ingredient to the list
                Ingredient newIngredient = dialog.Ingredient;
                ingredients.Add(newIngredient);
                ingredientsListBox.Items.Refresh();
            }
        }

        // Event handler for Add Step button click
        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a dialog to enter step details
            StepDialog dialog = new StepDialog();
            if (dialog.ShowDialog() == true)
            {
                // If dialog is confirmed, add the new step to the list
                string newStep = dialog.Step;
                steps.Add(newStep);
                stepsListBox.Items.Refresh();
            }
        }
    }
}