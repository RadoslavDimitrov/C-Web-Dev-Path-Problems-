using System;
using System.Collections.Generic;
using System.Text;

namespace P7MilitaryElite
{
    public interface IRepair
    {
        string PartName { get; set; }
        int HoursWorked { get; set; }
    }
}
