using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                myStack.Push(input[i]);
            }

            string[] command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                if(command[0] == "add")
                {
                    int num1 = int.Parse(command[1]);
                    int num2 = int.Parse(command[2]);

                    myStack.Push(num1);
                    myStack.Push(num2);
                }
                else if(command[0] == "remove")
                {
                    int numCount = int.Parse(command[1]);

                    if(numCount > myStack.Count)
                    {
                        command = Console.ReadLine().ToLower().Split();
                        continue;
                    }

                    for (int i = 0; i < numCount; i++)
                    {
                        myStack.Pop();
                    }
                }


                command = Console.ReadLine().ToLower().Split();
            }

            myStack.ToArray();

            int sum = 0;

            foreach (var item in myStack)
            {
                sum += item;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
