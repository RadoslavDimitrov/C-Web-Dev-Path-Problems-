using P3Raiding.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace P3Raiding.Core
{
    public class Engine
    {
        private List<BaseHero> group;
        private HeroFactory herofactory;

        public Engine()
        {
            this.group = new List<BaseHero>();
            this.herofactory = new HeroFactory();
        }

        public void Run()
        {
            int groupSize = int.Parse(Console.ReadLine());
            BaseHero hero = null;

            while (group.Count < groupSize)
            {
                string currName = Console.ReadLine();
                string currType = Console.ReadLine();

                hero = herofactory.CreateHero(currName, currType);

                if(hero != null)
                {
                    group.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int groupPower = 0;

            foreach (var item in group)
            {
                groupPower += item.Power;
                Console.WriteLine(item.CastAbility());
            }

            if(groupPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
