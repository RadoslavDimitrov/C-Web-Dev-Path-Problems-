using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = 10;
        }

        public override double FuelConsumption { get ; set; }

        public override void Drive(double kilometers)
        {
            double fuelUsed = kilometers * this.FuelConsumption;
            if (this.Fuel >= fuelUsed)
            {
                this.Fuel -= fuelUsed;
            }
            else //we have less fuel
            {
                this.Fuel = 0;
            }
        }
    }
}
