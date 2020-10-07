using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var myLake = new Lake(myList);

            StringBuilder sb = new StringBuilder();
            foreach (var item in myLake)
            {
                sb.Append(item + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb.ToString());
        }
    }
}
