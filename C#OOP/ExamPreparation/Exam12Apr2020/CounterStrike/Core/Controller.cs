using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Enums;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> guns;
        private IRepository<IPlayer> players; //must be dictionary
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            if(type != GunTypes.Pistol.ToString() && type != GunTypes.Rifle.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            IGun gun = null;

            if(type == GunTypes.Pistol.ToString())
            {
                gun = new Pistol(name, bulletsCount);
            }
            else
            {
                gun = new Rifle(name, bulletsCount);
            }

            this.guns.Add(gun);

            string msg = string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if(type != PlayerTypes.Terrorist.ToString() && type != PlayerTypes.CounterTerrorist.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            IGun gun = guns.FindByName(gunName);

            if(gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            if(type == PlayerTypes.CounterTerrorist.ToString())
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                player = new Terrorist(username, health, armor, gun);
            }

            this.players.Add(player);

            string msg = string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
            return msg;
        }

        public string Report()
        {
            players = players.OrderBy
        }

        public string StartGame()
        {
            return this.map.Start(players);
        }
    }
}
