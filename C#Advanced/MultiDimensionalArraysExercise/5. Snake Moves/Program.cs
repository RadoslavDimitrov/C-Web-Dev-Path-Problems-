using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string snakeInput = Console.ReadLine();

            Queue<char> snake = new Queue<char>(snakeInput);

            char[,] grid = new char[size[0], size[1]];

            for (int rows = 0; rows < size[0]; rows++)
            {
                if(rows % 2 == 0 || rows == 0)
                {
                    for (int cols = 0; cols < size[1]; cols++)
                    {
                        char currChar = snake.Dequeue();
                        grid[rows, cols] = currChar;
                        snake.Enqueue(currChar);
                        Console.Write(currChar);
                    }

                    Console.WriteLine();
                }
                else if(rows % 2 != 0 || rows == 1)
                {
                    for (int cols  = size[1] - 1; cols >= 0; cols--)
                    {
                        char currChar = snake.Dequeue();
                        grid[rows, cols] = currChar;
                        snake.Enqueue(currChar);
                        
                    }

                    for (int cols = 0; cols < size[1]; cols++)
                    {
                        Console.Write(grid[rows, cols]);
                    }

                    Console.WriteLine();
                }
                
            }
        }
    }
}
