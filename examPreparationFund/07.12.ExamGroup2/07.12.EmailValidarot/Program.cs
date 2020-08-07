using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _07._12.EmailValidarot
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Complete")
            {
                string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currCommand.Contains("Upper"))
                {
                    //to upper
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (currCommand.Contains("Lower"))
                {
                    //to lower
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (currCommand.Contains("GetDomain"))
                {
                    //print the last "count" chars
                    int count = int.Parse(currCommand[1]);

                    int diff = text.Length - count;

                    for (int i = diff; i < text.Length; i++)
                    {
                        Console.Write(text[i]);
                    }

                    Console.WriteLine();
                }
                else if (currCommand.Contains("GetUsername"))
                {
                    //print userName, if not print ...
                    if (text.Contains("@"))
                    {
                        int symbol = text.LastIndexOf('@');

                        for (int i = 0; i < symbol; i++)
                        {
                            Console.Write(text[i]);
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"The email {text} doesn't contain the @ symbol.");
                    }
                }
                else if (currCommand.Contains("Replace"))
                {
                    //replace curr char
                    char currChar = char.Parse(currCommand[1]);

                    text = text.Replace(currChar, '-');
                    Console.WriteLine(text);
                }
                else if (currCommand.Contains("Encrypt"))
                {
                    //get ASCII value
                    char[] textAsChar = text.ToCharArray();

                    foreach (var item in textAsChar)
                    {
                        Console.Write((int)item + " ");
                    }

                    Console.WriteLine();
                }



                command = Console.ReadLine();
            }
        }
    }
}
