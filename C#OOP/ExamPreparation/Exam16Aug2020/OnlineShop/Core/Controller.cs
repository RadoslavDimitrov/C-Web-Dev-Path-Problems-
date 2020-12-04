using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherials;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherials = new List<IPeripheral>();
        }

        //check for ID
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = CheckForComputerWithId(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            switch (componentType.ToLower())
            {
                case "centralprocessingunit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "powersupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "randomaccessmemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "solidstatedrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "videocard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            this.components.Add(component);
            computer.AddComponent(component);
            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computerId);
        }



        //No check for ID
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            switch (computerType.ToLower())
            {
                case "desktopcomputer":
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case "laptop":
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }


        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = CheckForComputerWithId(computerId);

            if (this.peripherials.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripherial = null;

            switch (peripheralType.ToLower())
            {
                case "headset":
                    peripherial = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "keyboard":
                    peripherial = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "monitor":
                    peripherial = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "mouse":
                    peripherial = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);

            }

            this.peripherials.Add(peripherial);
            computer.AddPeripheral(peripherial);
            return string.Format(SuccessMessages.AddedPeripheral, peripherial.GetType().Name, peripherial.Id, computer.Id);
        }

        //No check for ID
        public string BuyBest(decimal budget)
        {
            List<IComputer> computersToBuy = this.computers.Where(x => x.Price <= budget).OrderByDescending(x => x.Price).ToList();

            if(computersToBuy.Count == 0)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            return computersToBuy[0].ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = CheckForComputerWithId(id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = CheckForComputerWithId(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = CheckForComputerWithId(computerId);

            IComponent component = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);
            computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = CheckForComputerWithId(computerId);

            IPeripheral peripherial = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            computer.RemovePeripheral(peripheralType);
            this.peripherials.Remove(peripherial);

            return $"Successfully removed {peripheralType} with id {peripherial.Id}.";
        }

        private IComputer CheckForComputerWithId(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers.First(c => c.Id == id);
        }
    }
}
