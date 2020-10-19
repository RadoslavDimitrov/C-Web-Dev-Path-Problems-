using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)    //adds an entity to the roster if there is room for it
        {
            if(this.roster.Count < this.Capacity && !roster.Any(x => x.Name == player.Name))
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)   //removes a player by given name, if such exists, and returns bool
        {

            if(this.roster.Exists(x => x.Name == name))
            {
                var currPl = this.roster.FirstOrDefault(x => x.Name == name);
                this.roster.Remove(currPl);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)  //promote(set his rank to "Member") the first player with the given name.
                                                    //If the player is already a "Member", do nothing.
        {
            if(this.roster.Exists(x => x.Name == name))
            {
                var currPl = this.roster.Find(x => x.Name == name);
                if(currPl.Rank != "Member")
                {
                    currPl.Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name) //demote(set his rank to "Trial") the first player with the given name.
                                                //If the player is already a "Trial",  do nothing.
        {
            if (this.roster.Any(x => x.Name == name))
            {
                var currPl = this.roster.Find(x => x.Name == name);
                if (currPl.Rank != "Trial")
                {
                    currPl.Rank = "Trial";
                }
            }
        }
          
        public Player[] KickPlayersByClass(string classy) //removes all the players by the given class 
                                                            //and returns all players from that class as an array
        {
            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != classy).ToList();

            return myArrayToReturn;
            //var returnedPlayers = this.roster.Where(x => x.Class == @class).ToArray();
            //this.roster = this.roster.Where(x => x.Class != @class).ToList();
            //return returnedPlayers;
        }
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: { this.Name}");

            foreach (var player in this.roster)
            {
                sb.Append(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
