using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = 8;
        }

        public override double FuelConsumption { get; set; }

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
