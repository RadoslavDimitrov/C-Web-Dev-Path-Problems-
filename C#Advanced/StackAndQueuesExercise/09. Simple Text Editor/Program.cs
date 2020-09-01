using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            int n = int.Parse(Console.ReadLine());

            Stack<string> myHistory = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string numOfCommand = command[0];

                switch (numOfCommand)
                {
                    case "1":
                        myHistory.Push(text);
                        string textToAdd = command[1];
                        text = CommandToRead.AddCommand(text, textToAdd);
                        
                        break;
                    case "2":
                        myHistory.Push(text);
                        int countToRemove = int.Parse(command[1]);
                        text = CommandToRead.RemovePart(text, countToRemove);
                        
                        break;
                    case "3":
                        int indexToGet = int.Parse(command[1]) - 1;
                        char currChar = CommandToRead.GetElementAtIndex(text, indexToGet);
                        Console.WriteLine(currChar);
                        break;
                    case "4":
                        text = CommandToRead.UndoLastCommand(text, myHistory);

                        break;

                }
            }
        }



    }

    public static class CommandToRead
    {
        public static string AddCommand(string text, string textToAdd)
        {
            text = text + textToAdd;

            return text;

        }

        public static string RemovePart(string text, int countToRemove)
        {
            string newText = string.Empty;

            int newLenght = text.Length - countToRemove;

            for (int i = 0; i < newLenght; i++)
            {
                newText += text[i];
            }

            return newText;
        }

        public static char GetElementAtIndex(string text, int indexToGet)
        {
            char returnedChar = text[indexToGet];

            return returnedChar;
        }

        public static string UndoLastCommand(string text, Stack<string> myHistory)
        {
            string newText;
            if (myHistory.TryPop(out newText))
            {
                text = newText;
            }

            return text;
        }
    }
}
