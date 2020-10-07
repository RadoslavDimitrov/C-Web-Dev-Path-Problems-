using System;
using System.Collections.Generic;

namespace P5.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var personData = new List<Person>();

            while (input != "END")
            {
                string[] currInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currName = currInput[0];
                int currAge = int.Parse(currInput[1]);
                string currCity = currInput[2];

                var currPerson = new Person(currName, currAge, currCity);

                personData.Add(currPerson);

                input = Console.ReadLine();
            }

            int numOfPersonToCompare = int.Parse(Console.ReadLine()) - 1;

            int equalPersons = 0;
            int notEqualPersons = 0;

            for (int i = 0; i < personData.Count; i++)
            {
                if (personData[numOfPersonToCompare].CompareTo(personData[i]) == 0)
                {
                    equalPersons++;
                }
                else
                {
                    notEqualPersons++;
                }
            }

            if(equalPersons == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPersons} {notEqualPersons} {personData.Count}");
            }
            

            //Console.WriteLine(p1.CompareTo(p3)); // 1 - p1 is bigger than p3
        }
    }
}
