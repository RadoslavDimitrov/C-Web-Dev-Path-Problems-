using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currInput = Console.ReadLine().Split();

                Person person = new Person(int.Parse(currInput[1]), currInput[0]);

                family.AddMember(person);
            }

            var oldest = family.GetGetOldestMember();

            Console.WriteLine(oldest);

            
        }
    }
}
