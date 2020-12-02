namespace Robots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RobotManager
    {
        private List<Robot> robots;
        private int capacity;

        //TODO test -
        public RobotManager(int capacity)
        {
            //TODO test -
            this.robots = new List<Robot>();
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    //TODO test -
                    throw new ArgumentException("Invalid capacity!");
                }

                this.capacity = value;
            }
        }

        //TODO test -
        public int Count => this.robots.Count;

        public void Add(Robot robot)
        {
            if (this.robots.Any(r => r.Name == robot.Name))
            {
                //TODO test -
                throw new InvalidOperationException($"There is already a robot with name {robot.Name}!");
            }
            else if (this.robots.Count == this.capacity)
            {
                //TODO test -
                throw new InvalidOperationException("Not enough capacity!");
            }

            //TODO test -
            this.robots.Add(robot);
        }

        public void Remove(string name)
        {
            Robot robotToRemove = this.robots.FirstOrDefault(r => r.Name == name);

            if (robotToRemove == null)
            {
                //TODO test -
                throw new InvalidOperationException($"Robot with the name {name} doesn't exist!");
            }

            //TODO test -
            this.robots.Remove(robotToRemove);
        }

        public void Work(string robotName, string job, int batteryUsage)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            if (robot == null)
            {
                //TODO test -
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }
            else if (robot.Battery < batteryUsage)
            {
                //TODO test -
                throw new InvalidOperationException($"{robot.Name} doesn't have enough battery!");
            }

            //TODO test -
            robot.Battery -= batteryUsage;
        }

        public void Charge(string robotName)
        {
            Robot robot = this.robots.FirstOrDefault(r => r.Name == robotName);

            if (robot == null)
            {
                //TODO test -
                throw new InvalidOperationException($"Robot with the name {robotName} doesn't exist!");
            }

            //TODO test -
            robot.Battery = robot.MaximumBattery;
        }
    }
}
