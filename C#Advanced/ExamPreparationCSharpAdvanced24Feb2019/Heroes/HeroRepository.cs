using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public int Count => this.data.Count;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var hero = data.FirstOrDefault(x => x.Name == name);
            this.data.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            
            var currItem = new Item(0, 0, 0);
            var maxHero = new Hero("", 0, currItem);
            foreach (var hero in data)
            {
                if(hero.Item.Strength > maxHero.Item.Strength)
                {
                    maxHero = hero;
                }
            }

            return maxHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var currItem = new Item(0, 0, 0);
            var maxHero = new Hero("", 0, currItem);
            foreach (var hero in data)
            {
                if (hero.Item.Ability > maxHero.Item.Ability)
                {
                    maxHero = hero;
                }
            }

            return maxHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var currItem = new Item(0, 0, 0);
            var maxHero = new Hero("", 0, currItem);
            foreach (var hero in data)
            {
                if (hero.Item.Intelligence > maxHero.Item.Intelligence)
                {
                    maxHero = hero;
                }
            }

            return maxHero;
        }

        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, data)}";
        }
    }
}
