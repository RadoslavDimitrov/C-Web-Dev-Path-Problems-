using System;
using System.Collections.Generic;
using System.Text;

namespace P4PizzaCalories
{
    public class Pizza
    {
        private string name;

		private Dough dought;

		private List<Topping> toppings;

		public Pizza()
		{
			this.toppings = new List<Topping>();
		}
		public Pizza(string name)
			:this()
		{
			this.Name = name;
			
		}
		public int ToppingsCount
		{
			get { return this.toppings.Count; }
			
		}

		public double TotalCals => GetToTalCals();

		
		public string Name
		{
			get { return name; }
			private set
			{
				if(string.IsNullOrEmpty(value) || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}

				this.name = value;
			}
		}
		public Dough Dought
		{

			set { dought = value; }
		}

		private double GetToTalCals()
		{
			double sum = 0;

			sum += this.dought.CallPerGram;

			foreach (var topping in this.toppings)
			{
				sum += topping.CalsPerGram;
			}

			return sum;
		}
		public void AddTopping(Topping topping)
		{
			if(this.toppings.Count == 10)
			{
				throw new ArgumentException("Number of toppings should be in range[0..10].");
			}

			this.toppings.Add(topping);
		}

		public override string ToString()
		{
			return $"{this.Name} - {GetToTalCals():F2} Calories.";
		}
	}
}
