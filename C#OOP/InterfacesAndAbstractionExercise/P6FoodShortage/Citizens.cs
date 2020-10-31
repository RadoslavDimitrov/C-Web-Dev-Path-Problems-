using P5BirthdayCelebrations;
using P6FoodShortage;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4BorderControl
{
	public class Citizens : CheckIds, IBirthable, IBuyer
	{
		private string name;
		private int age;
		private string birthDay;
		private int food;
		public Citizens(string name, int age, string id, string bDay)
		{
			this.Name = name;
			this.Age = age;
			base.Id = id;
			this.BirthDay = bDay;
			this.Food = 0;
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string BirthDay
		{
			get
			{
				return this.birthDay;
			}
			private set
			{
				this.birthDay = value;
			}
		}

		public int Food
		{
			get
			{
				return this.food;
			}
			private set
			{
				this.food = value;
			}
		}

		public void BuyFood()
		{
			this.Food += 10;
		}
	}
}
