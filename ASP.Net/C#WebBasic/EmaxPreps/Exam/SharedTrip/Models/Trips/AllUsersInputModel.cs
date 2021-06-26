using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Models.Trips
{
    public class AllUsersInputModel
    {
        public ICollection<UsersTripInputModel> Users { get; set; }
    }
}
