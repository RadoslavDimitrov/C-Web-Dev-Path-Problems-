using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    class Spy : Soldier, ISoldier, ISpy
    {
        public int CodeNumber { get; set; }
        public Spy(string id, string firstName, string lastName, int codeNumber)
            :base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();

        }
    }
}
