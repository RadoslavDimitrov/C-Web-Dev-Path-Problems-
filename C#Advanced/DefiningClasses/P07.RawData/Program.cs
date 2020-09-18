using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
                //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} 
                //{tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

                string model = input[0];
                double engineSpeed = double.Parse(input[1]);
                double enginePower = double.Parse(input[2]);
                double cargoWeight = double.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                double tire1Age = double.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                double tire2Age = double.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                double tire3Age = double.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                double tire4Age = double.Parse(input[12]);

                Car currCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType
                    , tire1Age, tire1Pressure, tire2Age, tire2Pressure, tire3Age, tire3Pressure
                    , tire4Age, tire4Pressure);

                carList.Add(currCar);
            }

            string command = Console.ReadLine();

            switch (command)
            {
                case "fragile":
                   carList = carList.Where(x => x.Cargo.CargoType == "fragile")
                        .Where(x => x.GetAveragePressure() < 1)
                        .ToList();
                    break;
                case "flamable":
                    carList = carList.Where(x => x.Cargo.CargoType == "flamable")
                        .Where(z => z.Engine.EnginePower > 250)
                        .ToList();
                    break;

            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }
    }
}
