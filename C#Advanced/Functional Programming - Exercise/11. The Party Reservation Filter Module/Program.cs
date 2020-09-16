using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            //read input
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> filters = new List<string>();


            //make while != Print

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] currCommand = command.Split(new char[] {';' }, StringSplitOptions.RemoveEmptyEntries);

                switch (currCommand[0])
                {
                    case "Add filter":
                        filters.Add(currCommand[1] + " " + currCommand[2]);
                        break;
                    case "Remove filter":
                        filters.Remove(currCommand[1] + " " + currCommand[2]);
                        break;

                }

                command = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                var commands = filter.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Starts":
                        input = input.Where(x => !x.StartsWith(commands[2])).ToList();
                        break;
                    case "Ends":
                        input = input.Where(x => !x.EndsWith(commands[2])).ToList();
                        break;
                    case "Length":
                        input = input.Where(x => x.Length != int.Parse(commands[1])).ToList();
                        break;
                    case "Contains":
                        input = input.Where(x => !x.Contains(commands[1])).ToList();
                        break;

                }
            }

            if (input.Any())
            {
                Console.WriteLine(string.Join(" ", input));
            }
        }

        
    }
}
