using RecipeAppWPF_2024_.Models;
using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF
{
    // Dialog window for adding or editing an ingredient
    public partial class IngredientDialog : Window
    {
        // Property to store the created or edited ingredient
        public Ingredient Ingredient { get; private set; }

        // Constructor for the IngredientDialog
        public IngredientDialog()
        {
            InitializeComponent();
        }

        // Event handler for the OK button click
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve values from the input fields
            string name = nameTextBox.Text;
            double quantity = double.Parse(quantityTextBox.Text);
            string unit = unitTextBox.Text;
            int calories = int.Parse(caloriesTextBox.Text);

            // Get the selected food group from the ComboBox
            string foodGroup = (foodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Create a new Ingredient object with the input values
            Ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);

            // Set the dialog result to true, indicating successful creation/edit
            DialogResult = true;
        }
    }
}