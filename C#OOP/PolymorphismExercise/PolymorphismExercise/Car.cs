using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public class Car : Vehicle
    {
        private const double airCond = 0.9;

        public Car(double fuelQuantity, double fuelCons) 
            : base(fuelQuantity, fuelCons + airCond)
        {

        }


    }
}
