using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherials;
        private decimal price;
        private double overallPerformace;
        private List<double> averagePerformace;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherials = new List<IPeripheral>();
            this.averagePerformace = new List<double>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;


        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherials;

        public override double OverallPerformance
        {
            get
            { 
                if(this.averagePerformace.Count == 0)
                {
                    return this.overallPerformace;
                }

                return this.overallPerformace += this.averagePerformace.Average();
                //return GetOverallPerformance();
            }
            protected set { this.overallPerformace = value; }
        }


        public override decimal Price
        {
            get
            {              
                return this.price;
            }
            protected set
            {
                this.price = value;
            }

        }
        public void AddComponent(IComponent component)
        {
            Enum.TryParse(component.GetType().Name, out ComponentType componentType);

            foreach (var item in this.Components)
            {
                if (componentType.Equals(item.GetType().Name))
                {
                    string msg = string.Format(ExceptionMessages.ExistingComponent, componentType, this.GetType().Name, this.Id);
                    throw new ArgumentException(msg);
                }
            }

            this.components.Add(component);
            this.Price += component.Price;
            this.averagePerformace.Add(component.OverallPerformance);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            Enum.TryParse(peripheral.GetType().Name, out PeripheralType peripherialType);

            foreach (var item in this.peripherials)
            {
                if (peripherialType.Equals(item.GetType().Name))
                {
                    string msg = string.Format(ExceptionMessages.ExistingComponent, peripherialType, this.GetType().Name, this.Id);
                    throw new ArgumentException(msg);
                }
            }

            this.peripherials.Add(peripheral);
            this.Price += peripheral.Price;
            this.averagePerformace.Add(peripheral.OverallPerformance);
        }

        public IComponent RemoveComponent(string componentTypeSearched)
        {
            Enum.TryParse(componentTypeSearched, out ComponentType peripheralType);

            IComponent periferial = this.components.FirstOrDefault(x => x.GetType().Name == peripheralType.ToString());
            if (periferial == null)
            {
                string msg = string.Format(ExceptionMessages.NotExistingComponent, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Remove(periferial);
            this.Price -= periferial.Price;
            this.averagePerformace.Remove(periferial.OverallPerformance);
            return periferial;
        }

        public IPeripheral RemovePeripheral(string peripheralTypeSearched)
        {
            Enum.TryParse(peripheralTypeSearched, out PeripheralType peripheralType);

            IPeripheral periferial = this.peripherials.FirstOrDefault(x => x.GetType().Name == peripheralType.ToString());
            if(periferial == null)
            {
                string msg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }
            
            this.peripherials.Remove(periferial);
            this.Price -= periferial.Price;
            this.averagePerformace.Remove(periferial.OverallPerformance);
            return periferial;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.averagePerformace.Average()}):");
            foreach (var peripherial in this.Peripherals)
            {
                sb.AppendLine($"  {peripherial}");
            }

            return sb.ToString().TrimEnd();
        }

        private double GetAverageOverallPerfomance()
        {
            double sum = 0;
            foreach (var peripherial in this.Peripherals)
            {
                sum += peripherial.OverallPerformance;
            }

            return sum /= this.Peripherals.Count;
        }
    }
}
