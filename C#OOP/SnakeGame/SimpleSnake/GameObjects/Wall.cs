using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY)
            :base(leftX, topY)
        {
            this.CreateBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.TopY == 0 || snakeHead.TopY == this.TopY 
                || snakeHead.LeftX == 0 || snakeHead.LeftX == this.LeftX - 1;
        }
        private void CreateBorders()
        {
            this.SetHorizontalLine(0);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
            this.SetHorizontalLine(this.TopY);
        }
        private void SetHorizontalLine(int topY)
        {
            for (int currLeftX = 0; currLeftX < this.LeftX; currLeftX++)
            {
                this.Draw(currLeftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int currTopY = 0; currTopY < this.TopY; currTopY++)
            {
                this.Draw(leftX, currTopY, wallSymbol);
            }
        }
    }
}
