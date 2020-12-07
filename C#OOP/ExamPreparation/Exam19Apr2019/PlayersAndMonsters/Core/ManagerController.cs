namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerData;
        private ICardRepository cardData;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController()
        {
            this.playerData = new PlayerRepository();
            this.cardData = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = playerFactory.CreatePlayer(type, username);
            playerData.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = cardFactory.CreateCard(type, name);
            cardData.Add(card);

            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerData.Find(username);
            ICard card = this.cardData.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerData.Find(attackUser);
            IPlayer defender = this.playerData.Find(enemyUser);

            this.battleField.Fight(attacker, defender);

            return $"Attack user health {attacker.Health} - Enemy user health {defender.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in playerData.Players)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
