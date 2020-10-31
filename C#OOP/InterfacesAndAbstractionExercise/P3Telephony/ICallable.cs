using System;
using System.Collections.Generic;
using System.Text;

namespace P3Telephony
{
    public interface ICallable
    {
        public string Number { get; }
        string Call();
    }
}
