using System;
using System.Linq;
using System.Xml;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> returnSmallest = num =>
            {

                int min = int.MaxValue;
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i] < min)
                    {
                        min = num[i];
                    }
                }
                

                return min;
            };

            var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            int num = returnSmallest(nums.ToArray());

            Console.WriteLine(num);
        }
    }
}
