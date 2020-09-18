using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            double result = DateModifier.GetDaysBetween(dateOne, dateTwo);
            Console.WriteLine(Math.Abs(result));
        }
    }
}
