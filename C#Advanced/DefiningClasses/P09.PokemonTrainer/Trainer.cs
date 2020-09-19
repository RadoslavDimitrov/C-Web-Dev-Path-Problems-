using System;
using System.Collections.Generic;
using System.Text;

namespace P09.PokemonTrainer
{
    public class Trainer
    {
        //•	Name
        //•	Number of badges - starts with 0
        //•	A collection of pokemon

        private string name;

        private int numberOfBadges;

        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.pokemons = new List<Pokemon>();

        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }


        public int NumberOfBadges
        {
            get { return numberOfBadges; }
            set { numberOfBadges = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public override string ToString()
        {
            //{trainerName} {badges} {numberOfPokemon}"
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
