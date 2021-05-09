using BattleCards.Models;
using BattleCards.Services;
using BattleCards.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        public ICardsService CardsService { get; }

        public CardsController(ICardsService cardsService)
        {
            CardsService = cardsService;
        }
        public HttpResponse All()
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.CardsService.GetAll();
            return this.View(model);
        }

        public HttpResponse Collection()
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var cards = this.CardsService.GetUserCards(userId);

            return this.View(cards);
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardModel input)
        {
            if (input.Name.Length < 5 || input.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long");
            }

            if(input.Attack < 0)
            {
                return this.Error("Attack should be positive number");
            }

            if(input.Health < 0)
            {
                return this.Error("Health should be positive number");
            }

            if(input.Description.Length > 200)
            {
                return this.Error("Description should be less than 200 characters long");
            }


            int cardId = this.CardsService.AddCard(input);
            var user = this.GetUserId();

            this.CardsService.AddCardToUserCollection(user, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.GetUserId();
            this.CardsService.AddCardToUserCollection(user, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var user = this.GetUserId();
            this.CardsService.RemoveCardFromUserCollection(user, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}
