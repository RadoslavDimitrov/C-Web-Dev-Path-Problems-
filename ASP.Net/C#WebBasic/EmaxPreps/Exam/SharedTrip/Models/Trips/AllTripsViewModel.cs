using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Models.Trips
{
    public class AllTripsViewModel
    {
        public ICollection<TripViewModel> Trips { get; set; }
    }
}
