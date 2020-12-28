using System;
using System.Threading;

namespace ConsoleCGoL
{
    class Board
    {
        private const int size = 10;

        private bool[,] board = new bool[size, size];
        private bool[,] lastGen = new bool[size, size];

        public void FillBoard()
        {
            var rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (rand.Next(0, 100) < 30)
                    {
                        board[i, j] = true;
                    }
                    else
                    {
                        board[i, j] = false;
                    }
                }
            }

            lastGen = board;
        }

        public void DrawBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j])
                    {
                        Console.Write(1);
                    }
                    else
                    {
                        Console.Write(0);
                    }

                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Advance()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int lg = CountNeighbours(i, j);
                    if (!board[i, j] && lg == 3)
                    {
                        board[i, j] = true;
                    }

                    if (board[i, j] && (lg < 2 || lg > 3))
                    {
                        board[i, j] = false;
                    }
                }
            }
        }

        private int CountNeighbours(int i, int j)
        {
            int counter = 0;

            if (i != 0)
            {
                if (j != 0 && lastGen[i - 1, j - 1])
                {
                    counter++;
                }

                if (lastGen[i - 1, j])
                {
                    counter++;
                }

                if (j != size-1 && lastGen[i - 1, j + 1])
                {
                    counter++;
                }
            }

            if (i != size-1)
            {
                if (j != 0 && lastGen[i + 1, j - 1])
                {
                    counter++;
                }

                if (lastGen[i + 1, j])
                {
                    counter++;
                }

                if (j != size-1 && lastGen[i + 1, j + 1])
                {
                    counter++;
                }
            }

            if (j != 0 && lastGen[i, j - 1])
            {
                counter++;
            }

            if (j != size-1  && lastGen[i, j + 1])
            {
                counter++;
            }

            return counter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            board.FillBoard();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar))
            {
                board.Advance();
                board.DrawBoard();
                Thread.Sleep(500); 
            }
        }
    }
}