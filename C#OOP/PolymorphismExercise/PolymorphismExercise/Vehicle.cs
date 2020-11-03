using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelCons)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionKm = fuelCons;
        }
        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionKm { get; protected set; }

        public string Drive(double distance)
        {
            if (distance * this.FuelConsumptionKm > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= distance * (this.FuelConsumptionKm);
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
