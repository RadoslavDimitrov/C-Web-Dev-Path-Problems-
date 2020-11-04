using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private double tigerModifier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.allowedFood = new List<Type>
            {
                typeof(Meat)
            };
        }
        protected override double weightModifier => this.tigerModifier;
        protected override ICollection<Type> allowedFood { get; }
        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
