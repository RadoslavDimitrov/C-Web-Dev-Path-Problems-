﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P3Raiding.models
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;
        public Druid(string name) 
            : base(name)
        {
            this.Power = druidPower;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}