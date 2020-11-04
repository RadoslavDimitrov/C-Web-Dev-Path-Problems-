using System;
using System.Collections.Generic;
using System.Text;

namespace P3Raiding.models
{
    public class Warrior : BaseHero
    {
        private const int warPower = 100;
        public Warrior(string name) : base(name)
        {
            this.Power = warPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
