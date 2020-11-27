using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Dictionary<Direction, Point> directionPoints;
        private Direction direction;
        private readonly Snake snake;
        private readonly Wall wall;
        public Engine(Wall wall, Snake snake)
        {
            this.direction = Direction.Right;
            this.directionPoints = new Dictionary<Direction, Point>();
            this.SetDirectionPoints();
            this.snake = snake;
            this.wall = wall;
        }
        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }
                Point currPointDirection = this.directionPoints[this.direction];
                bool isMoved = this.snake.IsMoving(currPointDirection);

                Thread.Sleep(100);

                if (!isMoved)
                {
                    break;
                }

                Console.SetCursorPosition(80, 2);
                Console.WriteLine($"Score: {this.snake.Count - 6}");
                Console.SetCursorPosition(80, 4);
                Console.WriteLine($"Level: {this.snake.FoodEaten}");
            }

            Console.WriteLine("END");
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (this.direction != Direction.Left)
                    {
                        this.direction = Direction.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (this.direction != Direction.Right)
                    {
                        this.direction = Direction.Left;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.direction != Direction.Up)
                    {
                        this.direction = Direction.Down;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (this.direction != Direction.Down)
                    {
                        this.direction = Direction.Up;
                    }
                    break;
            }
        }

        private void SetDirectionPoints()
        {
            this.directionPoints.Add(Direction.Right, new Point(1, 0));
            this.directionPoints.Add(Direction.Left, new Point(-1, 0));
            this.directionPoints.Add(Direction.Down, new Point(0, 1));
            this.directionPoints.Add(Direction.Up, new Point(0, -1));
        }
    }
}
