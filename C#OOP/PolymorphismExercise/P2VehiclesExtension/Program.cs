using PolymorphismExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P2VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstVehicle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondVehicle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] thirdVehicle = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Vehicle> list = new List<Vehicle>();

            Vehicle first = Factory.CreateVehicle(firstVehicle);
            Vehicle second = Factory.CreateVehicle(secondVehicle);
            Vehicle third = Factory.CreateVehicle(thirdVehicle);

            list.Add(first);
            list.Add(second);
            list.Add(third);

            int numOfCommands = int.Parse(Console.ReadLine());

            Vehicle vehicle = null;
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currType = command[0];
                string vehicleType = command[1];
                double litersOfDistance = double.Parse(command[2]);

                switch (currType.ToLower())
                {
                    case "drive":
                         vehicle = list.FirstOrDefault(x => x.GetType().Name == vehicleType);
                        Console.WriteLine(vehicle.Drive(litersOfDistance));
                        break;
                    case "driveempty":
                        vehicle = list.FirstOrDefault(x => x.GetType().Name == vehicleType);
                        Console.WriteLine(vehicle.DriveEmpty(litersOfDistance));
                        break;
                    case "refuel":
                        vehicle = list.FirstOrDefault(x => x.GetType().Name == vehicleType);
                        vehicle.Refuel(litersOfDistance);
                        break;

                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
