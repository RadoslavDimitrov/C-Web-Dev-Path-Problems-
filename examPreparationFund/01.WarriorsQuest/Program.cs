using System;

namespace _01.WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "For Azeroth")
            {
                string[] currCommand = command.Split();

                string currSkill = currCommand[0];

                if(currSkill == "GladiatorStance")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if(currSkill == "DefensiveStance")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if(currSkill == "Dispel")
                {
                    text = ReplaceChar(text, currCommand);
                }
                else if(currSkill == "Target")
                {
                    text = ChangeOrRemoveItem(text, currCommand);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }



                command = Console.ReadLine();
            }
        }

        private static string ChangeOrRemoveItem(string text, string[] currCommand)
        {
            string changeOrRemove = currCommand[1];


            if (changeOrRemove == "Change")
            {
                string subForReplace = currCommand[2];
                string sub = currCommand[3];

                if (text.Contains(subForReplace))
                {
                    text = text.Replace(subForReplace, sub);
                    Console.WriteLine(text);
                }

            }
            else if (changeOrRemove == "Remove")//remove
            {
                string subForRemove = currCommand[2];
                int lengthForRemove = subForRemove.Length;
                int startIndex = text.IndexOf(subForRemove);

                if (text.Contains(subForRemove))
                {
                    text = text.Remove(startIndex, lengthForRemove);
                    Console.WriteLine(text);
                }

            }
            else
            {
                Console.WriteLine("Command doesn't exist!");
            }

            return text;
        }

        private static string ReplaceChar(string text, string[] currCommand)
        {
            int indexForDispel = int.Parse(currCommand[1]);
            char charToReplace = char.Parse(currCommand[2]);

            if (indexForDispel < text.Length && indexForDispel >= 0)
            {
                
                char[] temp = text.ToCharArray();
                temp[indexForDispel] = charToReplace;

                text = new string(temp);

                Console.WriteLine("Success!");
            }
            else
            {
                
                Console.WriteLine("Dispel too weak.");
            }

            return text;
        }
    }
}
