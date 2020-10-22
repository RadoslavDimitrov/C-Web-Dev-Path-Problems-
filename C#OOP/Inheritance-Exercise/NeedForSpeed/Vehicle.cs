﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double fuelUsed = kilometers * this.FuelConsumption;
            if(this.Fuel >= fuelUsed)
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
