using System;
using System.Threading;

namespace ConsoleCGoL
{
    internal class Board
    {
        private const int Size = 10;

        private readonly bool[,] _board = new bool[Size, Size];
        private bool[,] _lastGen = new bool[Size, Size];

        public void FillBoard()
        {
            var rand = new Random();

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (rand.Next(0, 100) < 30)
                    {
                        _board[i, j] = true;
                    }
                    else
                    {
                        _board[i, j] = false;
                    }
                }
            }

            _lastGen = _board;
        }

        public void DrawBoard()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Console.Write(_board[i, j] ? 'x' : ' ');
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void Advance()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var lg = CountNeighbours(i, j);
                    if (!_board[i, j] && lg == 3)
                    {
                        _board[i, j] = true;
                    }

                    if (_board[i, j] && (lg < 2 || lg > 3))
                    {
                        _board[i, j] = false;
                    }
                }
            }
        }

        private int CountNeighbours(int i, int j)
        {
            var counter = 0;

            if (i != 0)
            {
                if (j != 0 && _lastGen[i - 1, j - 1])
                {
                    counter++;
                }

                if (_lastGen[i - 1, j])
                {
                    counter++;
                }

                if (j != Size - 1 && _lastGen[i - 1, j + 1])
                {
                    counter++;
                }
            }

            if (i != Size - 1)
            {
                if (j != 0 && _lastGen[i + 1, j - 1])
                {
                    counter++;
                }

                if (_lastGen[i + 1, j])
                {
                    counter++;
                }

                if (j != Size - 1 && _lastGen[i + 1, j + 1])
                {
                    counter++;
                }
            }

            if (j != 0 && _lastGen[i, j - 1])
            {
                counter++;
            }

            if (j != Size - 1 && _lastGen[i, j + 1])
            {
                counter++;
            }

            return counter;
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();

            board.FillBoard();
            board.DrawBoard();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar))
            {
                board.Advance();
                board.DrawBoard();
                Thread.Sleep(100);
            }
        }
    }
}