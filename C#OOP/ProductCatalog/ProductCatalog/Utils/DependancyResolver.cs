using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Infrastructure.Data.Common;
using ProductCatalog.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Utils
{
    public static class DependancyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IRepository, ListRepository>();
            services.AddSingleton<Application>();
            services.AddScoped<Menu>();
            services.AddScoped<ProductPage>();

            return services.BuildServiceProvider();
        }
    }
}
