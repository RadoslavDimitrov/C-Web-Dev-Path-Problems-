using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Cargo
    {
		private int cargoWeight;

		private string cargoType;

		public Cargo(int weight, string type)
		{
			this.cargoWeight = weight;
			this.CargoType = type;
		}

		public string CargoType
		{
			get { return cargoType; }
			set { cargoType = value; }
		}


		public int CargoWeight
		{
			get { return cargoWeight; }
			set { cargoWeight = value; }
		}

	}
}
