using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string[] arg)
        {
            Food food = null;
            int quantity = int.Parse(arg[1]);

            switch (arg[0].ToLower())
            {
                case "vegetable":
                    return food = new Vegetable(quantity);
                case "fruit":
                    return food = new Fruit(quantity);
                case "meat":
                    return food = new Meat(quantity);
                case "seeds":
                    return food = new Seeds(quantity);
                default:
                    return food;
            }
        }
    }
}
