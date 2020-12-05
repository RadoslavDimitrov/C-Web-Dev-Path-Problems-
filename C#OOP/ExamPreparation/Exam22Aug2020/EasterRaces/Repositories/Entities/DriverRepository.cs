using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> data;

        public DriverRepository()
        {
            this.data = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.data;
        }

        public IDriver GetByName(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return this.data.Remove(model);
        }
    }
}
