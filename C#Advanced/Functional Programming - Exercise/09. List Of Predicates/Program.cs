using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, bool> isDivided = (x, y) => x % y == 0; //true -> print

            List<int> output = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                bool addToOutput = true;

                for (int currDivider = 0; currDivider < dividers.Length; currDivider++)
                {
                    if(!isDivided(i, dividers[currDivider]))
                    {
                        addToOutput = false;
                    }
                }

                if (addToOutput)
                {
                    output.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
