using System;
using System.Collections.Generic;
using System.Linq;

namespace CSHarpAdvancedExam_22Feb2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> secondBox = new Stack<int>(secondNumbers);
            Queue<int> firstBox = new Queue<int>(firstNumbers);

            List<int> myLoot = new List<int>();

            while (true)
            {
                if(firstBox.Count == 0)
                {
                    break;
                }
                if(secondBox.Count == 0)
                {
                    break;
                }
                int firstNum = firstBox.Peek();
                int secondNum = secondBox.Peek();
                int result = firstNum + secondNum;
                if(result % 2 == 0)
                {
                    myLoot.Add(result);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int temp = secondBox.Pop();
                    firstBox.Enqueue(temp);
                }
            }

            if(firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int itemValue = myLoot.Sum();

            if(itemValue >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {itemValue}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {itemValue}");
            }
        }
    }
}
