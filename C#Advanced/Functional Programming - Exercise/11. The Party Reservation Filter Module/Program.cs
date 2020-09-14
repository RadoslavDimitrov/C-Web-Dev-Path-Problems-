using System;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            //read input

            //make while != Print
                    //split command
                    //switch or for loop for command[0]

        }

        public Predicate<string> GetPredicate(string filter, string argument)
        {
            switch (filter)
            {
                case "Starts with":
                    return name => name.StartsWith(argument);
                case "Ends sith":
                    return name => name.EndsWith(argument);
                case "Length":
                    return name => name.Length == int.Parse(argument);
                case "Contains":
                    return name => name.Contains(argument);
                default:
                    throw new ArgumentException("Invalid command " + filter);
                    break;
            }
        }
    }
}
