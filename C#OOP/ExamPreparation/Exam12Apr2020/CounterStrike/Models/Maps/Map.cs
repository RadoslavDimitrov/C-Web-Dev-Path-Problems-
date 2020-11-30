using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = players.Where(x => x.GetType().Name == "Terrorist" && x.IsAlive == true).ToList();
            List<IPlayer> counters = players.Where(x => x.GetType().Name == "CounterTerrorist" && x.IsAlive == true).ToList();

            while (terrorists.Any(x => x.IsAlive) && counters.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(x => x.IsAlive))
                {
                    foreach (var counter in counters.Where(x => x.IsAlive))
                    {
                        counter.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counter in counters.Where(x => x.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(x => x.IsAlive))
                    {
                        terrorist.TakeDamage(counter.Gun.Fire());
                    }
                }
            }

            string result = terrorists.Any(x => x.IsAlive) ? "Terrorist wins!" : "Counter Terrorist wins!";

            return result;
        }
    }
}
