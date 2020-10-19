using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set 
            { 
                if(age > 0 && age <= 15)
                {
                    age = value;
                }

            }
        }

        public Child(string name, int age)
            : base(name, age)
        {
            if(age <= 15)
            {
                this.Age = age;
            }
        }
    }
}
