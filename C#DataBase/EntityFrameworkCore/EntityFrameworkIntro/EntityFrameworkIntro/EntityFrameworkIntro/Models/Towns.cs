using System;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;

namespace SoftUni.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
