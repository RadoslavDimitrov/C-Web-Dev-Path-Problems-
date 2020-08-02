using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());

            string input = string.Empty;

            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";

            for (int i = 0; i < numOfInputs; i++)
            {
                input = Console.ReadLine();

                bool isValid = Regex.IsMatch(input, pattern);

                if (isValid)
                {
                    var matches = Regex.Match(input, pattern);
                    //"{boss name}, The {title}
                    //>> Strength: { length of the name}
                    //>> Armour: { length of the title}"
                    Console.WriteLine($"{matches.Groups["name"]}, The {matches.Groups["title"]}");
                    Console.WriteLine($">> Strength: {matches.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {matches.Groups["title"].Length }");
                    

                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
