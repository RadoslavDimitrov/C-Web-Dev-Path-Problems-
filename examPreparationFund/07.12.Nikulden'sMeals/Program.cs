using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _07._12.Nikulden_sMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            int unlikedMeals = 0;

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] currCommand = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string currGuest = currCommand[1];
                string currMeal = currCommand[2];

                if(currCommand[0] == "Like")
                {
                    if (!guests.ContainsKey(currGuest)) //if the guest doesn't exist
                    {
                        guests.Add(currGuest, new List<string>());
                        guests[currGuest].Add(currMeal);
                    }
                    else if (!guests[currGuest].Contains(currMeal)) //if guest doesn't has the meal!
                    {
                        guests[currGuest].Add(currMeal);
                    }
                }
                else if(currCommand[0] == "Unlike")
                {
                    if (!guests.ContainsKey(currGuest)) //if guest doesn't exist!
                    {
                        Console.WriteLine($"{currGuest} is not at the party.");
                    }
                    else if (!guests[currGuest].Contains(currMeal)) //if guest doesn't has the meal!
                    {
                        Console.WriteLine($"{currGuest} doesn't have the {currMeal} in his/her collection.");
                    }
                    else
                    {
                        guests[currGuest].Remove(currMeal);
                        unlikedMeals++;
                        Console.WriteLine($"{currGuest} doesn't like the {currMeal}.");
                    }
                }


                command = Console.ReadLine();
            }

            guests = guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in guests)
            {
                Console.Write($"{kvp.Key}: ");
                Console.Write(string.Join(", ", kvp.Value));
                Console.WriteLine();
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }
    }
}
