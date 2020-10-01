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
            } while (timer != 0);
        }

        private void FillTheBoard()
        {
            cells.Add(new Cell(2, 2));
            cells.Add(new Cell(2, 3));
            cells.Add(new Cell(2, 4));
            cells.Add(new Cell(3, 3));
            cells.Add(new Cell(3, 4));
            cells.Add(new Cell(3, 5));
        }

        private void Advance()
        {
            cells.ForEach(delegate(Cell cell)
            {
                if (CountNeighbours(cell) == 2 || CountNeighbours(cell) == 3)
                {
                    //literally nothing
                }
                else
                {
                    cells.Remove(cell);
                    cell.Kill();
                }
            });
        }

        private int CountNeighbours(Cell e)
        {
            var counter = 0;
            cells.ForEach(delegate(Cell cell)
            {
                if (cell.IsNeighbour(e))
                {
                    counter++;
                }
            });

            return counter;
        }

        private bool isExist(int x, int y)
        {
            if (cells.Exists(e => e.GetX() == x & e.GetY() == y))
            {
                return true;
            }

            return false;
        }
    }
}