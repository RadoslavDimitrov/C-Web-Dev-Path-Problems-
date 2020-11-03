using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Truck : Vehicle
    {
        private const double airCond = 1.6;

        public Truck(double fuelQuantity, double fuelCons) 
            : base(fuelQuantity, fuelCons + airCond)
        {
        }

        public override void Refuel(double amount)
        {
            this.FuelQuantity += amount * 0.95;
        }
    }
}
