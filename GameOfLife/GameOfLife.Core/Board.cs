using System.Linq.Expressions;

namespace GameOfLife.Core
{
    using System;
    using System.Collections.Generic;

    public class Board
    {
        private List<Cell> cells = new List<Cell>();

        public void StartGame()
        {
            var timer = 100;
            this.FillTheBoard();
            do
            {
                this.Advance();
                timer--;
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(timer);
            } while (timer != 0);
        }

        private void FillTheBoard()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    cells.Add(new Cell(i, j));
                }
            }

            cells.Find(e => e.GetX() == 3 && e.GetY() == 3).Create();
            cells.Find(e => e.GetX() == 3 && e.GetY() == 4).Create();
            cells.Find(e => e.GetX() == 3 && e.GetY() == 5).Create();
            cells.Find(e => e.GetX() == 4 && e.GetY() == 4).Create();
            cells.Find(e => e.GetX() == 4 && e.GetY() == 5).Create();
            cells.Find(e => e.GetX() == 4 && e.GetY() == 6).Create();
        }

        private void Advance()
        {
            cells.ForEach(delegate(Cell cell)
            {
                if (CountNeighbours(cell) == 2 || CountNeighbours(cell) == 3)
                {
                    cell.Create();
                }
                else
                {
                    cell.Kill();
                }
            });
        }

        private int CountNeighbours(Cell e)
        {
            int counter = cells.FindAll(c =>
                Math.Abs(c.GetX() - e.GetX()) <= 1 && Math.Abs(c.GetY() - e.GetY()) <= 1 && c.IsAlive()).Count;
            return counter;
        }
    }
}