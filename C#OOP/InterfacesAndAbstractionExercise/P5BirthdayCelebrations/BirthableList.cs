using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P5BirthdayCelebrations
{
    public class BirthableList
    {
        private List<IBirthable> list;

        public BirthableList()
        {
            this.list = new List<IBirthable>();
        }

        public void Add(IBirthable person)
        {
            this.list.Add(person);
        }
        public List<IBirthable> GetMatchedYear(string year)
        {
            List<IBirthable> listToReturn = this.list.Where(x => x.BirthDay.Contains(year)).ToList();
            return listToReturn;
        }


    }
}
