using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace P2TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[,] field = InitializeMatrix(rows);

            //first P = f
            //second P = s
            //empty = *

            KeyValuePair<int, int> firstPlayerPosition = GetPosition(field, "f");
            KeyValuePair<int, int> secondPlayerPosition = GetPosition(field, "s");

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bool POneLive = true;
            bool PTwoLive = true;

            bool haveWinner = false;

            while (haveWinner != true)
            {
                string firstPlayerCom = command[0].ToLower();
                string secondPlayerCom = command[1].ToLower();

                //int currRow = firstPlayerPosition.Key;
                //int currCol = firstPlayerPosition.Value;


                if (firstPlayerCom == "up")
                {
                    
                    if (firstPlayerPosition.Key == 0)
                    {
                        firstPlayerPosition = new KeyValuePair<int, int>(field.GetLength(0), firstPlayerPosition.Value);
                    }

                    if (field[firstPlayerPosition.Key - 1, firstPlayerPosition.Value] == "s")
                    {
                        field[firstPlayerPosition.Key - 1, firstPlayerPosition.Value] = "x";
                        POneLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[firstPlayerPosition.Key - 1, firstPlayerPosition.Value] = "f";
                    firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key - 1, firstPlayerPosition.Value);
                }
                else if (firstPlayerCom == "down")
                {
                    if (firstPlayerPosition.Key == field.GetLength(0) - 1)
                    {
                        firstPlayerPosition = new KeyValuePair<int, int>(-1, firstPlayerPosition.Value);
                    }

                    if (field[firstPlayerPosition.Key + 1, firstPlayerPosition.Value] == "s")
                    {
                        field[firstPlayerPosition.Key + 1, firstPlayerPosition.Value] = "x";
                        POneLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[firstPlayerPosition.Key + 1, firstPlayerPosition.Value] = "f";
                    firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key + 1, firstPlayerPosition.Value);
                }
                else if (firstPlayerCom == "left")
                {
                    if (firstPlayerPosition.Value == 0)
                    {
                        firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key, field.GetLength(1));
                    }

                    if (field[firstPlayerPosition.Key, firstPlayerPosition.Value - 1] == "s")
                    {
                        field[firstPlayerPosition.Key, firstPlayerPosition.Value - 1] = "x";
                        POneLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[firstPlayerPosition.Key, firstPlayerPosition.Value - 1] = "f";
                    firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key, firstPlayerPosition.Value - 1);
                }
                else //right
                {
                    if (firstPlayerPosition.Value == field.GetLength(1) - 1)
                    {
                        firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key, -1);
                    }

                    if (field[firstPlayerPosition.Key, firstPlayerPosition.Value + 1] == "s")
                    {
                        field[firstPlayerPosition.Key, firstPlayerPosition.Value + 1] = "x";
                        POneLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[firstPlayerPosition.Key, firstPlayerPosition.Value + 1] = "f";
                    firstPlayerPosition = new KeyValuePair<int, int>(firstPlayerPosition.Key, firstPlayerPosition.Value + 1);
                }


                if (secondPlayerCom == "up")
                {

                    if (secondPlayerPosition.Key == 0)
                    {
                        secondPlayerPosition = new KeyValuePair<int, int>(field.GetLength(0), secondPlayerPosition.Value);
                    }

                    if (field[secondPlayerPosition.Key - 1, secondPlayerPosition.Value] == "f")
                    {
                        field[secondPlayerPosition.Key - 1, secondPlayerPosition.Value] = "x";
                        PTwoLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[secondPlayerPosition.Key - 1, secondPlayerPosition.Value] = "s";
                    secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key - 1, secondPlayerPosition.Value);
                }
                else if (secondPlayerCom == "down")
                {
                    if (secondPlayerPosition.Key == field.GetLength(0) - 1)
                    {
                        secondPlayerPosition = new KeyValuePair<int, int>(-1, secondPlayerPosition.Value);
                    }

                    if (field[secondPlayerPosition.Key + 1, secondPlayerPosition.Value] == "f")
                    {
                        field[secondPlayerPosition.Key + 1, secondPlayerPosition.Value] = "x";
                        PTwoLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[secondPlayerPosition.Key + 1, secondPlayerPosition.Value] = "s";
                    secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key + 1, secondPlayerPosition.Value);
                }
                else if (secondPlayerCom == "left")
                {
                    if (secondPlayerPosition.Value == 0)
                    {
                        secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key, field.GetLength(1));
                    }

                    if (field[secondPlayerPosition.Key, secondPlayerPosition.Value - 1] == "f")
                    {
                        field[secondPlayerPosition.Key, secondPlayerPosition.Value - 1] = "x";
                        PTwoLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[secondPlayerPosition.Key, secondPlayerPosition.Value - 1] = "s";
                    secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key, secondPlayerPosition.Value - 1);
                }
                else //right
                {
                    if (secondPlayerPosition.Value == field.GetLength(1) - 1)
                    {
                        secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key, -1);
                    }

                    if (field[secondPlayerPosition.Key, secondPlayerPosition.Value + 1] == "f")
                    {
                        field[secondPlayerPosition.Key, secondPlayerPosition.Value + 1] = "x";
                        PTwoLive = false;
                        haveWinner = true;
                        break;
                    }

                    field[secondPlayerPosition.Key, secondPlayerPosition.Value + 1] = "s";
                    secondPlayerPosition = new KeyValuePair<int, int>(secondPlayerPosition.Key, secondPlayerPosition.Value + 1);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintMatrix(field);
           
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool Contains(string[,] matrix, string charToLook)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row, col] == charToLook)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string[,] InitializeMatrix(int rows)
        {
            string[,] field = new string[rows, rows];

            int col = rows;

            for (int i = 0; i < rows; i++)
            {
                char[] currRow = Console.ReadLine().ToArray();

                for (int currCol = 0; currCol < rows; currCol++)
                {
                    field[i, currCol] = currRow[currCol].ToString();
                }
            }

            return field;
        }

        public static KeyValuePair<int, int> GetPosition(string[,] matrix, string charToLook)
        {
            KeyValuePair<int, int> currPosition = new KeyValuePair<int, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == charToLook)
                    {
                        KeyValuePair<int, int> firstPlayer = new KeyValuePair<int, int>(row, col);
                        currPosition = firstPlayer;
                    }
                }
            }

            return currPosition;
        }
    }
}
