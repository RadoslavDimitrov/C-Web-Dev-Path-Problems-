using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        public ApplicationDbContext Db { get; }
        
        public CardsService(ApplicationDbContext db)
        {
            Db = db;
        }


        public int AddCard(AddCardModel model)
        {

            Card card = new Card()
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
                Keyword = model.Keyword,

            };

            this.Db.Cards.Add(card);
            this.Db.SaveChanges();

            return card.Id;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.Db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.Db.UserCards.Add(new UserCard { UserId = userId, CardId = cardId });

            this.Db.SaveChanges();
        }

        public GetAllCardsViewModel GetAll()
        {
            var cards = this.Db.Cards.Select(x => new CardViewModel
            {
                Attack = x.Attack,
                Description = x.Description,
                Health = x.Health,
                Id = x.Id,
                Image = x.ImageUrl,
                Keyword = x.Keyword,
                Name = x.Name
            })
            .ToArray();

            GetAllCardsViewModel model = new GetAllCardsViewModel
            {
                Cards = cards
            };

            return model;
        }

        public GetAllCardsViewModel GetUserCards(string userId)
        {
            var cards = this.Db.UserCards.Where(x => x.UserId == userId).Select(uc => new CardViewModel
            {
                Id = uc.CardId,
                Name = uc.Card.Name,
                Attack = uc.Card.Attack,
                Health = uc.Card.Health,
                Description = uc.Card.Description,
                Image = uc.Card.ImageUrl,
                Keyword = uc.Card.Keyword
            })
                .ToArray();

            GetAllCardsViewModel model = new GetAllCardsViewModel()
            {
                Cards = cards
            };

            return model;
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var card = this.Db.UserCards.Where(x => x.UserId == userId && x.CardId == cardId).FirstOrDefault();

            this.Db.UserCards.Remove(card);
            this.Db.SaveChanges();
        }
    }
}
