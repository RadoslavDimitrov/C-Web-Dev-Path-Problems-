using System;
using System.Collections.Generic;

namespace P2Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];
            FillTheMatrix(matrix);

            //"f" - player
            //"-" - empty
            //"B" - bonus - one move forward
            //"T" - trap - one move backward
            //"F" - finish
            KeyValuePair<int, int> playerPos = GetPosition(matrix, "f");

            for (int i = 0; i < countOfCommands; i++)
            {
                string currCommand = Console.ReadLine().ToLower();

                switch (currCommand)
                {
                    case "up":
                        if(playerPos.Key == 0)
                        {
                            matrix[playerPos.Key, playerPos.Value] = "-";
                            playerPos = new KeyValuePair<int, int>(matrix.GetLength(0) - 1, playerPos.Value);
                            matrix[playerPos.Key, playerPos.Value] = "f";
                        }
                        else if (matrix[playerPos.Key - 1, playerPos.Value] == "B")
                        {

                        }
                        break;
                    case "down":
                        break;
                    case "left":
                        break;
                    case "right":
                        break;
                    default:
                        throw new Exception("Wrong move command");

                }
            }
        }

        public static KeyValuePair<int, int> Move(string[,] matrix,
            KeyValuePair<int,int> playerPos,
            KeyValuePair<int, int> directions)
        {

        }

        private static KeyValuePair<int, int> GetPosition(string[,] matrix, string v)
        {
            KeyValuePair<int, int> currPos = new KeyValuePair<int, int>(-1, -1);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col] == v)
                    {
                        currPos = new KeyValuePair<int, int>(row, col);
                        return currPos;
                    }
                }
            }

            return currPos;
        }

        private static void FillTheMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col].ToString();
                }
            }
        }
    }
}
