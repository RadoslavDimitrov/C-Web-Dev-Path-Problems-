using System;
using System.Text.RegularExpressions;

namespace _07._12.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"U\$(?<name>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[0-9]+)P@\$";

            int countValid = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                bool isValid = Regex.IsMatch(input, pattern);

                if (isValid)
                {
                    countValid++;
                    Match match = Regex.Match(input, pattern);

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["name"]}, Password: {match.Groups["password"]}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {countValid}");
        }
    }
}
