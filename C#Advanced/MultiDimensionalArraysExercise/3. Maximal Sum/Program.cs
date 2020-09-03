using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                int[] currColonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    matrix[currRow, currCol] = currColonInput[currCol];
                }
            }

            int maxSum = int.MinValue;

            int maxRow = -1;
            int maxCol = -1;

            for (int currRow = 0; currRow < matrix.GetLength(0) - 2; currRow++)
            {
                

                for (int currCol = 0; currCol < matrix.GetLength(1) - 2; currCol++)
                {
                    int sum = 0;

                    sum += matrix[currRow, currCol] + matrix[currRow, currCol + 1] + matrix[currRow, currCol + 2]
                        + matrix[currRow + 1, currCol] + matrix[currRow + 1, currCol + 1] + matrix[currRow + 1, currCol + 2]
                        + matrix[currRow + 2, currCol] + matrix[currRow + 2, currCol + 1] + matrix[currRow + 2, currCol + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = currRow;
                        maxCol = currCol;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
