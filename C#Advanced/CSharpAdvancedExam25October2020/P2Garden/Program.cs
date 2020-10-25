using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace P2Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            FillMatrix(matrix);

            string command = Console.ReadLine();

            List<int> flowerPos = new List<int>();

            while (command != "Bloom Bloom Plow")
            {
                int[] currCommand = command.Split(" ").Select(int.Parse).ToArray();
                int currRow = currCommand[0];
                int currCol = currCommand[1];

                if(currRow >= 0 && currRow < matrix.GetLength(0) && currCol >= 0 && currCol < matrix.GetLength(1))
                {
                    flowerPos.Add(currRow);
                    flowerPos.Add(currCol);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < flowerPos.Count; row+=2)
            {
                BoomFlowers(matrix, flowerPos[row], flowerPos[row + 1]);
                matrix[flowerPos[row], flowerPos[row + 1]]++;
            }

            Console.WriteLine(PrintMatrix(matrix));
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        if(matrix[row,col] == -1)
            //        {
            //            BoomFlowers(matrix, row, col);
            //        }
            //    }
            //}
        }

        private static string PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col] + " ");
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        private static void BoomFlowers(int[,] matrix, int flowerRow, int flowerCol)
        {
            //up
            int tempRow = flowerRow - 1;
            while (tempRow >= 0)
            {
                matrix[tempRow, flowerCol]++;
                tempRow--;
            }

            //down
            int tempDownRow = flowerRow + 1;
            while (tempDownRow < matrix.GetLength(0))
            {
                matrix[tempDownRow, flowerCol]++;
                tempDownRow++;
            }

            //left
            int tempCol = flowerCol - 1;
            while (tempCol >= 0)
            {
                matrix[flowerRow, tempCol]++;
                tempCol--;
            }

            //right
            int tempRightCol = flowerCol + 1;
            while (tempRightCol < matrix.GetLength(1))
            {
                matrix[flowerRow, tempRightCol]++;
                tempRightCol++;
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }
}
