using P4WildFarm.Contracts;
using P4WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4WildFarm.Models.Animals
{
    public abstract class Animal : IEat, ISoundProducable
    {
        //string Name, double Weight, int FoodEaten;
        private string name;
        private double weight;
        private int foodEaten;
        

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        public int FoodEaten
        {
            get { return foodEaten; }
            protected set { foodEaten = value; }
        }

        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        protected virtual double weightModifier { get; }

        protected virtual ICollection<Type> allowedFood { get; }
        public void Eat(Food food)
        {
            if(!this.allowedFood.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.weightModifier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public abstract void ProduceSound();

    }
}
