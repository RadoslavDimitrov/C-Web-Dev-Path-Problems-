using System;
using System.Collections;
using System.Collections.Generic;

namespace P6.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedPersons = new SortedSet<Person>();
            var hashPersons = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = command[0];
                int age = int.Parse(command[1]);

                var currP = new Person(name, age);

                sortedPersons.Add(currP);
                hashPersons.Add(currP);
            }

            Console.WriteLine(sortedPersons.Count);
            Console.WriteLine(hashPersons.Count);
        }
    }
}
