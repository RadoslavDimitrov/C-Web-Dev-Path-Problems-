using P5BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace P4BorderControl
{
	public class Citizens : CheckIds, IBirthable
	{
		private string name;
		private int age;
		private string birthDay;
		public Citizens(string name, int age, string id, string bDay)
		{
			this.Name = name;
			this.Age = age;
			base.Id = id;
			this.BirthDay = bDay;
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
	}
}
