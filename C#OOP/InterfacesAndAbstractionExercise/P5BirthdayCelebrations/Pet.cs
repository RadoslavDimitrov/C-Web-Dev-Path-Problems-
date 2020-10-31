using System;
using System.Collections.Generic;
using System.Text;

namespace P5BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthDay;
        public Pet(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public string BirthDay
        {
            get
            {
                return this.birthDay;
            }
            private set
            {
                this.birthDay = value;
            }
        }
    }
}
