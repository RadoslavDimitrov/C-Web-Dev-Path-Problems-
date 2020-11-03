using System;
using System.Text;

namespace PolymorphismExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] currCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string comLine = (currCommand[0] + currCommand[1]).ToLower();

                double litersOrDistance = double.Parse(currCommand[2]);

                switch (comLine)
                {
                    case "drivecar":
                        sb.AppendLine(car.Drive(litersOrDistance));
                        break;
                    case "drivetruck":
                        sb.AppendLine(truck.Drive(litersOrDistance));
                        break;
                    case "refuelcar":
                        car.Refuel(litersOrDistance);
                        break;
                    case "refueltruck":
                        truck.Refuel(litersOrDistance);
                        break;

                }
            }

            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

    }
}
