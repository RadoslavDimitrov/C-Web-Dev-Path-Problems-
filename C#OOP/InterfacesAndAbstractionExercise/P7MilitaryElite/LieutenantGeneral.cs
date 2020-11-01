using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    public class LieutenantGeneral : Private, ISoldier, IPrivate, ILieutenantGeneral
    {
        private List<Private> list;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            :base(id, firstName,lastName, salary)
        {
            this.list = new List<Private>();
        }

        public void AddPrivate(Private currPrivate)
        {
            this.list.Add(currPrivate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Privates:");

            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
