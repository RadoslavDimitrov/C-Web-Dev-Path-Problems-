using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvancedExam25October2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[] threads = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasksAsStack = new Stack<int>(tasks);
            Queue<int> threadsAsQueue = new Queue<int>(threads);

            while (true)
            {
                int currTask = tasksAsStack.Peek();
                int currThread = threadsAsQueue.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
                    tasksAsStack.Pop();
                    break;

                }

                if (currThread >= currTask)
                {
                    tasksAsStack.Pop();
                    threadsAsQueue.Dequeue();
                }
                else if (currThread < currTask)
                {
                    threadsAsQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threadsAsQueue));
        }
    }
}
