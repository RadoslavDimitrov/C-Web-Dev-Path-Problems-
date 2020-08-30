using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal numOfStations = decimal.Parse(Console.ReadLine());

            decimal startPomp = 0;
            decimal fuelLeft = 0;

            for (int i = 0; i < numOfStations; i++)
            {
                List<decimal> pair = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();

                decimal petrol = pair[0];
                decimal nextPomp = pair[1];

                fuelLeft += petrol;

                if(fuelLeft >= nextPomp)
                {
                    fuelLeft -= nextPomp;
                }
                else
                {
                    startPomp = i + 1;
                    fuelLeft = 0;
                }
            }

            Console.WriteLine(startPomp);
        }


        
    }
}
