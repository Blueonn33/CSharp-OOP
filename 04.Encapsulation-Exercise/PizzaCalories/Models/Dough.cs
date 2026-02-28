using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2.0;

        private readonly Dictionary<string, double> flourTypeColories;

        private readonly Dictionary<string, double> bakingTechniqueCalories;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourTypeColories = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 }
            };

            this.bakingTechniqueCalories = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "crispy", 0.9 },
                { "chewy", 1.1 },
                { "homemade", 1.0 }
            };

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!this.flourTypeColories.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!this.bakingTechniqueCalories.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = this.flourTypeColories[this.FlourType];
                double bakingTechniqueModifier = this.bakingTechniqueCalories[this.BakingTechnique];
                double calories = BaseCaloriesPerGram * this.Weight * flourTypeModifier * bakingTechniqueModifier;

                return calories;
            }
        }
    }
}

