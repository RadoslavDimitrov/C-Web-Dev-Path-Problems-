using System;
using System.Collections.Generic;
using System.Text;

namespace P09.PokemonTrainer
{
    public class Pokemon
    {
        //•	Name
        //•	Element
        //•	Health

        private string name;

        private string element;

        private int health;

        public Pokemon(string name, string element, int HP)
        {
            this.Name = name;
            this.Element = element;
            this.Health = HP;
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }


        public string Element
        {
            get { return element; }
            set { element = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
