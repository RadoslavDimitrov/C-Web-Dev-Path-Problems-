using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace P06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //"{model} {fuelAmount} {fuelConsumptionFor1km}"

            List<Car> carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = currInput[0];
                double currFuelAmount = double.Parse(currInput[1]);
                double currFuelConsumptionFor1km = double.Parse(currInput[2]);

                Car car = new Car(currModel, currFuelAmount, currFuelConsumptionFor1km);

                carList.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = currCommand[1];
                double currAmountOfKm = double.Parse(currCommand[2]);
                //"Drive {carModel} {amountOfKm}"
                int indexOfCar = carList.FindIndex(car => car.Model == currModel);
                double distanceLeft = carList[indexOfCar].DistanceLeft(carList[indexOfCar].FuelAmount
                    , carList[indexOfCar].FuelConsumptionPerKilometer);

                if(distanceLeft >= currAmountOfKm)
                {
                    carList[indexOfCar].FuelAmount -= currAmountOfKm * carList[indexOfCar].FuelConsumptionPerKilometer;
                    carList[indexOfCar].TravelledDistance += currAmountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }
    }
}
