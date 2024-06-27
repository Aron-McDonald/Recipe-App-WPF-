using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAppWPF_2024_.Models
{
    // Represents an ingredient in a recipe
    public class Ingredient
    {
        // The name of the ingredient
        public string Name { get; set; }

        // The current quantity of the ingredient (can be adjusted)
        public double Quantity { get; set; }

        // The original quantity of the ingredient (remains constant)
        public double OriginalQuantity { get; set; }

        // The unit of measurement for the ingredient (e.g., grams, cups, etc.)
        public string Unit { get; set; }

        // The number of calories per unit of the ingredient
        public int Calories { get; set; }

        // The food group the ingredient belongs to (e.g., protein, carbohydrate, etc.)
        public string FoodGroup { get; set; }

        // Constructor to create a new Ingredient object
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity; // Set the original quantity when creating a new ingredient
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }
}