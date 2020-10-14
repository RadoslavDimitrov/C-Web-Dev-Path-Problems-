using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if(this.data.Exists(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                this.data = this.data.Where(x => x.Manufacturer != manufacturer && x.Model != model).Select(y => y).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Car GetLatestCar()
        {
            if(this.data.Count == 0)
            {
                return null;
            }

            Car currCar = this.data.OrderByDescending(x => x.Year).First();
            return currCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if(this.data.Exists(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                Car currCar = this.data.Where(x => x.Manufacturer == manufacturer && x.Model == model).First();
                return currCar;
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            for (int i = 0; i < this.data.Count; i++)
            {
                sb.AppendLine(this.data[i].ToString());
            }

            return sb.ToString();
        }
    }
}
