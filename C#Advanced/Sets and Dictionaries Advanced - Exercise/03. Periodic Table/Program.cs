using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> myTable = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int currInput = 0; currInput < input.Length; currInput++)
                {
                    myTable.Add(input[currInput]);
                }
            }

            Console.WriteLine(string.Join(" ",myTable));
        }
    }
}
