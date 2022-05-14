using System;
using System.Collections.Generic;

namespace Exam.MoovIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var route = new Route("asd", 10D, 0, true, new List<string> { "sofia", "burgas" });
            var route1 = new Route("two", 10D, 0, true, new List<string> { "sofia", "burgas" });
            var route2 = new Route("three", 10D, 0, false, new List<string> { "sofia", "burgas" });
            var route3 = new Route("four", 10D, 0, false, new List<string> { "sofia", "burgas" });
            var route4 = new Route("five", 10D, 0, false, new List<string> { "sofia", "burgas" });

            var M = new MoovIt();
            M.AddRoute(route);
            M.AddRoute(route1);
            M.AddRoute(route2);
            M.AddRoute(route3);
            M.AddRoute(route4);
            var routes = M.GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints();

            Console.WriteLine(route);
        }
    }
}