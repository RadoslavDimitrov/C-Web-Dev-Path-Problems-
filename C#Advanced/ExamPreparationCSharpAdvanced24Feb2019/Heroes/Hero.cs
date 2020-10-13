using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        //        •	Name: string
        //•	Level: int
        //•	Item: Item
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public Hero()
        {
            this.Name = "";
            this.Level = 0;
            this.Item = new Item(0, 0, 0);
        }
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            return $"Hero: {this.Name} – {this.Level}lvl" + Environment.NewLine +
                   $"{this.Item}";

        }

        
    }
}
