using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._12.InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] currCommand = command.Split("->", StringSplitOptions.RemoveEmptyEntries);

                if (currCommand.Contains("Add"))
                {
                    //add user
                    if (users.ContainsKey(currCommand[1]))
                    {
                        Console.WriteLine($"{currCommand[1]} is already registered");
                    }
                    else
                    {
                        users.Add(currCommand[1], new List<string>());
                    }

                
                }
                else if (currCommand.Contains("Send"))
                {
                    //send User Email
                    if (users.ContainsKey(currCommand[1]))
                    {
                        users[currCommand[1]].Add(currCommand[2]);
                    }
                }
                else
                {
                    //Delete user
                    if (users.ContainsKey(currCommand[1]))
                    {
                        users.Remove(currCommand[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{currCommand[1]} not found!");
                    }
                }




                command = Console.ReadLine();
            }

            users = users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Users count: { users.Count}");

            //for (int i = 0; i < users.Count; i++)
            //{
                foreach (var item in users)
                {
                    Console.WriteLine($"{item.Key}");
                    foreach (var kvp in item.Value)
                    {
                        Console.WriteLine($" - {kvp}");
                    }
                }
            //}
        }
    }
}
