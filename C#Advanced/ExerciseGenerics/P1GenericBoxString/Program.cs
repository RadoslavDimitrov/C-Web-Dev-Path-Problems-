using System;

namespace P1GenericBoxОfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currStr = Console.ReadLine();

                var myBox = new Box<string>(currStr);

                Console.WriteLine(myBox.ToString());
            }
        }
    }
}
