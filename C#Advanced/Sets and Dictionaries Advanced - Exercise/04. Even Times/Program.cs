using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, int> myDict = new Dictionary<string, int>();

            string input;

            for (int i = 0; i < lines; i++)
            {
                input = Console.ReadLine();

                if (!myDict.ContainsKey(input))
                {
                    myDict.Add(input, 1);
                }
                else
                {
                    myDict[input]++;
                }


            }

            foreach (var item in myDict)
            {
                if(item.Value % 2 == 0 && item.Value != 1)
                {
                    Console.WriteLine(item.Key);
                }
            }

            
        }
    }
}
