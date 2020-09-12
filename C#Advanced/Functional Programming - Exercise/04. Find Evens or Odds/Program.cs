using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isOddOrEven = x => x % 2 == 0; //true == even, false == odd

            int[] bonds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            List<int> nums = new List<int>();

            for (int i = bonds[0]; i <= bonds[1]; i++)
            {
                if(command.ToLower() == "odd")
                {
                    if (!isOddOrEven(i))
                    {
                        nums.Add(i);
                    }
                }
                else
                {
                    if (isOddOrEven(i))
                    {
                        nums.Add(i);

                    }
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
