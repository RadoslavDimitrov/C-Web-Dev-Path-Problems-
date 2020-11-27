using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.FoodS
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoints = 1;
        public FoodAsterisk(Wall wall)
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
