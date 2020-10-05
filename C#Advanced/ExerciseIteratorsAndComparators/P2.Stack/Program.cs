using System;
using System.Collections.Generic;
using System.Linq;

namespace P2.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command.Contains("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch(ArgumentException ae)
                    {
                        Console.WriteLine("No elements");
                    }
                }
                else //push command
                {
                    string arrWithCommand = command.Remove(0, 5);
                    int[] arr = arrWithCommand.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    stack.Push(arr);
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }

            }
            
        }
    }
}
