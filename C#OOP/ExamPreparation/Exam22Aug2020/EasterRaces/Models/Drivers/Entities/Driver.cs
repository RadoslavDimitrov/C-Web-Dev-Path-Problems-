using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinNameLength = 5;

        private ICar car;
        private string name;
        public Driver(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameLength));
                }

                this.name = value;
            }
        }


        public ICar Car 
        { 
            get => this.car; 
            private set => this.car = value; 
        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.car != null;

        public void AddCar(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
