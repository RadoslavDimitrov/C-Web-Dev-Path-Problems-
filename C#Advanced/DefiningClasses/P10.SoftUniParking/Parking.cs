using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
		private List<Car> cars;

		private int capacity;



		public int Count => this.Cars.Count;
		

		public Parking(int capacity)
		{
			this.Cars = new List<Car>();
			this.capacity = capacity;
		}
		public List<Car> Cars
		{
			get { return cars; }
			set { cars = value; }
		}

		public string AddCar(Car Car)
		{
			if(this.Cars.Any(x => x.RegistrationNumber == Car.RegistrationNumber))
			{
				return "Car with that registration number, already exists!";
			}
			
			if(this.Cars.Count == this.capacity)
			{
				return "Parking is full!";
			}

			this.Cars.Add(Car);

				return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
		}

		public string RemoveCar(string registrationNumber)
		{
			if(this.Cars.All(x => x.RegistrationNumber != registrationNumber)) //if we have it
			{
				
				return $"Car with that registration number, doesn't exist!";

			}

			this.Cars = this.Cars.Where(x => x.RegistrationNumber != registrationNumber).ToList();
				return $"Successfully removed {registrationNumber}";

		}

		public Car GetCar(string registrationNumber)
		{
			Car car = this.Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
			return car;
		}

		public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
		{
			foreach (var registrationNumber in registrationNumbers)
			{
				Car car = this.Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

				if(car != null)
				{
					this.Cars.Remove(car);
				}
			}
		}

	}
}
