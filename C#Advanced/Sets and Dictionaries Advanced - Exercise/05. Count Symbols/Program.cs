using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> myDict = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!myDict.ContainsKey(text[i]))
                {
                    myDict.Add(text[i], 1);
                }
                else
                {
                    myDict[text[i]]++;
                }
            }

            foreach (var item in myDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
