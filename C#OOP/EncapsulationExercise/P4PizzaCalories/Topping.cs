using System;
using System.Collections.Generic;
using System.Text;

namespace P4PizzaCalories
{
    public class Topping
    {
        private double weight;
        private string toppingType;
        private const double baseCalsPerGram = 2;
        private const double meatModifier = 1.2;
        private const double veggiesModifier = 0.8;
        private const double cheeseModifier = 1.1;
        private const double sauceModifier = 0.9;

        public double CalsPerGram => GetCalsPerGram();

        private double GetCalsPerGram()
        {
            switch (this.toppingType.ToLower())
            {
                case "meat":
                    return 2 * meatModifier;
                 case "veggies":
                    return 2 * veggiesModifier;
                case "cheese":
                    return 2 * cheeseModifier;
                case "sauce":
                    return 2 * sauceModifier;
                default:
                    return 0;
                    break;
            }
        }

        public Topping(string type, double weight)
        {
            this.ToppingType = type;
            this.Weight = weight;
        }
        internal string ToppingType
        {
            
            set 
            {
                if(!(value.ToLower() == "meat" || value.ToLower() == "veggies"
                    || value.ToLower() == "cheese" || value.ToLower() == "sauce"))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value; 
            }
        }

        internal double Weight
        {

            set 
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                weight = value; 
            }
        }

    }   
}
