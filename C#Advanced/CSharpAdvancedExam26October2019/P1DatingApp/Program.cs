using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace P1DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] malesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] femaleInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> males = new Stack<int>(malesInput);
            Queue<int> females = new Queue<int>(femaleInput);

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currMale = males.Peek();
                int currFemale = females.Peek();

                if(currMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                if(currMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }

                if(currFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if(currFemale % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    continue;
                }

                if(currMale == currFemale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    int temp = currMale - 2;
                    males.Pop();
                    males.Push(temp);
                    females.Dequeue();
                }

            }

            Console.WriteLine($"Matches: {matches}");

            if(males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }

            if(females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
