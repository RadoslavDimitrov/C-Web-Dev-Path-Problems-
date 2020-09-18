using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Tire
    {
		private double pressure;

		private double tireAge;

		public Tire(double pressure, double age)
		{
			this.Pressure = pressure;
			this.TireAge = age;
		}
		public double TireAge
		{
			get { return tireAge; }
			set { tireAge = value; }
		}


		public double Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}

		
	}
}
