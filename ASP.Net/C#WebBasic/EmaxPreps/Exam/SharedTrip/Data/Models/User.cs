using SharedTrip.Data;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User : IdentityUser<string>
    {
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
