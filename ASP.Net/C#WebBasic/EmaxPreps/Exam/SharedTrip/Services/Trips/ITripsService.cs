using SharedTrip.Models.Trips;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats,
            string description);

        bool IsDepartureTimeValid(string departureTime);

        AllTripsViewModel GetAllTrips();

        TripViewModel GetDetailsForTrip(string tripId);


        bool HasAvailableSeats(string tripId);

        bool AddUserToTrip(string userId, string tripId);

        ICollection<UsersTripInputModel> GetAllUsersToCurrentTrip(string tripId);
    }
}
