using System;
using System.Collections.Generic;
using System.Linq;

namespace P7MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Private> soldiersList = new List<Private>();

            while (command != "End")
            {
                string[] currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string id = currCommand[1];
                string firstName = currCommand[2];
                string lastName = currCommand[3];
                switch (currCommand[0])
                {
                    case "Private":
                        decimal currSalary = decimal.Parse(currCommand[4]);
                        Private currPrivate = new Private(id, firstName, lastName, currSalary);
                        soldiersList.Add(currPrivate);
                        Console.WriteLine(currPrivate.ToString());
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(currCommand[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy.ToString());
                        break;
                    case "LieutenantGeneral":
                        decimal currSalaryLG = decimal.Parse(currCommand[4]);
                        LieutenantGeneral currLeiGen = new LieutenantGeneral(id, firstName, lastName, currSalaryLG);
                        for (int i = 5; i < currCommand.Length; i++)
                        {
                            Private currPrivateToAdd = soldiersList.FirstOrDefault(x => x.Id == currCommand[i]);
                            currLeiGen.AddPrivate(currPrivateToAdd);
                        }

                        Console.WriteLine(currLeiGen.ToString());
                        break;
                    case "Engineer":
                        decimal currSalaryEng = decimal.Parse(currCommand[4]);
                        string currCorps = currCommand[5];

                        if (currCorps != "Airforces" && currCorps != "Marines")
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        try
                        {
                            Engineer engineer = new Engineer(id, firstName, lastName, currSalaryEng, currCorps);

                            for (int i = 6; i < currCommand.Length; i+=2)
                            {
                                Repair currRep = new Repair(currCommand[i], int.Parse(currCommand[i + 1]));
                                engineer.AddRepair(currRep);
                            }

                            Console.WriteLine(engineer.ToString());
                        }
                        catch (ArgumentException ae)
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        break;
                    case "Commando":
                        decimal currSalaryCom = decimal.Parse(currCommand[4]);

                        string currCorp = currCommand[5];
                        if(currCorp != "Airforces" && currCorp != "Marines")
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        Commando commando = new Commando(id, firstName, lastName, currSalaryCom, currCorp);

                        for (int i = 6; i < currCommand.Length; i+=2)
                        {
                            try
                            {
                                Mission mission = new Mission(currCommand[i], currCommand[i + 1]);
                                commando.AddMission(mission);
                            }
                            catch (ArgumentException ae)
                            {
                                continue;
                            }

                        }

                        Console.WriteLine(commando.ToString());
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
