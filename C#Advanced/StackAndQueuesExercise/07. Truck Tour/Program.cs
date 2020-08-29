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
            int numPompStation = int.Parse(Console.ReadLine());

            Queue<int> amountPetrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int i = 0; i < numPompStation; i++)
            {
                int[] currPomp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                amountPetrol.Enqueue(currPomp[0]);
                distance.Enqueue(currPomp[1]);
            }

            int indexCounter = 0;
            int counter = numPompStation;
            int left = 0;

            while (true)
            {
                int currPetrol = amountPetrol.Dequeue();
                int currDistance = distance.Dequeue();
                
                
                if((left + currPetrol) - currDistance >= 0)
                {
                    int currLeft = currPetrol - currDistance;
                    left += currLeft;
                    counter--;
                    amountPetrol.Enqueue(currPetrol);
                    distance.Enqueue(currDistance);
                }
                else
                {
                    indexCounter++;
                    counter = numPompStation;
                    amountPetrol.Enqueue(currPetrol);
                    distance.Enqueue(currDistance);
                }

                if(counter == 0)
                {
                    Console.WriteLine(indexCounter);
                    return;
                }
            }
        }


        
    }
}
