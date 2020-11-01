using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IPrivate> privateToAdd = new List<IPrivate>();

            while (input != "End")
            {
                string[] currInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string soldierType = currInput[0];
                int id = int.Parse(currInput[1]);
                string firstName = currInput[2];
                string lastName = currInput[3];
                

                switch (soldierType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(currInput[4]);
                        Private solder = new Private(id, firstName, lastName, salary);
                        privateToAdd.Add(solder);
                        Console.WriteLine(solder);
                        break;

                    case "LieutenantGeneral":
                        decimal salaryLG = decimal.Parse(currInput[4]);
                        ILieutenantGeneral lieutantant = new LieutenantGeneral(id, firstName, lastName, salaryLG);

                        for (int i = 5; i < currInput.Length; i++)
                        {
                            IPrivate currPrivate = privateToAdd.FirstOrDefault(x => x.Id == int.Parse(currInput[i]));
                            lieutantant.AddPrivate(currPrivate);
                        }

                        Console.WriteLine(lieutantant);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(currInput[4]);
                        string currCorps = currInput[5];
                        IEngineer engineer = null;
                        if (currCorps == "Airforces")
                        {

                             engineer = new Engineer(id, firstName, lastName, salary, Corps.Airforces);
                        }
                        else if(currCorps == "Marines")
                        {
                             engineer = new Engineer(id, firstName, lastName, salary, Corps.Marines);
                        }
                        else
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        for (int i = 6; i < currInput.Length; i+=2)
                        {
                            Repair repair = new Repair(currInput[i], int.Parse(currInput[i + 1]));
                            engineer.AddRepair(repair);
                        }

                        Console.WriteLine(engineer);

                        break;

                    case "Commando":
                        salary = decimal.Parse(currInput[4]);
                         currCorps = currInput[5];
                        ICommando commando = null;
                        if (currCorps == "Airforces")
                        {

                            commando = new Commando(id, firstName, lastName, salary, Corps.Airforces);
                        }
                        else if (currCorps == "Marines")
                        {
                            commando = new Commando(id, firstName, lastName, salary, Corps.Marines);
                        }
                        else
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        for (int i = 6; i < currInput.Length; i+=2)
                        {
                            if(currInput[i + 1] != MissionState.Finished.ToString() 
                                && currInput[i + 1] != MissionState.inProgress.ToString())
                            {
                                continue;
                            }

                            Mission mission = null;
                            if (currInput[i + 1] == MissionState.inProgress.ToString())
                            {
                                mission = new Mission(currInput[i], MissionState.inProgress);
                            }
                            else
                            {
                                mission = new Mission(currInput[i], MissionState.Finished);
                            }

                            commando.AddMission(mission);
                            
                        }

                        Console.WriteLine(commando);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(currInput[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;
 
                }

                input = Console.ReadLine();
            }
        }
    }
}
