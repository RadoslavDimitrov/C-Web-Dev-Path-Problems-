using PolymorphismExercise;
using System;
using System.Collections.Generic;
using System.Text;

namespace P2VehiclesExtension
{
    public static class Factory
    {
        public static Vehicle CreateVehicle(string[] arg)
        {
            double fuelQuantity = double.Parse(arg[1]);
            double litersPerKM = double.Parse(arg[2]);
            double tankCapacity = double.Parse(arg[3]);



            switch (arg[0].ToLower())
            {
                case "car":
                    return new Car(fuelQuantity, litersPerKM, tankCapacity);
                case "truck":
                    return new Truck(fuelQuantity, litersPerKM, tankCapacity);
                case "bus":
                    return new Bus(fuelQuantity, litersPerKM, tankCapacity);
                default:
                    return null;

            }
        }
    }
}
