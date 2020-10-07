using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P5.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person()
        {
            this.age = 0; 
        }

        public Person(string name, int age, string town) : this()
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }


        public int CompareTo([AllowNull] Person other)
        {
            if(this.name.CompareTo(other.name) == 0) //even name
            {
                if(this.age.CompareTo(other.age) == 0) //even age
                {
                    if(this.town.CompareTo(other.town) == 0) //even town
                    {
                        return 0;
                    }
                    else if(this.town.CompareTo(other.town) < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if(this.age.CompareTo(other.age) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if(this.name.CompareTo(other.name) < 0) //is smaller
            {
                return -1;
            }
            else // is bigger
            {
                return 1;
            }
        }
    }
}
