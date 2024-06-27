using RecipeAppWPF_2024_.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    // User control for scaling the quantities of ingredients in a recipe
    public partial class ScaleRecipePage : UserControl
    {
        // List to store all recipes
        private List<Recipe> recipes;
        // Currently selected recipe
        private Recipe selectedRecipe;

        // Constructor for ScaleRecipePage
        public ScaleRecipePage(List<Recipe> recipes)
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
        }

        // Event handler for the Scale Recipe button click
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe == null)
            {
                MessageBox.Show("Please select a recipe.");
                return;
            }

            // Try to parse the scaling factor from the input text box
            if (double.TryParse(scalingFactorTextBox.Text, out double scalingFactor))
            {
                MessageBox.Show($"Scaling recipe '{selectedRecipe.Name}' by a factor of {scalingFactor}.");

                // Call the ScaleRecipe method on the selected recipe
                selectedRecipe.ScaleRecipe(scalingFactor);

                // Refresh the display to show updated quantities
                DisplayRecipeDetails();
            }
            else
            {
                MessageBox.Show("Invalid scaling factor. Please enter a valid number.");
            }
        }
    }
}