using System;
using System.Collections.Generic;
using System.Text;

namespace P2BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialStr = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());
            //"-" => empty position
            char[,] matrix = new char[size, size];

            ReadMatrix(matrix);

            KeyValuePair<int, int> playerPos = GetPlayerPosition(matrix);

            Player player = new Player(playerPos.Key, playerPos.Value, initialStr);

            //ConsoleKeyInfo command;

            //Console.WriteLine("Use arrows to move or press ENTER to ESC");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("");

            //string currCommand = string.Empty;
            //var keyCommand = Console.ReadKey();


            //while (keyCommand.Key != ConsoleKey.Enter)
            //{
            //    currCommand = TransferKeyInfoToStringCommand(currCommand, keyCommand);

            //    matrix[player.Row, player.Col] = '-';

            //    player.Move(currCommand, matrix);

            //    if (matrix[player.Row, player.Col] != '-')
            //    {
            //        player.Consume(ref matrix[player.Row, player.Col], ref matrix);
            //    }

            //    matrix[player.Row, player.Col] = 'P';

            //    Console.Clear();
            //    Console.WriteLine(PrintMatrix(matrix));

            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine();
            //    Console.WriteLine("Use arrows to move or press ENTER to ESC");

            //    keyCommand = Console.ReadKey();
            //}
            string command;

            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                matrix[player.Row, player.Col] = '-';

                player.Move(command, matrix);

                if (matrix[player.Row, player.Col] != '-')
                {
                    player.Consume(ref matrix[player.Row, player.Col], ref matrix);
                }



            }

            matrix[player.Row, player.Col] = 'P';

            Console.WriteLine(player.InitialStr);
            Console.WriteLine(PrintMatrix(matrix));
        }

        private static string TransferKeyInfoToStringCommand(string currCommand, ConsoleKeyInfo keyCommand)
        {
            if (keyCommand.Key == ConsoleKey.UpArrow)
            {
                currCommand = "up";
            }
            else if (keyCommand.Key == ConsoleKey.DownArrow)
            {
                currCommand = "down";
            }
            else if (keyCommand.Key == ConsoleKey.LeftArrow)
            {
                currCommand = "left";
            }
            else if (keyCommand.Key == ConsoleKey.RightArrow)
            {
                currCommand = "right";
            }

            return currCommand;
        }

        public static string PrintMatrix(char[,] matrix)
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

            return sb.ToString().Trim();
        }

        private static KeyValuePair<int, int> GetPlayerPosition(char[,] matrix)
        {
            KeyValuePair<int, int> currPos = new KeyValuePair<int, int>(-1, -1);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        currPos = new KeyValuePair<int, int>(row, col);
                    }
                }
            }

            return currPos;
        }

        private static void ReadMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[i, col] = currRow[col];
                }
            }
        }
    }

    public class Player
    {
        public Player(int row, int col, string initialString)
        {
            this.Row = row;
            this.Col = col;
            this.InitialStr = initialString;
        }

        public string InitialStr;
        public int Row { get; set; }
        public int Col { get; set; }

        public void Consume(ref char ch, ref char[,] matrix)
        {
            this.InitialStr += ch;
            matrix[this.Row, this.Col] = '-';
        }
        public void Move(string command, char[,] matrix)
        {
            switch (command)
            {
                case "up":
                    if(this.Row == 0)
                    {
                        if(this.InitialStr.Length > 0)
                        {
                            this.InitialStr = this.InitialStr.Remove(this.InitialStr.Length - 1);
                        }

                    }
                    else
                    {
                        this.Row--;
                    }
                    break;
                case "down":
                    if(this.Row == matrix.GetLength(0) - 1)
                    {
                        if (this.InitialStr.Length > 0)
                        {
                            this.InitialStr = this.InitialStr.Remove(this.InitialStr.Length - 1);
                        }
                    }
                    else
                    {
                        this.Row++;
                    }
                    break;
                case "left":
                    if (this.Col == 0)
                    {
                        if (this.InitialStr.Length > 0)
                        {
                            this.InitialStr = this.InitialStr.Remove(this.InitialStr.Length - 1);
                        }
                    }
                    else
                    {
                        this.Col--;
                    }
                    break;
                case "right":
                    if (this.Col == matrix.GetLength(1) - 1)
                    {
                        if (this.InitialStr.Length > 0)
                        {
                            this.InitialStr = this.InitialStr.Remove(this.InitialStr.Length - 1);
                        }
                    }
                    else
                    {
                        this.Col++;
                    }
                    break;
                default:
                    throw new Exception("invalid move command");

            }
        }

    }
}
