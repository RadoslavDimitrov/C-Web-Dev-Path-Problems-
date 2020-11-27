using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private readonly Random rand;
        private readonly char foodSymbol;
        private readonly Wall wall;

        protected Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            rand = new Random();
            this.FoodPoints = points;
        }

        public int FoodPoints { get;private set; }
        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            bool foodInSnake = true;

            while (foodInSnake)
            {
                this.LeftX = this.rand.Next(2, wall.LeftX - 1);
                this.TopY = this.rand.Next(2, wall.TopY - 1);

                foodInSnake = snakeElements.Any(p => p.TopY == this.TopY && p.LeftX == this.LeftX);
            }

            Console.BackgroundColor = ConsoleColor.Red;

            this.Draw(this.foodSymbol);

            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY && snake.LeftX == this.LeftX;
        }
    }
}
