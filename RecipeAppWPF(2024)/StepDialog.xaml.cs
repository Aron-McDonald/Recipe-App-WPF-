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

namespace RecipeAppWPF
{
    /// <summary>
    /// Dialog window for adding or editing a recipe step
    /// </summary>
    public partial class StepDialog : Window
    {
        // Property to store the step description
        public string Step { get; private set; }

        // Constructor for the StepDialog
        public StepDialog()
        {
            InitializeComponent();
        }

        // Event handler for the OK button click
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the Step property to the text entered in the description text box
            Step = descriptionTextBox.Text;

            // Set the DialogResult to true, indicating successful creation/edit
            DialogResult = true;
        }
    }
}