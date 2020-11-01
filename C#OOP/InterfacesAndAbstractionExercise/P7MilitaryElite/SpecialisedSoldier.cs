using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P7MilitaryElite
{
    public class SpecialisedSoldier : Private, IPrivate, ISoldier, ISpecialisedSoldier
    {
        private readonly Dictionary<string, string> corpsDict = new Dictionary<string, string>
        {
                {"Airforces", "Airforces"},
                {"Marines", "Marines"}
        };

        private string corps;
        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (!corpsDict.ContainsKey(value))
                {
                    throw new ArgumentException("invalid corps");
                }

                this.corps = value;
            }
        }
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            :base(id,firstName, lastName,salary)
        {
            this.Corps = corps;
        }
    }
}
