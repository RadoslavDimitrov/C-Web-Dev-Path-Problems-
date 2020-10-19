using System;
using System.Collections.Generic;
using System.Text;

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
            Player player = new Player(playerPos.Key, playerPos.Value);
            bool isWon = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string currCommand = Console.ReadLine().ToLower();

                matrix[player.Row, player.Col] = "-";
                player.Move(currCommand, matrix);

                if (matrix[player.Row, player.Col] == "B")
                {
                    player.Move(currCommand, matrix);
                    if(matrix[player.Row, player.Col] == "F")
                    {
                        isWon = true;
                        break;
                    }

                }
                else if (matrix[player.Row, player.Col] == "T")
                {
                    ReturnOneStep(matrix, player, currCommand);
                }
                else if (matrix[player.Row, player.Col] == "F")
                {
                    
                    isWon = true;
                    break;
                }

            }

            matrix[player.Row, player.Col] = "f";

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            Console.WriteLine(PrintMatrix(matrix));
        }

        private static string PrintMatrix(string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static void ReturnOneStep(string[,] matrix, Player player, string currCommand)
        {
            switch (currCommand)
            {
                case "up":
                    player.Move("down", matrix);
                    break;
                case "down":
                    player.Move("up", matrix);
                    break;
                case "left":
                    player.Move("right", matrix);
                    break;
                case "right":
                    player.Move("left", matrix);
                    break;

            }
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

        public class Player
        {
            public int Row;
            public int Col;

            public Player(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public void Move(string command, string[,] matrix)
            {
                switch (command)
                {
                    case "up":
                        this.Row--;
                        if(this.Row < 0)
                        {
                            this.Row = matrix.GetLength(0) - 1;
                        }
                        break;
                    case "down":
                        this.Row++;
                        if(this.Row > matrix.GetLength(0) - 1)
                        {
                            this.Row = 0;
                        }
                        break;
                    case "left":
                        this.Col--;
                        if(this.Col < 0)
                        {
                            this.Col = matrix.GetLength(1) - 1;
                        }
                        break;
                    case "right":
                        this.Col++;
                        if(this.Col > matrix.GetLength(1) - 1)
                        {
                            this.Col = 0;
                        }
                        break;
                    default:
                        throw new Exception("Invalid Move command");

                }
            }
        }
    }
}
