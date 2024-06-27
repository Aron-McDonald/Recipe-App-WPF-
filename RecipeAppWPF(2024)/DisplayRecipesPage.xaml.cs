using RecipeAppWPF_2024_.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class DisplayRecipesPage : UserControl
    {
        // List to store the currently displayed recipes
        private List<Recipe> recipes;
        // List to store all recipes (used for filtering)
        private List<Recipe> allRecipes;

        // Constructor for DisplayRecipesPage
        public DisplayRecipesPage(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            // Create a copy of all recipes for filtering purposes
            allRecipes = new List<Recipe>(recipes);

            // Ensure controls are initialized before setting up event handlers
            if (filterTypeComboBox != null)
            {
                filterTypeComboBox.SelectionChanged += FilterTypeComboBox_SelectionChanged;
            }

            // Populate the recipe list initially
            PopulateRecipeList();
        }

        // Method to populate the recipe list box with sorted recipes
        private void PopulateRecipeList()
        {
            recipeListBox.Items.Clear();

            // Sort the recipes alphabetically by name
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            foreach (Recipe recipe in sortedRecipes)
            {
                recipeListBox.Items.Add(recipe.Name);
            }
        }

        // Event handler for when a recipe is selected in the list box
        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRecipeName = recipeListBox.SelectedItem as string;
            Recipe selectedRecipe = allRecipes.Find(r => r.Name == selectedRecipeName);

            if (selectedRecipe != null)
            {
                // Display the selected recipe details
                recipeNameTextBlock.Text = selectedRecipe.Name;
                ingredientsItemsControl.ItemsSource = selectedRecipe.Ingredients;
                stepsItemsControl.ItemsSource = selectedRecipe.Steps;
            }
            else
            {
                // Clear the display if no recipe is selected
                recipeNameTextBlock.Text = string.Empty;
                ingredientsItemsControl.ItemsSource = null;
                stepsItemsControl.ItemsSource = null;
            }
        }

        // Event handler for when the filter type is changed
        private void FilterTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if all necessary controls are initialized
            if (filterTypeComboBox == null || filterTypeComboBox.SelectedItem == null ||
                ingredientFilterTextBox == null || foodGroupFilterComboBox == null || maxCaloriesFilterTextBox == null)
            {
                return;
            }

            string filterType = (filterTypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (string.IsNullOrEmpty(filterType))
            {
                return;
            }

            // Show/hide appropriate filter controls based on the selected filter type
            ingredientFilterTextBox.Visibility = filterType == "Filter by Ingredient" ? Visibility.Visible : Visibility.Collapsed;
            foodGroupFilterComboBox.Visibility = filterType == "Filter by Food Group" ? Visibility.Visible : Visibility.Collapsed;
            maxCaloriesFilterTextBox.Visibility = filterType == "Filter by Maximum Calories" ? Visibility.Visible : Visibility.Collapsed;
        }

        // Method to apply the selected filter
        private void ApplyFilter()
        {
            string filterType = (filterTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            switch (filterType)
            {
                case "Filter by Ingredient":
                    string ingredientFilter = ingredientFilterTextBox.Text.ToLower();
                    recipes = allRecipes.Where(r =>
                        string.IsNullOrEmpty(ingredientFilter) ||
                        r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredientFilter))
                    ).OrderBy(r => r.Name).ToList();
                    break;
                case "Filter by Food Group":
                    string foodGroupFilter = (foodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                    recipes = allRecipes.Where(r =>
                        foodGroupFilter == "All" ||
                        r.Ingredients.Any(i => i.FoodGroup == foodGroupFilter)
                    ).OrderBy(r => r.Name).ToList();
                    break;
                case "Filter by Maximum Calories":
                    int maxCaloriesFilter = int.TryParse(maxCaloriesFilterTextBox.Text, out int calories) ? calories : int.MaxValue;
                    recipes = allRecipes.Where(r =>
                        r.Ingredients.Sum(i => i.Calories) <= maxCaloriesFilter
                    ).OrderBy(r => r.Name).ToList();
                    break;
            }
            // Refresh the recipe list with the filtered results
            PopulateRecipeList();
        }

        // Event handler for the Apply Filter button click
        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }
    }
}