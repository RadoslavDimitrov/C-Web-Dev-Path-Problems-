using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();

            while (command != "Tournament")
            {
                string[] currInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                Trainer currTrainer = new Trainer(currInput[0]);
                Pokemon currPokemon = new Pokemon(currInput[1], currInput[2], int.Parse(currInput[3]));

                if (trainers.Exists(x => x.Name == currTrainer.Name)) //if we have the current trainer
                {
                    int indexOfTrainer = trainers.FindIndex(x => x.Name == currInput[0]);
                    trainers[indexOfTrainer].Pokemons.Add(currPokemon);
                }
                else
                {
                    currTrainer.Pokemons.Add(currPokemon);
                    trainers.Add(currTrainer);
                }

                command = Console.ReadLine();
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string currElement = input;

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Pokemons.Exists(x => x.Element == currElement)) //we have the ele
                    {
                        trainers[i].NumberOfBadges++;
                    }
                    else //we dont have the curr ele
                    {
                        for (int currPokemon = 0; currPokemon < trainers[i].Pokemons.Count; currPokemon++)
                        {
                            trainers[i].Pokemons[currPokemon].Health -= 10;

                            if(trainers[i].Pokemons[currPokemon].Health <= 0) //is pokemon dead?
                            {
                                trainers[i].Pokemons.Remove(trainers[i].Pokemons[currPokemon]);
                            }
                        }
                    }
                }
                


                input = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
