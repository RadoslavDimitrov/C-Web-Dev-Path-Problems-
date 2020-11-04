using System;
using System.Collections.Generic;
using System.Text;

namespace P3Raiding
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        public BaseHero(string name)
        {
            this.Name = name;
        }
        public  int Power
        {
            get { return power; }
            protected set { power = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public abstract string CastAbility();


    }
}
