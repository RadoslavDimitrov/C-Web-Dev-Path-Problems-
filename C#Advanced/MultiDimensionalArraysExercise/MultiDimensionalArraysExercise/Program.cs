using System;
using System.Linq;
using System.Resources;

namespace MultiDimensionalArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine()); //square matrix

            int[,] matrix = new int[rows, rows];

            int col = rows;

            for (int i = 0; i < rows; i++)
            {
                int[] currArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int colum = 0; colum < rows; colum++)
                {
                    matrix[i, colum] = currArr[colum];
                }
            }

            int firstSum = 0;

            for (int currRow = 0; currRow < rows; currRow++)
            {
                firstSum += matrix[currRow, currRow];
            }

            int secondSum = 0;

            for (int currRowTwo = 0; currRowTwo < rows; currRowTwo++)
            {
                secondSum += matrix[currRowTwo, rows - 1 - currRowTwo];
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
