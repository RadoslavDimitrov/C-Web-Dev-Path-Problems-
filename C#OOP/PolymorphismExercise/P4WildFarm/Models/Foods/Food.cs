using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Foods
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; set; }
    }
}
