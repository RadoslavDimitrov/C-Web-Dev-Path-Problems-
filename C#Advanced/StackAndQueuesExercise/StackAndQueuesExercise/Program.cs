using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueuesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numToPush = input[0];
            int numToPop = input[1];
            int lookForNum = input[2];

            int[] numsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(numsInput);

            for (int i = 0; i < numToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(lookForNum))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
