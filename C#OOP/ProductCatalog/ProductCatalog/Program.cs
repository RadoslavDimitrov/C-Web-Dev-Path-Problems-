using ProductCatalog.Utils;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace ProductCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DependancyResolver.GetServiceProvider();
            var app = serviceProvider.GetService<Application>();

            using(serviceProvider.CreateScope())
            {
                app.Run(args);
            }

        }
    }
}
