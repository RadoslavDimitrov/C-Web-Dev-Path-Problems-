using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private double owlModifier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Meat)
            };
        }

        protected override double weightModifier => this.owlModifier;
        protected override ICollection<Type> allowedFood { get; }
        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        
    }
}
