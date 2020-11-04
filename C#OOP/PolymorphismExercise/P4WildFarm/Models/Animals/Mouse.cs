using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private double mouseModifier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit)
            };
        }

        protected override double weightModifier => this.mouseModifier;
        protected override ICollection<Type> allowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
