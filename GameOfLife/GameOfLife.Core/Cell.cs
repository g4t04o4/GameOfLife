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
            isAlive = false;
        }

        public void Kill()
        {
            this.isAlive = false;
        }

        public void Create()
        {
            this.isAlive = true;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public bool IsAlive()
        {
            return isAlive;
        }
    }
}