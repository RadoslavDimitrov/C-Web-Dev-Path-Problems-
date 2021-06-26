using SharedTrip.Data;
using SharedTrip.Models.Trips;
using SharedTrip.Services.Trips;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (String.IsNullOrEmpty(model.StartPoint))
            {
                return this.Redirect("/Trips/Add");    
            }
            if (String.IsNullOrEmpty(model.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }
            if (String.IsNullOrEmpty(model.DepartureTime))
            {
                return this.Redirect("/Trips/Add");
            }

            if (!this.tripsService.IsDepartureTimeValid(model.DepartureTime))
            {
                return this.Redirect("/Trips/Add");
            }

            if (model.Seats < DataConstants.TripMinSeats || model.Seats > DataConstants.TripMaxSeats)
            {
                return this.Redirect("/Trips/Add");
            }

            if (String.IsNullOrEmpty(model.Description) || model.Description.Length > DataConstants.TripDescriptionMaxLenght)
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Create(model.StartPoint, model.EndPoint, model.DepartureTime, model.ImagePath, model.Seats, model.Description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.tripsService.GetAllTrips();

            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.tripsService.GetDetailsForTrip(tripId);
            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.GetUserId();

            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Redirect($"/Trips/AddUserToTrip?tripId=" +tripId);
            }

            var isUserAdded = this.tripsService.AddUserToTrip(userId, tripId);
            if (!isUserAdded)
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }
            return this.Redirect("/Trips/All");
        }
    }
}
