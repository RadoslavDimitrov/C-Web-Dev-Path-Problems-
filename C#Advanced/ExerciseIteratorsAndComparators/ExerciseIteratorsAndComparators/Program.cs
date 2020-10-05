using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExerciseIteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            ListyIterator<string> mylist = new ListyIterator<string>();

            while (command != "END")
            {
                var currCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Create"))
                {
                    

                    var currArr = new List<string>();

                    if(currCommand.Length > 0)
                    {
                        for (int i = 1; i < currCommand.Length; i++)
                        {
                            currArr.Add(currCommand[i]);
                        }
                    }
                    
                    mylist = new ListyIterator<string>(currArr);
                }
                else if (command.Contains("Move"))
                {
                    Console.WriteLine(mylist.Move().ToString());
                }
                else if (command.Contains("HasNext"))
                {
                    Console.WriteLine(mylist.HasNext().ToString());
                }
                else if (currCommand[0] == "Print")
                {
                    mylist.Print();
                }
                else if (currCommand[0] == "PrintAll")
                {
                    foreach (var item in mylist)
                    {
                        Console.Write(item + " ");
                    }

                    Console.WriteLine();
                }



                command = Console.ReadLine();
            }
            
            
        }
    }
}
