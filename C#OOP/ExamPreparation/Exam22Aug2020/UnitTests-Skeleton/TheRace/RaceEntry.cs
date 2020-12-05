namespace TheRace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceEntry
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";

        private Dictionary<string, UnitDriver> driver;

        public RaceEntry()
        {
            this.driver = new Dictionary<string, UnitDriver>();
        }

        //TODO test - Done
        public int Counter
            => this.driver.Count;

        public string AddDriver(UnitDriver driver)
        {
            //TODO test - done
            if (driver == null)
            {
                throw new InvalidOperationException(DriverInvalid); //TODO?
            }

            //TODO test - done
            if (this.driver.ContainsKey(driver.Name))
            {
                throw new InvalidOperationException(string.Format(ExistingDriver, driver.Name));//TODO?
            }

            //TODO test - done
            this.driver.Add(driver.Name, driver);

            //TODO - test - done
            string result = string.Format(DriverAdded, driver.Name);

            //TODO test - done
            return result;
        }

        public double CalculateAverageHorsePower()
        {
            //TODO test - done
            if (this.driver.Count < MinParticipants)
            {
                throw new InvalidOperationException(string.Format(RaceInvalid, MinParticipants));
            }

            //TODO test done
            double averageHorsePower = this.driver
                .Values
                .Select(x => x.Car.HorsePower)
                .Average();

            return averageHorsePower;
        }
    }
}