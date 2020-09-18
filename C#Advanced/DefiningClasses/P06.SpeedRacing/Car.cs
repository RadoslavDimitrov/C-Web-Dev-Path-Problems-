using System;
using System.Collections.Generic;
using System.Text;

namespace P06.SpeedRacing
{
    public class Car
    {
        //•	string Model
        //•	double FuelAmount
        //•	double FuelConsumptionPerKilometer
        //•	double Travelled distance

        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }


        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double DistanceLeft(double fuelAmount, double fuelConsumptionForKm)
        {
            return fuelAmount / fuelConsumptionForKm;
        }

        public override string ToString()
        {
            return $"{this.model} {this.fuelAmount:F2} {this.travelledDistance}";
        }
    }
}
