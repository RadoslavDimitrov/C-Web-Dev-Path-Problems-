using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace P07.RawData
{
    public class Car
    {
		//model, engine, cargo and a collection of exactly 4 tires
		private string model;

		private Engine engine;

		private Cargo cargo;

		private List<Tire> tires;

		//"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType}
		//{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age}
		//{tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
		public Car(string model, double engineSpeed, double enginePower, double cargoWeight
			,string cargoType, double tire1Age, double tire1Pressure
			,double tire2Age, double tire2Pressure
			,double tire3Age, double tire3Pressure
			,double tire4Age, double tire4Pressure)
		{
			this.Model = model;
			this.Engine = new Engine(engineSpeed, enginePower);
			this.Cargo = new Cargo(cargoWeight, cargoType);
			this.Tires = new List<Tire>();
			Tire tireOne = new Tire(tire1Pressure, tire1Age);
			Tire tireTwo = new Tire(tire2Pressure, tire2Age);
			Tire tireThree = new Tire(tire3Pressure, tire3Age);
			Tire tireFour = new Tire(tire4Pressure, tire4Age);
			this.Tires.Add(tireOne);
			this.Tires.Add(tireTwo);
			this.Tires.Add(tireThree);
			this.Tires.Add(tireFour);
			
		}
		public List<Tire> Tires
		{
			get { return tires; }
			set { tires = value; }
		}


		public Cargo Cargo
		{
			get { return cargo; }
			set { cargo = value; }
		}


		public Engine Engine
		{
			get { return engine; }
			set { engine = value; }
		}


		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public double GetAveragePressure()
		{
			double result = (this.tires[0].Pressure + this.tires[1].Pressure 
				+ this.tires[2].Pressure + this.tires[3].Pressure) / 4;
			return result;
		}

		public override string ToString()
		{
			return $"{this.Model}";
		}
	}
}
