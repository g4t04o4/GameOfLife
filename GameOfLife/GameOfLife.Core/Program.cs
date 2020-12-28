using System;
using System.Threading;

namespace GameOfLife.Core
{
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