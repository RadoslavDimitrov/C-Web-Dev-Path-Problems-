using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
		private string name;
		private int age;

		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;
		}
		public int Age
		{
			get { return age; }
			set 
			{
				if(value > 0)
				{
					age = value;
				}
				
			}
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(String.Format("Name: {0}, age: {1}", this.Name, this.Age));

			return sb.ToString();
		}
	}
}
