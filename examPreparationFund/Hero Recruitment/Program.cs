using System;
using System.Collections.Generic;
using System.Linq;

namespace Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            Dictionary<string, List<string>> heroList = new Dictionary<string, List<string>>();

            while (command != "End")
            {
                string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currCommand.Contains("Enroll"))
                {
                    string currHeroName = currCommand[1];

                    if (!heroList.ContainsKey(currHeroName))
                    {
                        heroList.Add(currHeroName, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{currHeroName} is already enrolled.");
                    }
                }
                else if (currCommand.Contains("Learn"))
                {
                    string heroName = currCommand[1];
                    string spellName = currCommand[2];

                    if (!heroList.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heroList[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        heroList[heroName].Add(spellName);
                    }

                }
                else if (currCommand.Contains("Unlearn"))
                {
                    string heroName = currCommand[1];
                    string spellName = currCommand[2];

                    if (!heroList.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if(heroList[heroName].Contains(spellName) == false)
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        heroList[heroName].Remove(spellName);
                    }
                }




                command = Console.ReadLine();
            }

            heroList = heroList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Heroes:");

            foreach (var item in heroList)
            {
                Console.Write($"== {item.Key}: ");
                Console.Write(string.Join(", ", item.Value));
                Console.WriteLine();
            }
        }
    }
}
