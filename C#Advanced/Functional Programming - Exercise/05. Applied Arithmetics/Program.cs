using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> add = x => x.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = x => x.Select(y => y * 2).ToList();
            Func<List<int>, List<int>> subtract = x => x.Select(y => y - 1).ToList();
            Func<List<int>, string> print = x => String.Join(" ", x);

            Action<List<int>, string> ApplyArithmetics = (nums, opr) =>
            {
                if (opr == "add")
                {
                    numbers = add(nums);
                }
                else if (opr == "multiply")
                {
                    numbers = multiply(nums);
                }
                else if (opr == "subtract")
                {
                    numbers = subtract(nums);
                }
                else if (opr == "print")
                {
                    Console.WriteLine(print(nums));
                }
            };

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                ApplyArithmetics(numbers, command);
                command = Console.ReadLine().ToLower();
            }
        }
    }
}