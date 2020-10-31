using System;
using System.Collections.Generic;
using System.Text;

namespace P4PizzaCalories
{
    public class Dough
    {
        private string flourType; //white or wholegrain
        private double flourTypeModifier => GetFlourModifier();

        private string bakingTechnique; //crispy, chewy or homemade
        private double bakingModifier => GetBakingModifier();

        private double weight;

        private const double baseDoughtCal = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }
        public string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double CallPerGram => GetCallories();

        private double GetFlourModifier() // "white" , "wholegrain"
        {
            if (this.flourType.ToLower() == "white")
            {
                return 1.5;
            }
            else
            {
                return 1.0;
            }
        }

        private double GetBakingModifier()  //crispy, chewy or homemade
        {
            if (this.bakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.bakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1.0;
            }
        }
        private double GetCalloriesPerGram()
        {
            return baseDoughtCal  * this.flourTypeModifier * this.bakingModifier;
        }

        private double GetCallories()
        {
            return (baseDoughtCal * this.weight) * this.flourTypeModifier * this.bakingModifier;
        }
    }
}
