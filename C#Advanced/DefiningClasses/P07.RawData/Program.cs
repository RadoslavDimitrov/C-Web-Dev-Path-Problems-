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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

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
                         //.Where(x => x.GetAveragePressure() < 1)
                         .Where(x => x.isLowerThanOnePressure() == true)
                        .ToList();
                    break;
                case "flamable":
                    carList = carList.Where(x => x.Cargo.CargoType == "flamable")
                        .Where(x => x.Engine.EnginePower > 250)
                        .ToList();
                    break;

            }

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }
    }
}
