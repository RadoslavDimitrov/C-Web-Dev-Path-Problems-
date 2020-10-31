using System;
using System.Collections.Generic;
using System.Text;

namespace P4BorderControl
{
    public class Robots : CheckIds
    {
		private string model;

		public Robots(string model, string id)
		{
			this.Model = model;
			base.Id = id;
		}

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

	}
}
