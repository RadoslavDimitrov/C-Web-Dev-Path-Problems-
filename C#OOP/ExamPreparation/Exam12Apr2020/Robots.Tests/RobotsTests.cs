namespace Robots.Tests
{
    using NUnit;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {

        [Test]
        public void Contructor_ShouldInitializeCapacity()
        {
            //Arrange
            var robotManager = new RobotManager(2);


            //Assert
            Assert.AreEqual(2, robotManager.Capacity);
        }

        [Test]
        public void Contructor_InvalidValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-2));
        }

        [Test]
        public void Count_ShouldReturnProperCount()
        {
            //Arrange
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(2);
            robotManager.Add(robot);
            //act


            //Assert
            Assert.AreEqual(1, robotManager.Count);
        }


        [Test]
        public void Add_RobotSameName_ShoudThrowInvalidOperationException()
        {
            //Arrange
            var robotOne = new Robot("Pesho", 10);
            var robotManager = new RobotManager(2);

            //act
            robotManager.Add(robotOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotOne));
        }

        [Test]
        public void Add_TwoRobotsCapacityOne_ShoudThrowInvalidOperationException()
        {
            //Arrange
            var robotOne = new Robot("Pesho", 10);
            var robotTwo = new Robot("Gosho", 5);
            var robotManager = new RobotManager(1);

            //act
            robotManager.Add(robotOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robotTwo));
        }

        [Test]
        public void Remove_RobotNull_ShoudThrowInvalidOperationException()
        {
            //Arrange
            var robotManager = new RobotManager(2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("Gosho"));
        }

        [Test]
        public void Remove_ShoudRemoveRobot()
        {
            //Arrange
            var robotOne = new Robot("Pesho", 10);
            var robotTwo = new Robot("Gosho", 5);
            var robotManager = new RobotManager(2);

            //act
            robotManager.Add(robotOne);
            robotManager.Add(robotTwo);
            robotManager.Remove("Pesho");

            int expectedCount = 1;
            int actualCount = robotManager.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Work_NullRobot_ShoudThrowInvalidOperationException()
        {
            var robotManager = new RobotManager(2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "Dig", 5));
        }

        [Test]
        public void Work_LowerBattery_ShoudThrowInvalidOperationException()
        {
            //Arrange
            var robotTwo = new Robot("Gosho", 5);
            var robotManager = new RobotManager(2);
            robotManager.Add(robotTwo);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gosho", "Dig", 10));
        }

        [Test]
        public void Work_ShoudDecreaseBattery()
        {
            //Arrange
            var robotOne = new Robot("Pesho", 10);
            var robotManager = new RobotManager(2);

            //act
            robotManager.Add(robotOne);
            robotManager.Work(robotOne.Name, "Dig", 5);


            //Assert
            Assert.AreEqual(5, robotOne.Battery);
        }

        [Test]
        public void Charge_NullRobot_ShoudThrowInvalidOperationException()
        {
            var robotManager = new RobotManager(2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Gosho"));
        }


        [Test]
        public void Charge_ShoudIncreaseBatteryToMaxCapacity()
        {
            //Arrange
            var robotOne = new Robot("Pesho", 10);
            var robotManager = new RobotManager(2);

            //act
            robotManager.Add(robotOne);
            robotManager.Work(robotOne.Name, "Dig", 5);
            robotManager.Charge("Pesho");


            //Assert
            Assert.AreEqual(10, robotOne.Battery);
        }
    }
}
