using P4BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P6FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numOfInput = int.Parse(Console.ReadLine());
            List<IBuyer> ppl = new List<IBuyer>();
            for (int i = 0; i < numOfInput; i++)
            {
                string[] currInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string currName = currInput[0];
                int currAge = int.Parse(currInput[1]);
                string idOrGroup = currInput[2];

                if(currInput.Length == 4) //"<name> <age> <id> <birthdate>"  - citizen
                {
                    string BDay = currInput[3];
                    IBuyer currCitizen = new Citizens(currName, currAge, idOrGroup, BDay);
                    ppl.Add(currCitizen);
                }
                else //"<name> <age><group>" - Rebel
                {
                    IBuyer currRebel = new Rebel(currName, currAge, idOrGroup);
                    ppl.Add(currRebel);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string currName = command;

                IBuyer currObject = ppl.FirstOrDefault(x => x.Name == currName);

                if(currObject != null)
                {
                    currObject.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(TotalFood(ppl));
        }

        public static int TotalFood(List<IBuyer> ppl)
        {
            int result = 0;

            foreach (var item in ppl)
            {
                result += item.Food;
            }

            return result;
        }
    }
}
