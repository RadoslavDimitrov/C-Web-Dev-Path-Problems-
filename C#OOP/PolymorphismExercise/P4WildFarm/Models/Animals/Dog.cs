using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private double dogModifier = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Meat)
            };
        }

        protected override double weightModifier => this.dogModifier;
        protected override ICollection<Type> allowedFood { get; }
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
