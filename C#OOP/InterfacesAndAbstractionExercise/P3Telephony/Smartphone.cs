using System;
using System.Collections.Generic;
using System.Text;

namespace P3Telephony
{
    public class Smartphone : IWebSearchable, ICallable
    {
        private string number;
        private string url;

        public Smartphone(string number, string url)
        {
            this.Number = number;
            this.Url = url;
        }
        public string Url
        {
            get { return url; }
            set 
            {
                if (HasDigit(value))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                url = value;
            }
        }

        public string Number
        {
            get 
            {
                return number;
            }
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
            return $"Calling... {this.Number}";
        }

        public string SearchWeb()
        {
            return $"Browsing: {this.Url}!";
        }

        private bool HasDigit(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    return true;
                }
            }

            return false;
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
