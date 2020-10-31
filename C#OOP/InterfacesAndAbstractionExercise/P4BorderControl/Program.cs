using System;
using System.Collections.Generic;

namespace P4BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            EntryList enteredPpl = new EntryList();

            while (input != "End")
            {
                string[] currInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currName = currInput[0];

                if (currInput.Length == 3) //citizen
                {
                    int currAge = int.Parse(currInput[1]);
                    string currId = currInput[2];

                    CheckIds currCitizen = new Citizens(currName, currAge, currId);
                    enteredPpl.Add(currCitizen);
                }
                else //robot
                {
                    string currId = currInput[1];

                    CheckIds currRobot = new Robots(currName, currId);
                    enteredPpl.Add(currRobot);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            List<CheckIds> fakeIdList = enteredPpl.GetFakeIds(fakeId);

            foreach (var item in fakeIdList)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
