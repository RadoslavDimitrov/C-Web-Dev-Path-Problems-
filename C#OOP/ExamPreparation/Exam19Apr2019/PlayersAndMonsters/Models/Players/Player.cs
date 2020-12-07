using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepo;
        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.cardRepo = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository => this.cardRepo;

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.username = value;
            }
        }
        public int Health { get => this.health; 
            set 
            { 
                if(value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                this.health = value;
            } 
        }

        public bool IsDead => this.health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if(damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            this.health -= damagePoints;

            if(this.health < 0)
            {
                this.health = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Username: {this.username} - Health: {this.health} - Cards {this.cardRepo.Count}");

            foreach (var item in this.cardRepo.Cards)
            {
                sb.AppendLine($"Card: {item.Name} - Damage: {item.DamagePoints}");
            }

            sb.AppendLine("###");

            return sb.ToString().Trim();
        }
    }
}
