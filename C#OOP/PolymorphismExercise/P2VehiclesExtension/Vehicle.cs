using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorphismExercise
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionKm;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelCons, double tankCapacity)
        {
            if(fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionKm = fuelCons;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity 
        {
            get => this.fuelQuantity; 
            protected set 
            {
                this.fuelQuantity = value; 
            }
        }

        public double FuelConsumptionKm 
        {
            get => this.fuelConsumptionKm; 
            protected set 
            {
                this.fuelConsumptionKm = value; 
            } 
        }
        public double TankCapacity   
        {
            get 
            {
                return this.tankCapacity;
            }
            protected set 
            { 
                //if(this.FuelQuantity > value)
                //{
                //    this.FuelQuantity = 0;
                //}

                this.tankCapacity = value;
            } 
        }

        public virtual string Drive(double distance)
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
            if(amount < 1)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            //we try to add more fuel than our free space
            if(this.FuelQuantity + amount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += amount;
            }

        }

        public string DriveEmpty(double amount)
        {
            StringBuilder sb = new StringBuilder();
            this.FuelConsumptionKm -= 1.4;
            sb.AppendLine(this.Drive(amount));
            this.FuelConsumptionKm += 1.4;
            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
