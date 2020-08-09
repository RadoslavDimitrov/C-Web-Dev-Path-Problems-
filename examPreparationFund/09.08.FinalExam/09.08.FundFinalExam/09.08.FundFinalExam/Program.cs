using System;
using System.Linq;

namespace _09._08.FundFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] currCommand = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (currCommand.Contains("Add Stop"))
                {
                    //add stop
                    stops = AddPartAndPrint(stops, currCommand);
                }
                else if (currCommand.Contains("Remove Stop"))
                {
                    //remove from index to index
                    stops = RemovePartAndPrint(stops, currCommand);
                }
                else if (currCommand.Contains("Switch"))
                {
                    //switch old substr to new substr - all matches
                    stops = SwitchPartAndPrint(stops, currCommand);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }

        private static string SwitchPartAndPrint(string stops, string[] currCommand)
        {
            string oldSub = currCommand[1];
            string newSub = currCommand[2];

            if (stops.Contains(oldSub))
            {
                stops = stops.Replace(oldSub, newSub);
                Console.WriteLine(stops);
            }
            else
            {
                Console.WriteLine(stops);
            }

            return stops;
        }

        private static string AddPartAndPrint(string stops, string[] currCommand)
        {
            int index = int.Parse(currCommand[1]);
            string strToInsert = currCommand[2];

            if(index >= 0 && index < stops.Length)
            {
                stops = stops.Insert(index, strToInsert);
                Console.WriteLine(stops);
                
            }
            else
            {
                Console.WriteLine(stops);
            }

            return stops;

            
        }

        private static string RemovePartAndPrint(string stops, string[] currCommand)
        {
            int startIndex = int.Parse(currCommand[1]);
            int endIndex = int.Parse(currCommand[2]);

            int diff = endIndex - startIndex + 1;

            if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
            {
                if (startIndex <= endIndex)
                {
                    stops = stops.Remove(startIndex, diff);
                    Console.WriteLine(stops);
                }
                else
                {
                    Console.WriteLine(stops);
                }

                
            }
            else
            {
                Console.WriteLine(stops);
            }

            return stops;
        }
    }
}
