using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public PlayerFactory()
        {

        }
        public IPlayer CreatePlayer(string type, string username)
        {
            ICardRepository cardRepo = new CardRepository();
            IPlayer player = null;

            switch (type.ToLower())
            {
                case "advanced":
                    player = new Advanced(cardRepo, username);
                    break;
                case "beginner":
                    player = new Beginner(cardRepo, username);
                    break;
            }

            return player;
        }
    }
}
