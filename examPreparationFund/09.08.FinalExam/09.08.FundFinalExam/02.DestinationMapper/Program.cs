using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            //string pattern = @"(=|\/)(?<name>[A-Z][a-z]{2,})\1";
            string pattern = @"(={1}|\/{1})(?<name>[A-Z][A-Za-z]{2,})(\1)";

            MatchCollection matches = Regex.Matches(text, pattern);

            var matchesInList = matches.ToList();

            List<string> clearMatches = new List<string>();

            int travelPoints = 0;

            for (int i = 0; i < matchesInList.Count; i++)
            {
                string currStr = matchesInList[i].ToString();

                currStr = currStr.Trim(new char[] { '=', '/' });

                clearMatches.Add(currStr);

                travelPoints += currStr.Length;
            }

            if(matches.Count > 0)
            {
                Console.Write($"Destinations: " + string.Join(", ", clearMatches));
            }
            else
            {
                Console.Write("Destinations:");
            }
            
            Console.WriteLine(); 
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
