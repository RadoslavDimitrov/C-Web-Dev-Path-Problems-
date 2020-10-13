using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        //        •	Strength: int
        //•	Ability: int
        //•	Intelligence: int
        //The class constructor should receive strength, ability and intelligence and override the ToString() method in the following format:
        //"Item:"
        //"  * Strength: {Strength Value}"
        //"  * Ability: {Ability Value}"
        //"  * Intelligence: {Intelligence Value}"
        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public Item()
        {
            this.Strength = 0;
            this.Ability = 0;
            this.Intelligence = 0;
        }
        public Item(int str, int aby, int intell)
        {
            this.Strength = str;
            this.Ability = aby;
            this.Intelligence = intell;
        }

        public override string ToString()
        {
           return "Item:" + Environment.NewLine +
            $"  * Strength: {this.Strength}" + Environment.NewLine +
            $"  * Ability: {this.Ability}" + Environment.NewLine +
            $"  * Intelligence: {this.Intelligence}";
        }

    }
}
