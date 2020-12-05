using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> data;

        public RaceRepository()
        {
            this.data = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.data.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.data;
        }

        public IRace GetByName(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.data.Remove(model);
        }
    }
}
