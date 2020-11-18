using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShoudReturnRightMake()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(car.Make, Is.EqualTo("mazda"));
        }

        [Test]
        public void Constructor_ShoudReturnRightModel()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(car.Model, Is.EqualTo("626"));
        }

        [Test]
        public void Constructor_ShoudReturnRightFuelConsumption()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(car.FuelConsumption, Is.EqualTo(10));
        }

        [Test]
        public void Constructor_ShoudReturnRightFuelCapacity()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(car.FuelCapacity, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_ShoudReturnRightFuelAmount()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_EmptyMake_ShoudReturnException()
        {
            Assert.That(() => new Car("", "626", 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NullMake_ShoudReturnException()
        {
            Assert.That(() => new Car(null, "626", 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_EmptyModel_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", "", 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NullModel_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", null, 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NegativeFuelConsumption_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", "626", -10, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_ZeroFuelConsumption_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", "626", 0, 100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_NegativeFuelCapacity_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", "626", 10, -100), Throws.ArgumentException);
        }

        [Test]
        public void Constructor_ZeroFuelCapacity_ShoudReturnException()
        {
            Assert.That(() => new Car("mazda", "626", 10, 0), Throws.ArgumentException);
        }

        [Test]
        public void RefuelMethod_NegativeFuel_ShoudReturnException()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(() => car.Refuel(-10), Throws.ArgumentException);
        }

        [Test]
        public void RefuelMethod_AddingFuel_ShoudReturnFuelSum()
        {
            Car car = new Car("mazda", "626", 10, 100);

            car.Refuel(20);

            Assert.That(car.FuelAmount, Is.EqualTo(20));
        }

        [Test]
        public void RefuelMethod_AddingFuel_ShoudNotOverflowFuelCapacity()
        {
            Car car = new Car("mazda", "626", 10, 100);

            car.Refuel(200);

            Assert.That(car.FuelAmount, Is.EqualTo(100));
        }

        [Test]
        public void RefuelMethod_AddingZero_ShoudReturnException()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }

        [Test]
        public void DriveMethod_MoreDistanceThanFuel_ShoudReturnException()
        {
            Car car = new Car("mazda", "626", 10, 100);

            Assert.That(() => car.Drive(1001), Throws.InvalidOperationException);
        }

        [Test]
        public void DriveMethod_DriveSomeKm_ShoudReturnLessFuelAmount()
        {
            Car car = new Car("mazda", "626", 10, 100);

            car.Refuel(100);
            car.Drive(100);

            Assert.That(90, Is.EqualTo(car.FuelAmount));
        }
    }
}