using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] matrix = new char[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currChars = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currChars[col];
                }
            }

            char currChar = '0';


            int equalSquare = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currChar = matrix[row, col];

                    if(currChar == matrix[row, col +1] 
                        && currChar == matrix[row + 1, col]
                        && currChar == matrix[row + 1, col + 1])
                    {
                        equalSquare++;
                    }
                }
            }

            Console.WriteLine(equalSquare);
        }
    }
}
