using System;
using System.Linq;

namespace _07._12.Nikulden_sCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currCommand.Contains("Replace"))
                {
                    text = ReplaceChar(text, currCommand);
                }
                else if (currCommand.Contains("Cut"))
                {
                    text = CutPartOfText(text, currCommand);
                }
                else if (currCommand.Contains("Make"))
                {
                    text = ChangeToLowerOrUpper(text, currCommand);
                }
                else if (currCommand.Contains("Check"))
                {
                    CheckForSubstring(text, currCommand);
                }
                else if (currCommand.Contains("Sum"))
                {
                    SumOfSubstring(text, currCommand);
                }

                command = Console.ReadLine();
            }
        }

        private static void SumOfSubstring(string text, string[] currCommand)
        {
            int startIndex = int.Parse(currCommand[1]);
            int endIndex = int.Parse(currCommand[2]);

            if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
            {
                if (startIndex <= endIndex)
                {
                    int length = endIndex - startIndex + 1;
                    string sub = text.Substring(startIndex, length);

                    char[] subToCharArr = sub.ToCharArray();

                    int sum = 0;

                    for (int i = 0; i < subToCharArr.Length; i++)
                    {
                        sum += subToCharArr[i];
                    }

                    Console.WriteLine(sum);
                }
                else
                {
                    Console.WriteLine("Invalid indexes!");
                }
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }
        }

        private static void CheckForSubstring(string text, string[] currCommand)
        {
            string strToCheck = currCommand[1];

            if (text.Contains(strToCheck))
            {
                Console.WriteLine($"Message contains {strToCheck}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {strToCheck}");
            }
        }

        private static string ChangeToLowerOrUpper(string text, string[] currCommand)
        {
            string lowerOrUpper = currCommand[1];

            if (lowerOrUpper == "Upper")
            {
                text = text.ToUpper();
                Console.WriteLine(text);
            }
            else
            {
                text = text.ToLower();
                Console.WriteLine(text);
            }

            return text;
        }

        private static string CutPartOfText(string text, string[] currCommand)
        {
            int startIndex = int.Parse(currCommand[1]);
            int endIndex = int.Parse(currCommand[2]);

            if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
            {
                if (startIndex <= endIndex)
                {
                    int length = endIndex - startIndex + 1;

                    text = text.Remove(startIndex, length);
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine("Invalid indexes!");
                }
            }
            else
            {
                Console.WriteLine("Invalid indexes!");
            }

            return text;
        }

        private static string ReplaceChar(string text, string[] currCommand)
        {
            string currChar = currCommand[1];
            string newChar = currCommand[2];

            text = text.Replace(currChar, newChar);
            Console.WriteLine(text);
            return text;
        }
    }
}
