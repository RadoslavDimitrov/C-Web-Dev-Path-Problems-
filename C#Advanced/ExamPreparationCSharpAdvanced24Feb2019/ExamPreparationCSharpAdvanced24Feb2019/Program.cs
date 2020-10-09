using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreparationCSharpAdvanced24Feb2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stackInput = new Stack<string>(input);

            Queue<char> openedHalls = new Queue<char>();
            List<int> currResSum = new List<int>();

            while (stackInput.Count > 0)
            {
                var currPop = stackInput.Pop();
                var currPopAsCharArr = currPop.ToCharArray();

                if (char.IsLetter(currPopAsCharArr[0]))
                {
                    openedHalls.Enqueue(currPopAsCharArr[0]);
                    continue;
                }

                if(openedHalls.Count == 0)
                {
                    continue;
                }

                int currReservation = int.Parse(currPop);

                if(currResSum.Sum() + currReservation <= hallCapacity)
                {
                    currResSum.Add(currReservation);
                }
                else
                {
                    Console.WriteLine($"{openedHalls.Dequeue()} -> " + string.Join(", ", currResSum));
                    currResSum.Clear();

                    if (openedHalls.Count == 0)
                    {
                        continue;
                    }

                    if (currReservation > hallCapacity)
                    {
                        continue;
                    }
                    else
                    {
                        currResSum.Add(currReservation);
                    }
                }
            }
        }
    }
}
