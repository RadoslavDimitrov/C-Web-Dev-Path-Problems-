using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            Func<string, int, bool> isEnoughtLength = (word, length) => word.Length <= length;

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if(isEnoughtLength(words[i], nameLength))
                {
                    Console.WriteLine(words[i]);
                }
            }
        }
    }
}
