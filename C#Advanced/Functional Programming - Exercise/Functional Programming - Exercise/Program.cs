using System;
using System.Linq;

namespace Functional_Programming___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> returnName = str => Console.WriteLine(str);

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(returnName);
        }
    }
}
