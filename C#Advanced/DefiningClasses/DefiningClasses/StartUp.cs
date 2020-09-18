using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split();

                Person person = new Person(int.Parse(currInput[1]), currInput[0]);

                people.Add(person);
            }

            people = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}
