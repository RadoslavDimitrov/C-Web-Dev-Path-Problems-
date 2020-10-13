using System;
using System.Collections.Generic;

namespace P2Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

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
