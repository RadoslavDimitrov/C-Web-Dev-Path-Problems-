using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> myList = new Queue<string>(input);

            string command = Console.ReadLine();

            while (myList.Count > 0)
            {
                if (command.Contains("Play"))
                {
                    myList.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string songName = command.Remove(0, 4);
                    if (!myList.Contains(songName))
                    {
                        myList.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else //show --- print all
                {
                    List<string> myListAsList = new List<string>(myList);
                    Console.WriteLine(string.Join(", ", myListAsList));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
