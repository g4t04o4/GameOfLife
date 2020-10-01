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
            int timer = 100;
            this.FillTheBoard();
            do
            {
                this.Advance();
                timer--;
                System.Threading.Thread.Sleep(1000);
            } while (timer != 0);
        }

        public void FillTheBoard()
        {
            cells.Add(new Cell(2, 2));
            cells.Add(new Cell(2, 3));
            cells.Add(new Cell(2, 4));
            cells.Add(new Cell(3, 3));
            cells.Add(new Cell(3, 4));
            cells.Add(new Cell(3, 5));
        }

        public void Advance()
        {
            foreach (Cell e in cells)
            {
                if (CountNeighbours(e) != 2 && CountNeighbours(e) != 3)
                {
                    cells.Remove(e);
                    e.Kill();
                }
            }
        }

        private int CountNeighbours(Cell e)
        {
            int counter = 0;
            foreach (Cell cell in cells)
            {
                if (cell.IsNeighbour(e))
                {
                    counter++;
                }
            }

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