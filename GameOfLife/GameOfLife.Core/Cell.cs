using System;

namespace GameOfLife.Core
{
    public class Cell
    {
        private int x, y;
        private bool isAlive;

        public Cell(int xInput, int yInput)
        {
            x = xInput;
            y = yInput;
            isAlive = true;
        }

        public void Kill()
        {
            this.isAlive = false;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public bool IsNeighbour(Cell e)
        {
            if (Math.Abs(this.x - e.x) <= 1 & Math.Abs(this.y - e.y) <= 1)
            {
                return true;
            }

            return false;
        }
    }
}