using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double, bool> isDivisable = (z, y) => z % y != 0;

            List<double> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            double delimetur = double.Parse(Console.ReadLine());

            Func<List<double>, List<double>> reverse = x =>
            {
                List<double> reversedArr = new List<double>();

                for (int i = x.Count - 1; i >= 0 ; i--)
                {
                    if(isDivisable(x[i], delimetur))
                    {
                        reversedArr.Add(x[i]);
                    }
                    
                }

                return reversedArr;
            };

            Console.WriteLine(string.Join(" ", reverse(input)));
        }
    }
}
