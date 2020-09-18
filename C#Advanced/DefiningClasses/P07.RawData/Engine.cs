using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Engine
    {
		private double engineSpeed;

		private double enginePower;

		public Engine(double speed, double power)
		{
			this.EngineSpeed = speed;
			this.enginePower = power;
		}
		public double EnginePower
		{
			get { return enginePower; }
			set { enginePower = value; }
		}


		public double EngineSpeed
		{
			get { return engineSpeed; }
			set { engineSpeed = value; }
		}

	}
}
