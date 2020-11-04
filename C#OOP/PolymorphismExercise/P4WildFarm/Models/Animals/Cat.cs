using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private double catModifier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Vegetable),
                typeof(Meat)
            };
        }

        protected override double weightModifier => this.catModifier;
        protected override ICollection<Type> allowedFood { get; }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
