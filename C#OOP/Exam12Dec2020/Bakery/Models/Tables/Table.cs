using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;

        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;

        private bool isReserved = false;
        private int numberOfPeople;
        private decimal bill;
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.FoodOrders = new List<IBakedFood>();
            this.DrinkOrders = new List<IDrink>();

        }
        public int TableNumber
        {
            get { return this.tableNumber; }
            private set { this.tableNumber = value; }
        }

        public int Capacity 
        {
            get { return this.capacity; }
            private set
            {
                //TODO <= or <????
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople 
        {
            get { return this.numberOfPeople; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson 
        {
            get { return this.pricePerPerson; }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved => this.isReserved;

        public decimal Price => numberOfPeople * PricePerPerson;

        public void Clear()
        {
            this.FoodOrders = new List<IBakedFood>();
            this.DrinkOrders = new List<IDrink>();
            this.isReserved = false;
            //TODO check for error
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal sum = 0;

            foreach (var item in this.FoodOrders)
            {
                sum += item.Price;
            }

            foreach (var drink in this.DrinkOrders)
            {
                sum += drink.Price;
            }

            return sum  + this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
            //"Table: {table number}"

            //"Type: {table type}"

            //"Capacity: {table capacity}"

            //"Price per Person: {price per person for the current table}"
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);

        }

        public void OrderFood(IBakedFood food)
        {
            this.FoodOrders.Add(food);

        }

        public void Reserve(int numberOfPeople)
        {
            this.isReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
