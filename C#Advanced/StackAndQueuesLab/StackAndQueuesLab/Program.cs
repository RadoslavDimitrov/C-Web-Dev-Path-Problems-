using System;
using System.Collections.Generic;
using System.Transactions;

namespace StackAndQueuesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reverseMe = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reverseMe.Push(input[i]);
            }

            Console.WriteLine(reverseMe.ToArray());



            //Simple example
            //string input = Console.ReadLine();
            //Stack<char> myStack = new Stack<char>(input.ToCharArray());

            //Console.WriteLine(myStack.ToArray());
        }
    }
}
