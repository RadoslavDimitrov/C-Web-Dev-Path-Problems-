using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> playerData;
        public PlayerRepository()
        {
            this.playerData = new List<IPlayer>();
        }
        public int Count => this.playerData.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playerData;

        public IPlayer FirstOrDefault { get; internal set; }

        public void Add(IPlayer player)
        {
            CheckForNullPlayer(player);

            if (this.playerData.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.playerData.Add(player);
        }

        private static void CheckForNullPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
        }

        public IPlayer Find(string username)
        {
            return this.playerData.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            CheckForNullPlayer(player);

            return this.playerData.Remove(player);
        }
    }
}
