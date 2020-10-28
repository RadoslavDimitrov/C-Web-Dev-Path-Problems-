using System;
using System.Collections.Generic;
using System.Text;

namespace P3ShoppingSpree
{
    public class Person
    {
		private string name;
		private decimal money;

		public readonly List<Product> bagOfProducts;

		public Person(string name,decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.bagOfProducts = new List<Product>();
		}
		public decimal Money
		{
			get { return money; }
			set 
			{
				if(value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}

				money = value;
			}
		}

		public string Name
		{
			get { return name; }
			set 
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value; 
			}
		}

		public void AddProduct(Product product)
		{
			this.bagOfProducts.Add(product);
		}
	}
}
