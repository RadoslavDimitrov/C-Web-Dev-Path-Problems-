using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.LeftX = x;
            this.TopY = y;
        }
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            this.Draw(this.LeftX, this.TopY, symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }
    }
}
