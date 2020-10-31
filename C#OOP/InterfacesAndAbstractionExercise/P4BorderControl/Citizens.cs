using System;
using System.Collections.Generic;
using System.Text;

namespace P4BorderControl
{
    public class Citizens : CheckIds
    {
		private string name;
		private int age;

		public Citizens(string name, int age, string id)
		{
			this.Name = name;
			this.Age = age;
			base.Id = id;
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

	}
}
