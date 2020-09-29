using System;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace P7.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringInput = Console.ReadLine().Split();
            string fullName = $"{stringInput[0]} {stringInput[1]}";
            MyTuple<string, string> stringTuple = new MyTuple<string, string>(fullName, stringInput[2]);
            Console.WriteLine(stringTuple);

            string[] secondInput = Console.ReadLine().Split();
            MyTuple<string, int> secondTuple = new MyTuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
            Console.WriteLine(secondTuple);

            string[] numsInput = Console.ReadLine().Split();
            MyTuple<int, double> numTuple = new MyTuple<int, double>(int.Parse(numsInput[0]), double.Parse(numsInput[1]));
            Console.WriteLine(numTuple);
        }
    }
}
