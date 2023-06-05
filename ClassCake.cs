using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCookery
{
    internal class ClassCake
    {
        public ClassCake(int id, string name, string category, int cost, string unit, double fats, double protein, double carbohydrates, string vitamins, string caterer, int quantity, string recipe)
        {
            Id = id;
            Name = name;
            Category = category;
            Cost = cost;
            Unit = unit;
            Fats = fats;
            Protein = protein;
            Carbohydrates = carbohydrates;
            Vitamins = vitamins;
            Caterer = caterer;
            Quantity = quantity;
            Recipe = recipe;
        }

        public ClassCake()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Cost { get; set; }
        public string Unit { get; set; }
        public double Fats { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public string Vitamins { get; set; }
        public string Caterer { get; set; }
        public int Quantity { get; set; }
        public string Recipe { get; set; }
    }
}