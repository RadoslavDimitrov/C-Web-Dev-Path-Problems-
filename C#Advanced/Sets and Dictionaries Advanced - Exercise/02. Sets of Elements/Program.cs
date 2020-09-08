using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstAndSecondSetLength = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstLength = firstAndSecondSetLength[0];
            int secondLength = firstAndSecondSetLength[1];

            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondSet = new HashSet<string>();

            string input;

            for (int i = 0; i < firstLength; i++)
            {
                input = Console.ReadLine();
                firstSet.Add(input);
            }

            for (int i = 0; i < secondLength; i++)
            {
                input = Console.ReadLine();
                secondSet.Add(input);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
