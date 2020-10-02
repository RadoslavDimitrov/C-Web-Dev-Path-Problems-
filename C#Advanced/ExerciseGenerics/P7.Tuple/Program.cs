using System;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace P7.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] stringInput = Console.ReadLine().Split();
            string fullName = $"{stringInput[0]} {stringInput[1]}";
            string city = stringInput[2];
            string town;

            if(stringInput.Length > 4)
            {
                town = $"{stringInput[3]} {stringInput[4]}";
            }
            else
            {
                town = stringInput[3];
            }

            MyTuple<string, string, string> stringTuple = new MyTuple<string, string, string>(fullName, city, town);
            Console.WriteLine(stringTuple);

            string[] secondInput = Console.ReadLine().Split();
            bool isDrunk = false;
            if(secondInput[2].ToLower() == "drunk")
            {
                isDrunk = true;
            }
            MyTuple<string, double, bool> secondTuple = new MyTuple<string, double, bool>(secondInput[0],
                double.Parse(secondInput[1]), isDrunk);
            Console.WriteLine(secondTuple);

            string[] thirdInput = Console.ReadLine().Split();
            MyTuple<string, double, string> thirdTuple = new MyTuple<string, double, string>(thirdInput[0],
                double.Parse(thirdInput[1]), thirdInput[2]);
            Console.WriteLine(thirdTuple);
        }
    }
}
