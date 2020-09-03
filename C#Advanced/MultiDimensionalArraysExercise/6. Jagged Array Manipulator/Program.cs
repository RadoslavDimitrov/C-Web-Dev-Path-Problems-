using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();
            }

            for (int currRow = 0; currRow < matrix.Length - 1; currRow++)
            {
                if(matrix[currRow].Length == matrix[currRow + 1].Length)
                {
                    //multiply each element in both rows
                    for (int i = 0; i < matrix[currRow].Length; i++)
                    {
                        matrix[currRow][i] *= 2;
                    }
                    for (int j = 0; j < matrix[currRow + 1].Length; j++)
                    {
                        matrix[currRow + 1][j] *= 2;
                    }
                }
                else
                {
                    //divide each element in both rows
                    for (int i = 0; i < matrix[currRow].Length; i++)
                    {
                        matrix[currRow][i] /= 2;
                    }
                    for (int j = 0; j < matrix[currRow + 1].Length; j++)
                    {
                        matrix[currRow + 1][j] /= 2;
                    }
                }
            }


            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                int currRow = int.Parse(command[1]);
                int currCol = int.Parse(command[2]);
                int currValue = int.Parse(command[3]);

                if(command[0] == "Add")
                {
                    if(currRow >= 0 && currRow < matrix.Length && currCol >= 0 && currCol < matrix[currRow].Length)
                    {
                        matrix[currRow][currCol] += currValue;
                    }
                }
                else if(command[0] == "Subtract")
                {
                    if (currRow >= 0 && currRow < matrix.Length && currCol >= 0 && currCol < matrix[currRow].Length)
                    {
                        matrix[currRow][currCol] -= currValue;
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (double[] item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
