using RecipeAppWPF;
using RecipeAppWPF_2024_.Models;
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

namespace RecipeAppWPF_2024_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List to store all recipes in the application
        private List<Recipe> recipes = new List<Recipe>();

        // Constructor for the MainWindow
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the New Recipe button click
        private void NewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new NewRecipePage and set it as the content of the ContentArea
            NewRecipePage newRecipePage = new NewRecipePage(recipes);
            ContentArea.Content = newRecipePage;
        }

        // Event handler for the Display Recipes button click
        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new DisplayRecipesPage and set it as the content of the ContentArea
            DisplayRecipesPage displayRecipesPage = new DisplayRecipesPage(recipes);
            ContentArea.Content = displayRecipesPage;
        }

        // Event handler for the Scale Recipe button click
        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new ScaleRecipePage and set it as the content of the ContentArea
            ScaleRecipePage scaleRecipePage = new ScaleRecipePage(recipes);
            ContentArea.Content = scaleRecipePage;
        }

        // Event handler for the Reset Quantities button click
        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new ResetQuantitiesPage and set it as the content of the ContentArea
            ResetQuantitiesPage resetQuantitiesPage = new ResetQuantitiesPage(recipes);
            ContentArea.Content = resetQuantitiesPage;
        }

        // Event handler for the Clear Recipes button click
        private void ClearRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new ClearRecipesPage and set it as the content of the ContentArea
            ClearRecipesPage clearRecipesPage = new ClearRecipesPage(recipes);
            ContentArea.Content = clearRecipesPage;
        }

        // Event handler for the Exit button click
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Show a confirmation dialog before exiting the application
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // If user confirms, shut down the application
                Application.Current.Shutdown();
            }
        }
    }
}