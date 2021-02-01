using System;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Addresse>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresse> Addresses { get; set; }
    }
}
