using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private const int MinNameLength = 4;
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHp;
        private int maxHp;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHp = minHorsePower;
            this.maxHp = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength)
                {
                    string msg = string.Format(ExceptionMessages.InvalidModel, value, MinNameLength);
                    throw new ArgumentException(msg);
                }

                this.model = value;
            }
        }

        public int HorsePower 
        {
            get { return this.horsePower; }
            private set
            {
                if(value < minHp || value > maxHp)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters
        {
            get { return this.cubicCentimeters; }
            private set
            {
                this.cubicCentimeters = value;
            }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.cubicCentimeters / this.horsePower * laps;
        }
    }
}
