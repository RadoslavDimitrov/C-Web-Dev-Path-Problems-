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

        internal double Weight
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
        internal string FlourType
        {
            set
            {
                if (!(value == "White" || value == "Wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        internal string BakingTechnique
        {
            set
            {
                if (!(value == "Crispy" || value == "Chewy" || value == "Homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double CallPerGram => GetCalloriesPerGram();

        private double GetFlourModifier() // "white" , "wholegrain"
        {
            if (this.flourType == "White")
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
            if (this.bakingTechnique == "Crispy")
            {
                return 0.9;
            }
            else if (this.bakingTechnique == "Chewy")
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
