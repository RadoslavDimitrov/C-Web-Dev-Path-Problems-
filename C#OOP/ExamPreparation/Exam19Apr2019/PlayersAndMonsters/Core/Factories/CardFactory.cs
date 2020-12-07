using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public CardFactory()
        {

        }
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type.ToLower())
            {
                case "magic":
                    card = new MagicCard(name);
                    break;
                case "trap":
                    card = new TrapCard(name);
                    break;
            }

            return card;
        }
    }
}
