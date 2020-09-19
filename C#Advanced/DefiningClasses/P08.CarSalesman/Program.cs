using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace P08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfengines = int.Parse(Console.ReadLine());

            List<Engine> engineList = new List<Engine>();

            for (int i = 0; i < numOfengines; i++)
            {
                //"{model} {power} {displacement} {efficiency}"
                string[] currInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = currInput[0];
                int currPower = int.Parse(currInput[1]);
                CheckLengthAndCreateEngine(engineList, currInput, currModel, currPower);
            }

            int numOfCars = int.Parse(Console.ReadLine());

            List<Car> carsList = new List<Car>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currModel = input[0];
                string currEngineModel = input[1];
                int engineIndex = engineList.FindIndex(x => x.Model == currEngineModel);

                //"{model} {engine} {weight - int} {color - string}" 

                CreateAndAddCars(engineList, carsList, input, currModel, engineIndex);

            }

            Console.WriteLine(string.Join(Environment.NewLine, carsList));
        }

        private static void CreateAndAddCars(List<Engine> engineList, List<Car> carsList, string[] input, string currModel, int engineIndex)
        {
            if (input.Length == 2)
            {
                Car car = new Car(currModel, engineList[engineIndex]);
                carsList.Add(car);
            }
            else if (input.Length == 3)
            {
                int currWeight = int.MinValue;

                if(int.TryParse(input[2], out currWeight))
                {
                    Car car = new Car(currModel, engineList[engineIndex], int.Parse(input[2]));
                    carsList.Add(car);
                }
                else
                {
                    Car car = new Car(currModel, engineList[engineIndex], input[2]);
                    carsList.Add(car);
                }

                //if (currWeight > 0) //we have weight
                //{
                //    Car car = new Car(currModel, engineList[engineIndex], int.Parse(input[2]));
                //    carsList.Add(car);
                //}
                //else //we have color
                //{
                //    Car car = new Car(currModel, engineList[engineIndex], input[2]);
                //    carsList.Add(car);
                //}
            }
            else //we have all parameters
            {
                Car car = new Car(currModel, engineList[engineIndex], int.Parse(input[2]), input[3]);
                carsList.Add(car);
            }
        }

        private static void CheckLengthAndCreateEngine(List<Engine> engineList, string[] currInput, string currModel, int currPower)
        {
            if (currInput.Length == 2)
            {
                Engine currEngine = new Engine(currModel, currPower);
                engineList.Add(currEngine);
            }
            else if (currInput.Length == 3)
            {
                int currDisplacement = int.MinValue;
                if (int.TryParse(currInput[2], out currDisplacement))
                {
                    Engine currEngine = new Engine(currModel, currPower, currDisplacement);
                    engineList.Add(currEngine);
                }
                else
                {
                    Engine currEngine = new Engine(currModel, currPower, currInput[2]);
                    engineList.Add(currEngine);
                }

                //if (currDisplacement > int.MinValue) // we have displacement
                //{
                //    Engine currEngine = new Engine(currModel, currPower, currDisplacement);
                //    engineList.Add(currEngine);
                //}
                //else //we have eff
                //{
                //    Engine currEngine = new Engine(currModel, currPower, currInput[2]);
                //    engineList.Add(currEngine);
                //}
            }
            else //we have all parameters
            {
                Engine currEngine = new Engine(currModel, currPower, int.Parse(currInput[2]), currInput[3]);
                engineList.Add(currEngine);
            }
        }
    }
}
