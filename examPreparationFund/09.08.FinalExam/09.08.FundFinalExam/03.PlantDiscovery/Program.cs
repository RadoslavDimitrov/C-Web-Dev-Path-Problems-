using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> plants = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] currPlant = Console.ReadLine().Split("<->");
                string plantName = currPlant[0];
                int rarity = int.Parse(currPlant[1]);

                if (!plants.ContainsKey(plantName))
                {
                    //we make new plant with rarity
                    plants.Add(plantName, new List<double>());
                    plants[plantName].Add(rarity);
                }
                else
                {   //update rarity
                    plants[plantName].RemoveAt(0);
                    plants[plantName].Add(rarity);
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                List<string> currCommand = command.Split(new char[] { ':', '-'}, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < currCommand.Count; i++)
                {
                    
                    string temp = currCommand[i].Trim();
                    currCommand.RemoveAt(i);
                    currCommand.Insert(i, temp);
                }

                string plantName = currCommand[1];
                if (plants.ContainsKey(plantName))
                {
                    if (currCommand.Contains("Rate"))
                    {
                        double rating = double.Parse(currCommand[2]);
                        plants[plantName].Add(rating);
                    }
                    else if (currCommand.Contains("Update"))
                    {
                        double newRarity = double.Parse(currCommand[2]);
                        plants[plantName].RemoveAt(0);
                        plants[plantName].Insert(0, newRarity);
                    }
                    else if (currCommand.Contains("Reset"))
                    {
                        plants[plantName].RemoveRange(1, plants[plantName].Count - 1);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                
                


                command = Console.ReadLine();
            }

            double currSum = 0.0;
            int counter = 0;
            double currAverage = 0;

            foreach (var item in plants)
            {
                for (int i = 1; i < item.Value.Count; i++)
                {
                    currSum += item.Value[i];
                    counter++;
                }

                currAverage = currSum / counter;

                if(item.Value.Count > 1)
                {
                    item.Value.RemoveRange(1, item.Value.Count - 1);
                    item.Value.Add(currAverage);
                }
                else
                {
                    item.Value.Add(0);
                }

                currSum = 0;
                counter = 0;
                currAverage = 0;
            }


            plants = plants.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1])
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in plants)
            {
                Console.WriteLine($"- { kvp.Key}; Rarity: { kvp.Value[0]}; Rating: {kvp.Value[1]:F2}");
            }
               
            

            
        }
    }
}
