using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options)
            :base(options)
        {
            
        }

        //TODO complete context

        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Sale> Sales { get; set; }
        DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Email)
                .IsUnicode(false);

                entity.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);

                entity.Property(c => c.CreditCardNumber)
                .IsRequired(true);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                product.Property(p => p.Quantity)
                .IsRequired(true);

                product.Property(p => p.Price)
                .IsRequired(true);

                product.Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description")
                .IsRequired(false);
            });

            modelBuilder.Entity<Store>(store =>
            {
                store.Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);
            });

            modelBuilder.Entity<Sale>(sale =>
            {
                sale.Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");

                sale.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

                sale.HasOne(s => s.Product)
                .WithMany(p => p.Sales)
                .HasForeignKey(s => s.ProductId);

                sale.HasOne(s => s.Store)
                .WithMany(st => st.Sales)
                .HasForeignKey(s => s.StoreId);


            });
        }

    }
}
