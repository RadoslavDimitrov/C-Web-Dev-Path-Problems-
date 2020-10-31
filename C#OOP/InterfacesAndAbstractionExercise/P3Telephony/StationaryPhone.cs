using System;
using System.Collections.Generic;
using System.Text;

namespace P3Telephony
{
    public class StationaryPhone : ICallable
    {
        private string number;

        public StationaryPhone(string number)
        {
            this.Number = number;
        }
        public string Number
        {
            get { return number; }
            set 
            {
                if (HasLetter(value))
                {
                    throw new ArgumentException("Invalid number!");
                }
                number = value; 
            }
        }

        public string Call()
        {
            return $"Dialing... {this.Number}";
        }

        private bool HasLetter(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
