using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardModel model);

        void AddCardToUserCollection(string userId, int cardId);

        GetAllCardsViewModel GetAll();

        GetAllCardsViewModel GetUserCards(string userId);

        void RemoveCardFromUserCollection(string userId, int cardId);
    }
}
