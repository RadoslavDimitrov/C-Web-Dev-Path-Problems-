using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] currCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if(currCommand[0] == 1)
                {
                    myStack.Push(currCommand[1]);
                }
                else if(currCommand[0] == 2)
                {
                    myStack.Pop();
                }
                else if(currCommand[0] == 3)
                {
                    if(myStack.Count > 0)
                    {
                        Console.WriteLine(myStack.Max());
                    }
                }
                else if(currCommand[0] == 4)
                {
                    if(myStack.Count > 0)
                    {
                        Console.WriteLine(myStack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", myStack));
        }
    }
}
