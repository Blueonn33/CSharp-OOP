using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2.0;

        private readonly Dictionary<string, double> toppingTypeCalories;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            toppingTypeCalories = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!this.toppingTypeCalories.ContainsKey(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get => BaseCaloriesPerGram * this.Weight * this.toppingTypeCalories[this.Type];
        }
    }
}