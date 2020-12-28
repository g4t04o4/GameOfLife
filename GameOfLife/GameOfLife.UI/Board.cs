using System.Linq.Expressions;
using System.Drawing.Bitmap;

namespace GameOfLife.UI
{
    using System;

    internal class Board
    {
        private const int Size = 80;

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

        // private static Bitmap ToBitmap(bool[,] board)
        // {
        //     Bitmap Image = new Bitmap(Size, Size);
        //
        //     for (var i = 0; i < Size; i++)
        //     {
        //         for (var j = 0; j < Size; j++)
        //         {
        //             //Create a Bitmap from the board.
        //         }
        //     }
        // }
    }
}