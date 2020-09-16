using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isGreaterSum = (name, num) => name.ToCharArray()
            .Select(ch => (int)ch).Sum() >= num;

            Func<List<string>, int, Func<string, int, bool>, string> combineName = (names, num, func) =>
            names.FirstOrDefault(str => func(str, num));

            var result = combineName(input, number, isGreaterSum);
            Console.WriteLine(result);
            

            
            
        }
    }
}
