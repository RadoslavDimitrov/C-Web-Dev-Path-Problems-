using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        private Dictionary<string, Route> routesById;

        public MoovIt()
        {
            this.routesById = new Dictionary<string, Route>();
        }
        public int Count => this.routesById.Count;

        public void AddRoute(Route route)
        {
            if (this.routesById.ContainsKey(route.Id))
            {
                throw new ArgumentException();
            }

            this.routesById.Add(route.Id, route);
            
        }

        public void ChooseRoute(string routeId)
        {
            if (!this.routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            this.routesById[routeId].Popularity += 1;
        }

        public bool Contains(Route route)
        {
            if (this.routesById.ContainsKey(route.Id))
            {
                return true;
            }

            var routes = this.routesById.Values.Where(r => r.LocationPoints.Count == route.LocationPoints.Count
                && r.LocationPoints[0] == route.LocationPoints[0]
                   && r.LocationPoints[r.LocationPoints.Count - 1] == route.LocationPoints[route.LocationPoints.Count - 1]);

            if(routes.Count() > 0)
            {
                return true;
            }

            return false;
        }
        public Route GetRoute(string routeId)
        {
            if (!this.routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            return this.routesById[routeId];
        }
        public void RemoveRoute(string routeId)
        {
            if (!this.routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            this.routesById.Remove(routeId);
        }

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
        {
            return this.routesById.Values.Where(r => r.IsFavorite == true)
                .Where(r => r.LocationPoints[0] != destinationPoint && r.LocationPoints.Contains(destinationPoint))
                .OrderBy(r => r.Distance)
                .ThenByDescending(r => r.Popularity);
        }


        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
        {
            return this.routesById.Values
                .OrderByDescending(r => r.IsFavorite == true)
                .OrderByDescending(r => r.Popularity)
                .ThenBy(r => r.Distance)
                .ThenBy(r => r.LocationPoints.Count())
                .Take(5);
        }


        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
        {
            return this.routesById.Values
                .Where(r => r.LocationPoints.Contains(startPoint) && r.LocationPoints.Contains(endPoint))
                .OrderByDescending(r => r.IsFavorite == true)
                .ThenBy(r => Math.Abs(r.LocationPoints.IndexOf(endPoint) - r.LocationPoints.IndexOf(startPoint)))
                .ThenByDescending(r => r.Popularity);
                
        }
    }
}
