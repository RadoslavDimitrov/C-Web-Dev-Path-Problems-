using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> data;

        public CarRepository()
        {
            this.data = new List<ICar>();
        }
        public void Add(ICar model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.data;
        }

        public ICar GetByName(string name)
        {
            return this.data.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.data.Remove(model);
        }
    }
}
