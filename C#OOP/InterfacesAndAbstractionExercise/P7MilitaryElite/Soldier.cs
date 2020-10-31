using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    public class Soldier : ISoldier
    {
		private string id;
		private string firstName;
		private string lastName;

		public Soldier(string id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}
		public string LastName
		{	
			get { return lastName; }
			set { lastName = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
