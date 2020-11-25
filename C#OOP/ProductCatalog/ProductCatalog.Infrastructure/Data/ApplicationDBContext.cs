using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
    }
}
