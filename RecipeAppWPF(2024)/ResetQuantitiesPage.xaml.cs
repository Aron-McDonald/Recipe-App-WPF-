using RecipeAppWPF_2024_.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    // User control for resetting ingredient quantities of a recipe
    public partial class ResetQuantitiesPage : UserControl
    {
        // List to store all recipes
        private List<Recipe> recipes;
        // Currently selected recipe
        private Recipe selectedRecipe;

        // Constructor for ResetQuantitiesPage
        public ResetQuantitiesPage(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            PopulateRecipeComboBox();
        }

        // Method to populate the recipe combo box with available recipes
        private void PopulateRecipeComboBox()
        {
            recipeComboBox.ItemsSource = recipes;
            recipeComboBox.DisplayMemberPath = "Name";
        }

        // Event handler for when a recipe is selected in the combo box
        private void RecipeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecipe = recipeComboBox.SelectedItem as Recipe;
            DisplayRecipeDetails();
        }

        // Method to display the details of the selected recipe
        private void DisplayRecipeDetails()
        {
            if (selectedRecipe != null)
            {
                recipeNameTextBlock.Text = selectedRecipe.Name;
                // Refresh the ingredients list
                ingredientsItemsControl.ItemsSource = null;
                ingredientsItemsControl.ItemsSource = selectedRecipe.Ingredients;
                // Refresh the steps list
                stepsItemsControl.ItemsSource = null;
                stepsItemsControl.ItemsSource = selectedRecipe.Steps;
            }
            else
            {
                // Clear all fields if no recipe is selected
                recipeNameTextBlock.Text = string.Empty;
                ingredientsItemsControl.ItemsSource = null;
                stepsItemsControl.ItemsSource = null;
            }
        }

        // Event handler for the Reset Quantities button click
        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe.");
                return;
            }

            // Reset the quantities of the selected recipe
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }

            // Refresh the UI with the updated recipe
            DisplayRecipeDetails();

            // Show a confirmation message
            MessageBox.Show($"Recipe '{selectedRecipe.Name}' has been reset to its original state.");
        }
    }
}