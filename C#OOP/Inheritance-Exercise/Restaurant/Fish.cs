using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double grams = 22;
        public Fish(string name, decimal price) : base(name, price, 0)
        {

        }

        public virtual double Grams { get => grams; }
    }
}
