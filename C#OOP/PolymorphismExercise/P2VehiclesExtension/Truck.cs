using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Truck : Vehicle
    {
        private const double airCond = 1.6;

        public Truck(double fuelQuantity, double fuelCons, double tankCapacity) 
            : base(fuelQuantity, fuelCons + airCond, tankCapacity)
        {
        }

        public override void Refuel(double amount)
        {
            if (amount < 1)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += amount * 0.95;
            }

        }
    }
}
