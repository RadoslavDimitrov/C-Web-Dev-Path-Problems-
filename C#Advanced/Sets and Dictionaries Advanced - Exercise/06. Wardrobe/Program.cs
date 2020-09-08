using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] currInput = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = currInput[0];

                string[] dresses = currInput[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    for (int currDress = 0; currDress < dresses.Length; currDress++)
                    {
                        if (!wardrobe[color].ContainsKey(dresses[currDress]))
                        {
                            wardrobe[color].Add(dresses[currDress], 1);
                        }
                        else
                        {
                            wardrobe[color][dresses[currDress]]++;
                        }
                    }

                }
                else
                {
                    for (int currDress = 0; currDress < dresses.Length; currDress++)
                    {
                        if (!wardrobe[color].ContainsKey(dresses[currDress]))
                        {
                            wardrobe[color].Add(dresses[currDress], 1);
                        }
                        else
                        {
                            wardrobe[color][dresses[currDress]]++;
                        }
                    }
                }
            }

            string[] lookinFor = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string lookColor = lookinFor[0];
            string lookDress = lookinFor[1];

            foreach (var item in wardrobe)
            {
                if(item.Key == lookColor)
                {
                    Console.WriteLine($"{item.Key} clothes:");

                    foreach (var cloth in item.Value)
                    {
                        if(cloth.Key == lookDress)
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine($"{item.Key} clothes:");

                    foreach (var cloth in item.Value)
                    {
                        
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                    }
                }
            }
        }
    }
}
