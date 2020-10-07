using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Transactions;

namespace P6.EqualityLogic
{
 
    public class Person : IComparable<Person>
    {
        public string name;
        public int age;

        public Person()
        {

        }

        public Person(string name, int age) : this()
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (this.name.CompareTo(other.name) == 0) //even names
            {
                if(this.age.CompareTo(other.age) == 0) //even ages
                {
                    return 0;
                }
                else if (this.age.CompareTo(other.age) < 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if(this.name.CompareTo(other.name) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }

        }

        public override bool Equals(object other)
        {
            var p = other as Person;
            if(p == null)
            {
                return false;
            }

            return this.name == p.name && this.age == p.age;
        }
        public override int GetHashCode()
        {
            var hash = this.name.Length * 7777;
            foreach (char ch in this.name)
            {
                hash += ch;
            }
            hash += this.age * 99999;

            return hash;
        }
    }
}
