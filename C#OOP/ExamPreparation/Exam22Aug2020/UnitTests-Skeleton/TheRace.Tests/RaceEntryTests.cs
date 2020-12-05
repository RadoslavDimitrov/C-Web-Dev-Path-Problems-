using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShoudInitializeDictionari()
        {
            RaceEntry race = new RaceEntry();

            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void AddDriver_NullDriver_ShouldThrowException()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void AddDriver_TwoDriversWithSameName_ShouldThrowException()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver driver = new UnitDriver("Gosho", new UnitCar("mazda", 120, 2000));
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ShouldAddProperly()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver driver = new UnitDriver("Gosho", new UnitCar("mazda", 120, 2000));
            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void AddDriver_ShouldReturnProperly()
        {
            RaceEntry race = new RaceEntry();
            UnitDriver driver = new UnitDriver("Gosho", new UnitCar("mazda", 120, 2000));
            string actualResult = race.AddDriver(driver);
            string expectedResult = $"Driver {driver.Name} added in race.";
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePower_NoDrivers_ShoudThrowException()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_TwoDrivers_ShoudWorkProperly()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(new UnitDriver("Gosho", new UnitCar("mazda", 100, 1000)));
            race.AddDriver(new UnitDriver("Pesho", new UnitCar("honda", 100, 1000)));

            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}