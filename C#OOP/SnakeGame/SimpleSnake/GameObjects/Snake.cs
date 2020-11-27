using SimpleSnake.GameObjects.Foods;
using SimpleSnake.GameObjects.FoodS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char WhiteSpace = ' ';
        private const char SnakeSymbol = '\u25CF';
        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;
        private readonly Random random;
        private int foodIndex;
        private Food food;

        private int nextTopY;
        private int nextLeftX;
        public Snake(Wall wall)
        {
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.wall = wall;
            this.CreateSnake();
            this.SeedFoods();
            this.random = new Random();


            this.GenerateNewFood();
        }

        public int Count => this.snakeElements.Count;
        public int FoodEaten { get;private set; }

        public bool IsMoving(Point direction)
        {
            Point currSnakeHead = this.snakeElements.Last();
            this.GetNextPoint(direction, currSnakeHead);

            bool isInSnake = this.snakeElements
                .Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);

            if (isInSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            if (this.food.IsFoodPoint(newSnakeHead))
            {
                //EAT
                this.Eat(direction, currSnakeHead);
                this.FoodEaten++;
            }

            newSnakeHead.Draw(SnakeSymbol);
            this.snakeElements.Enqueue(newSnakeHead);
            Point tail = this.snakeElements.Dequeue();
            tail.Draw(WhiteSpace);
            return true;
        }

        private void GenerateNewFood()
        {
            this.foodIndex = this.random.Next(0, this.foods.Length);
            this.food = this.foods[foodIndex];
            food.SetRandomPosition(this.snakeElements);
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            int foodPoints = this.food.FoodPoints;

            for (int i = 0; i < foodPoints; i++)
            {
                this.snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                this.GetNextPoint(direction, currSnakeHead);
            }

            this.GenerateNewFood();
        }

        private void GetNextPoint(Point direction, Point currSnakeHead)
        {
            this.nextTopY = currSnakeHead.TopY + direction.TopY;
            this.nextLeftX = currSnakeHead.LeftX + direction.LeftX;
        }

        private void CreateSnake()
        {
            
            for (int y = 1; y < 7; y++)
            {
                this.snakeElements.Enqueue(new Point(2, y));
            } 
        }
        private void SeedFoods()
        {
            this.foods[0] = new FoodAsterisk(wall);
            this.foods[1] = new FoodDollar(wall);
            this.foods[2] = new FoodHash(wall);
        }



    }
}
