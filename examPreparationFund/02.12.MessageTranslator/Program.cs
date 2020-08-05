using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _02._12.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<text>[A-Za-z ]{8,})\]";

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                bool isMatch = Regex.IsMatch(command, pattern);

                if(isMatch == false)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    Match currMatch = Regex.Match(command, pattern);

                    string textAsString = currMatch.Groups["text"].ToString();

                    char[] textAsChar = textAsString.Where(x => x != ' ').ToArray(); //arr from all letters

                    string currCommand = currMatch.Groups["command"].ToString(); //command

                    

                    Console.Write($"{currCommand}: ");
                    for (int k = 0; k < textAsChar.Length - 1; k++)
                    {
                        Console.Write((int)textAsChar[k] + " ");
                    }
                    Console.Write((int)textAsChar[textAsChar.Length - 1]);
                    Console.WriteLine();
                }
            }
        }
    }
}
