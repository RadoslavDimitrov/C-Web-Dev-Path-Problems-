using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    public class Private : Soldier, ISoldier, IPrivate
    {
        private decimal salary;

        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id,firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.salary:F2}";
        }
    }
}
