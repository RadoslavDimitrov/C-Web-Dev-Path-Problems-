using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //move = row +- 2,col +-1 || row +- 1, col +- 2
            //k = knight
            // O = empty O not null

            int size = int.Parse(Console.ReadLine());

            char[,] myGrid = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currRowInput = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    myGrid[row, col] = currRowInput[col];
                }
            }

            int countDeleted = 0;

            while (true)
            {
                int maxKnightHit = 0;
                int maxRow = -1;
                int maxCol = -1;
                

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int currKnightHit = 0;

                        if (myGrid[row, col] == 'K')
                        {
                            if (row + 1 < size && col + 2 < size)
                            {
                                if (myGrid[row + 1, col + 2] == 'K') //right by 2 and 1 down
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row - 1 >= 0 && col + 2 < size)
                            {
                                if (myGrid[row - 1, col + 2] == 'K') //rigth by 2 and 1 up
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row + 2 < size && col + 1 < size)
                            {
                                if (myGrid[row + 2, col + 1] == 'K') //2 down 1 right
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row + 2 < size && col - 1 >= 0)
                            {
                                if (myGrid[row + 2, col - 1] == 'K') //2 down 1 left
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row - 1 >= 0 && col - 2 >= 0)
                            {
                                if (myGrid[row - 1, col - 2] == 'K') // 1 up 2 left
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row + 1 < size && col - 2 >= 0)
                            {
                                if (myGrid[row + 1, col - 2] == 'K') //1 down 2 left
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row - 2 >= 0 && col + 1 < size)
                            {
                                if (myGrid[row - 2, col + 1] == 'K') //2 up 1 right
                                {
                                    currKnightHit++;
                                }
                            }
                            if (row - 2 >= 0 && col - 1 >= 0)
                            {
                                if (myGrid[row - 2, col - 1] == 'K') // 2 up 1 left
                                {
                                    currKnightHit++;
                                }
                            }




                            if (currKnightHit > maxKnightHit)
                            {
                                maxKnightHit = currKnightHit;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }

                if (maxKnightHit > 0)
                {
                    myGrid[maxRow, maxCol] = '0';
                    countDeleted++;
                }

                

                if (maxKnightHit == 0)
                {
                    break;
                }
            }

            Console.WriteLine(countDeleted);
        }
    }
}
