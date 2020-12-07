using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cardData;
        public CardRepository()
        {
            this.cardData = new List<ICard>();
        }
        public int Count => this.cardData.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardData;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.cardData.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardData.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cardData.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return this.cardData.Remove(card);
        }
    }
}
