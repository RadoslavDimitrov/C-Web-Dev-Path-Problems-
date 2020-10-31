using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    public interface IMission
    {
        string State { get; }
        string CodeName { get; }
    }
}
