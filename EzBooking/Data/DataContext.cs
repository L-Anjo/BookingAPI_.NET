using EzBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EzBooking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<House> Houses{ get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<StatusHouse> StatusHouses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostalCode>()
                .Property(p => p.postalCode)
                .ValueGeneratedNever();

        }
    }
}
