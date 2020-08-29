using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int itemsToDequeue = input[1];
            int lookFor = input[2];

            int[] numInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> myQueue = new Queue<int>(numInput);

            for (int i = 0; i < itemsToDequeue; i++)
            {
                myQueue.TryDequeue(out int result);
            }

            if (myQueue.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else if(myQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(myQueue.Min());
            }
        }
    }
}
