using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int currRow = 0; currRow < rows; currRow++)
            {
                string[] currColonInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int currCol = 0; currCol < cols; currCol++)
                {
                    matrix[currRow, currCol] = currColonInput[currCol];
                }
            }

            string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if(command.Length >= 5 && command[0] == "swap")
                {
                    int row1;
                    int col1;
                    int row2;
                    int col2;
                    if (int.TryParse(command[1], out row1))
                    {
                        if(int.TryParse(command[2], out col1))
                        {
                            if(int.TryParse(command[3], out row2))
                            {
                                if(int.TryParse(command[4], out col2))
                                {
                                    if (row1 >= 0 && row1 < matrix.GetLength(0) && row2 >= 0 && row2 < matrix.GetLength(0)
                        && col1 >= 0 && col1 < matrix.GetLength(1) && col2 >= 0 && col2 < matrix.GetLength(1))
                                    {
                                        string temp = matrix[row1, col1];
                                        matrix[row1, col1] = matrix[row2, col2];
                                        matrix[row2, col2] = temp;

                                        for (int i = 0; i < rows; i++)
                                        {
                                            for (int j = 0; j < cols; j++)
                                            {
                                                Console.Write($"{matrix[i, j]} ");
                                            }

                                            Console.WriteLine();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                            command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
