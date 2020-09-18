using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Cargo
    {
		private double cargoWeight;

		private string cargoType;

		public Cargo(double weight, string type)
		{
			this.cargoWeight = weight;
			this.CargoType = type;
		}

		public string CargoType
		{
			get { return cargoType; }
			set { cargoType = value; }
		}


		public double CargoWeight
		{
			get { return cargoWeight; }
			set { cargoWeight = value; }
		}

	}
}
