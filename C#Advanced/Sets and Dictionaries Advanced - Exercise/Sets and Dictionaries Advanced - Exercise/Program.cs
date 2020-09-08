using System;
using System.Collections.Generic;

namespace Sets_and_Dictionaries_Advanced___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());

            HashSet<string> mySet = new HashSet<string>();

            for (int i = 0; i < numOfInputs; i++)
            {
                string input = Console.ReadLine();

                mySet.Add(input);
            }

            Console.WriteLine(string.Join(Environment.NewLine, mySet));
        }
    }
}
