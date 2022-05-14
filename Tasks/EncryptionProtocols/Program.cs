using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionProtocols
{
    class Program
    {
        static void Main(string[] args)
        {
            //read input
            char[] data = Console.ReadLine().TrimEnd().ToCharArray();

            //initialize collections to separate digits from letters
            Stack<int> digits = new Stack<int>();
            Queue<char> letters = new Queue<char>();

            //fill digits and letters collections
            for (int i = 0; i < data.Length; i++)
            {
                if (Char.IsLetter(data[i]))
                {
                    letters.Enqueue(data[i]);
                }
                else
                {
                    digits.Push(int.Parse(data[i].ToString()));
                }
            }

            var result = new StringBuilder();

            var digitsCount = digits.Count;

            for (int j = 0; j < digitsCount; j++)
            {
                var currDigit = digits.Pop();

                if(currDigit % 2 == 0)
                {
                    result.Append(currDigit - 1);
                }
                else
                {
                    result.Append(currDigit + 1);
                }

                if(letters.Count > 0)
                {
                    result.Append(letters.Dequeue());
                }
            }

            while (letters.Count > 0)
            {
                result.Append(letters.Dequeue());
            }

            Console.WriteLine(result.ToString());
        }
    }
}
