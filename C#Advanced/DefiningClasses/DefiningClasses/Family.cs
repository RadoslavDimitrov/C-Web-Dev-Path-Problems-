using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetGetOldestMember()
        {
            var Person = people.OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return Person;
                
        }

        
    }
}
