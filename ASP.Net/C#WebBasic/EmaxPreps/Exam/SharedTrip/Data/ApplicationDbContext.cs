namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;

    public class ApplicationDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(ut =>
            {
                ut.HasKey(x => new { x.UserId, x.TripId });

                ut.HasOne(x => x.User)
                    .WithMany(y => y.UserTrips)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                ut.HasOne(x => x.Trip)
                    .WithMany(y => y.UserTrips)
                    .HasForeignKey(x => x.TripId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
