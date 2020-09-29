using P1GenericBoxString;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P1GenericBoxОfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var myList = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                var currBox = new Box<double>(double.Parse(Console.ReadLine()));

                myList.Add(currBox);
            }

            var itemToCompare = new Box<double>( double.Parse(Console.ReadLine()));

            int count = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                if (itemToCompare.IsLower(myList[i]))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }


    }
}
