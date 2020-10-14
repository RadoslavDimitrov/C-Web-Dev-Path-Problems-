using System;
using System.Collections.Generic;
using System.Text;

namespace P2Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];
            ReadMatrix(matrix);

            KeyValuePair<int, int> snakePosition = GetPosition(matrix, "S");

            bool isLive = true;
            int foodQuantity = 0;
            bool haveFoodLeft;
            while (isLive)
            {
                if (foodQuantity == 10)
                {
                    break;
                }

                string moveCommand = Console.ReadLine().ToLower();

                if (moveCommand == "up")
                {
                    if (snakePosition.Key == 0)
                    {
                        matrix[snakePosition.Key, snakePosition.Value] = ".";
                        isLive = false;
                        continue;
                    }
                    else if (matrix[snakePosition.Key - 1, snakePosition.Value] == "*")
                    {
                        foodQuantity++;
                        snakePosition = MoveUp(matrix, snakePosition);
                        haveFoodLeft = HaveFood(matrix);
                        if(haveFoodLeft == false)
                        {
                            isLive = false;
                            continue;
                        }
                    }
                    else if (matrix[snakePosition.Key - 1, snakePosition.Value] == "B")
                    {
                        KeyValuePair<int, int> firstHole = new KeyValuePair<int, int>(snakePosition.Key - 1, snakePosition.Value);
                        KeyValuePair<int, int> secondHole = GetHolePosition(matrix, firstHole);
                        snakePosition = MoveToNextHole(matrix, snakePosition, firstHole, secondHole);
                    }
                    else
                    {
                        snakePosition = MoveUp(matrix, snakePosition);
                    }


                }
                else if (moveCommand == "down")
                {
                    if (snakePosition.Key == matrix.GetLength(0) - 1)
                    {
                        matrix[snakePosition.Key, snakePosition.Value] = ".";
                        isLive = false;
                        continue;
                    }
                    else if (matrix[snakePosition.Key + 1, snakePosition.Value] == "*")
                    {
                        foodQuantity++;
                        snakePosition = MoveDown(matrix, snakePosition);
                        haveFoodLeft = HaveFood(matrix);
                        if (haveFoodLeft == false)
                        {
                            isLive = false;
                            continue;
                        }
                    }
                    else if (matrix[snakePosition.Key + 1, snakePosition.Value] == "B")
                    {
                        KeyValuePair<int, int> firstHole = new KeyValuePair<int, int>(snakePosition.Key + 1, snakePosition.Value);
                        KeyValuePair<int, int> secondHole = GetHolePosition(matrix, firstHole);
                        snakePosition = MoveToNextHole(matrix, snakePosition, firstHole, secondHole);
                    }
                    else
                    {
                        snakePosition = MoveDown(matrix, snakePosition);

                    }
                }
                else if (moveCommand == "left")
                {
                    if (snakePosition.Value == 0)
                    {
                        matrix[snakePosition.Key, snakePosition.Value] = ".";
                        isLive = false;
                        continue;
                    }
                    else if (matrix[snakePosition.Key, snakePosition.Value - 1] == "*")
                    {
                        foodQuantity++;
                        snakePosition = MoveLeft(matrix, snakePosition);
                        haveFoodLeft = HaveFood(matrix);
                        if (haveFoodLeft == false)
                        {
                            isLive = false;
                            continue;
                        }
                    }
                    else if (matrix[snakePosition.Key, snakePosition.Value - 1] == "B")
                    {
                        KeyValuePair<int, int> firstHole = new KeyValuePair<int, int>(snakePosition.Key, snakePosition.Value - 1);
                        KeyValuePair<int, int> secondHole = GetHolePosition(matrix, firstHole);
                        snakePosition = MoveToNextHole(matrix, snakePosition, firstHole, secondHole);
                    }
                    else
                    {
                        snakePosition = MoveLeft(matrix, snakePosition);

                    }
                }
                else //right
                {
                    if (snakePosition.Value == matrix.GetLength(1))
                    {
                        matrix[snakePosition.Key, snakePosition.Value] = ".";
                        isLive = false;
                        continue;
                    }
                    else if (matrix[snakePosition.Key, snakePosition.Value + 1] == "*")
                    {
                        foodQuantity++;
                        snakePosition = MoveRight(matrix, snakePosition);
                        haveFoodLeft = HaveFood(matrix);
                        if (haveFoodLeft == false)
                        {
                            isLive = false;
                            continue;
                        }
                    }
                    else if (matrix[snakePosition.Key, snakePosition.Value + 1] == "B")
                    {
                        KeyValuePair<int, int> firstHole = new KeyValuePair<int, int>(snakePosition.Key, snakePosition.Value + 1);
                        KeyValuePair<int, int> secondHole = GetHolePosition(matrix, firstHole);
                        snakePosition = MoveToNextHole(matrix, snakePosition, firstHole, secondHole);
                    }
                    else
                    {
                        snakePosition = MoveRight(matrix, snakePosition);

                    }
                }

            }


            if (!isLive)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintMatrix(matrix);
        }

        private static bool HaveFood(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col] == "*")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private static void PrintMatrix(string[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }

                if (row < matrix.GetLength(0) - 1)
                {
                    sb.AppendLine();
                }

            }

            Console.WriteLine(sb.ToString());
        }

        private static KeyValuePair<int, int> MoveRight(string[,] matrix, KeyValuePair<int, int> snakePosition)
        {
            KeyValuePair<int, int> currPosition = snakePosition;
            snakePosition = new KeyValuePair<int, int>(snakePosition.Key, snakePosition.Value + 1);
            matrix[currPosition.Key, currPosition.Value] = ".";
            matrix[snakePosition.Key, snakePosition.Value] = "S";
            return snakePosition;
        }

        private static KeyValuePair<int, int> MoveLeft(string[,] matrix, KeyValuePair<int, int> snakePosition)
        {
            KeyValuePair<int, int> currPosition = snakePosition;
            snakePosition = new KeyValuePair<int, int>(snakePosition.Key, snakePosition.Value - 1);
            matrix[currPosition.Key, currPosition.Value] = ".";
            matrix[snakePosition.Key, snakePosition.Value] = "S";
            return snakePosition;
        }

        private static KeyValuePair<int, int> MoveDown(string[,] matrix, KeyValuePair<int, int> snakePosition)
        {
            KeyValuePair<int, int> currPosition = snakePosition;
            snakePosition = new KeyValuePair<int, int>(snakePosition.Key + 1, snakePosition.Value);
            matrix[currPosition.Key, currPosition.Value] = ".";
            matrix[snakePosition.Key, snakePosition.Value] = "S";
            return snakePosition;
        }

        private static KeyValuePair<int, int> MoveToNextHole(string[,] matrix, KeyValuePair<int, int> snakePosition, KeyValuePair<int, int> firstHole, KeyValuePair<int, int> secondHole)
        {
            matrix[snakePosition.Key, snakePosition.Value] = ".";
            matrix[firstHole.Key, firstHole.Value] = ".";
            snakePosition = new KeyValuePair<int, int>(secondHole.Key, secondHole.Value);
            matrix[snakePosition.Key, snakePosition.Value] = "S";
            return snakePosition;
        }

        private static KeyValuePair<int, int> MoveUp(string[,] matrix, KeyValuePair<int, int> snakePosition)
        {
            KeyValuePair<int, int> currPosition = snakePosition;
            snakePosition = new KeyValuePair<int, int>(snakePosition.Key - 1, snakePosition.Value);
            matrix[currPosition.Key, currPosition.Value] = ".";
            matrix[snakePosition.Key, snakePosition.Value] = "S";
            return snakePosition;
        }

        private static KeyValuePair<int, int> GetHolePosition(string[,] matrix, KeyValuePair<int, int> firstHole)
        {
            KeyValuePair<int, int> secondHole = new KeyValuePair<int, int>(-1, -1);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col] == "B" && row != firstHole.Key && col != firstHole.Value)
                    {
                        secondHole = new KeyValuePair<int, int>(row, col);
                        return secondHole;
                    }
                }
            }
            return secondHole;
        }

        private static void ReadMatrix(string[,] matrix)
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

        public static KeyValuePair<int, int> GetPosition(string[,] matrix, string charToLook)
        {
            KeyValuePair<int, int> currPair = new KeyValuePair<int, int>( -1, -1);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == charToLook)
                    {
                        currPair = new KeyValuePair<int, int>(row, col);
                        return currPair;
                    }
                }
            }

            return currPair;
        }
    }

    
}
