using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameLenght = 5;
        private const int MinLaps = 1;

        private List<IDriver> drivers;
        private string name;
        private int laps;
        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < MinNameLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameLenght));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if(value < MinLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if(this.drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.name));
            }

            this.drivers.Add(driver);
        }
    }
}
