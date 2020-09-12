using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> appendSirInName = str => Console.WriteLine($"Sir {str}");

            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(appendSirInName);
        }
    }
}
