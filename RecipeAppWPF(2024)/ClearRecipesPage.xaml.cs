using RecipeAppWPF_2024_.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    public partial class ClearRecipesPage : UserControl
    {
        private List<Recipe> recipes;

        public ClearRecipesPage(List<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            PopulateRecipeList();
        }

        private void PopulateRecipeList()
        {
            recipeListBox.ItemsSource = recipes;
            recipeListBox.DisplayMemberPath = "Name";
        }

        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = recipeListBox.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                recipes.Remove(selectedRecipe);
                PopulateRecipeList();
                MessageBox.Show($"Recipe '{selectedRecipe.Name}' has been cleared.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to clear.");
            }
        }
    }
}