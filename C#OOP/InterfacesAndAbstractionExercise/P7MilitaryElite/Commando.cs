using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P7MilitaryElite
{
    public class Commando : SpecialisedSoldier, ISoldier, IPrivate,ISpecialisedSoldier, ICommando
    {
        private List<Mission> list;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.list = new List<Mission>();
        }

        public void CompleteMission(Mission mission)
        {
            var currMission = this.list.FirstOrDefault(x => x.CodeName == mission.CodeName);

            if (currMission != null)
            {
                currMission.State = "Finished";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var item in list)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
