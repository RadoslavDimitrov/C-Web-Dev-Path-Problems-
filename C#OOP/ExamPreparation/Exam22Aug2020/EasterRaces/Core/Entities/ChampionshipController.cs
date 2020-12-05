using EasterRaces.Core.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverData;
        private CarRepository carData;
        private RaceRepository raceData;

        public ChampionshipController()
        {
            this.driverData = new DriverRepository();
            this.carData = new CarRepository();
            this.raceData = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverData.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.carData.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceData.GetByName(raceName);

            if(race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.driverData.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            car = this.carData.GetByName(model);

            if (car != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
            }

            this.carData.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {

            IDriver driverFromRepo = this.driverData.GetByName(driverName);

            if (driverFromRepo != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            driverFromRepo = new Driver(driverName);
            this.driverData.Add(driverFromRepo);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceData.GetByName(name);

            if(race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);
            this.raceData.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceData.GetByName(raceName);

            if(race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> topThree = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, topThree[0].Name, race.Name));
            IDriver driver = this.driverData.GetByName(topThree[0].Name);
            driver.WinRace();
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, topThree[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, topThree[2].Name, race.Name));

            this.raceData.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
