using P4BorderControl;
using System;
using System.Collections.Generic;

namespace P5BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            BirthableList BList = new BirthableList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] currInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currName = currInput[1];

                switch (currInput[0])
                {
                    case "Citizen": //Citizen Pesho 22 9010101122 10/10/1990
                        int currAge = int.Parse(currInput[2]);
                        string currId = currInput[3];
                        string bDay = currInput[4];
                        IBirthable currCitizen = new Citizens(currName, currAge, currId, bDay);
                        BList.Add(currCitizen);
                        break;
                    case "Robot":
                        input = Console.ReadLine();
                        continue;
                    case "Pet": //"Pet <name> <birthdate" 
                        string currBDay = currInput[2];
                        IBirthable currPet = new Pet(currName, currBDay);
                        BList.Add(currPet);
                        break;

                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            List<IBirthable> listToPrint = BList.GetMatchedYear(year);

            if (listToPrint.Count > 0)
            {
                foreach (var item in listToPrint)
                {
                    Console.WriteLine(item.BirthDay);
                }
            }


        }
    }
}
