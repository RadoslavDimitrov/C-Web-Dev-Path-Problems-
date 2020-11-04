using P3Raiding.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P3Raiding.Factory
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;
            switch (type.ToLower())
            {
                case "druid":
                    return hero = new Druid(name);
                case "paladin":
                    return hero = new Paladin(name);
                case "rogue":
                    return hero = new Rogue(name);
                case "warrior":
                    return hero = new Warrior(name);
                default:
                    return hero;
            }
        }
    }
}
