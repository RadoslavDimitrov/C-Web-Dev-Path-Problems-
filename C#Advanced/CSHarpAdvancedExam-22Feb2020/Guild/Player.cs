using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        //•	Name: string
        //•	Class: string
        //•	Rank: string – "Trial" by default
        //•	Description: string – "n/a" by default
        public Player(string name, string myClass)
        {
            this.Name = name;
            this.Class = myClass;
            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        //"Player {Name}: {Class}
        //Rank: {Rank}
        //Description: {Description}"

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
