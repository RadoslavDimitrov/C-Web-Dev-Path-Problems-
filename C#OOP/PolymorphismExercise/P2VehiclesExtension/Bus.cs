using PolymorphismExercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace P2VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double fuelModifier = 1.4;
        public Bus(double fuelQuantity, double fuelCons, double tankCapacity) 
            : base(fuelQuantity, fuelCons + fuelModifier, tankCapacity)
        {
        }

        
    }
}
