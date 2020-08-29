using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> myStack = new Stack<int>(input);

            int rackCapacity = int.Parse(Console.ReadLine());

            int rackCounter = 1;
            int sum = 0;

            while (myStack.Count > 0)
            {
                int currValue = myStack.Peek();

                if(currValue + sum <= rackCapacity)
                {
                    sum += currValue;
                    myStack.Pop();
                    if(sum == rackCapacity)
                    {
                        if (myStack.Any())
                        {
                            rackCounter++;
                            sum = 0;
                        }
                       
                    }
                }
                else //sum > rackCapacity
                {
                    rackCounter++;
                    sum = 0;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
