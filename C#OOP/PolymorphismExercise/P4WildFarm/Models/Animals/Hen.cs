using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private double henModifier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds),
                typeof(Vegetable)
            };
        }

        protected override double weightModifier => this.henModifier;
        protected override ICollection<Type> allowedFood { get; }
        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
