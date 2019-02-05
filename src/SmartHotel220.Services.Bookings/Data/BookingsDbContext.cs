using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Bookings.Domain.Booking;

namespace SmartHotel220.Services.Bookings.Data
{
    public class BookingsDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public BookingsDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable("Booking");

            modelBuilder.Entity<Booking>()
                        .Property(b => b.ClientEmail).IsRequired()
                        .HasMaxLength(50);

            modelBuilder.Entity<Booking>().Property(e => e.TotalCost)
                        .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<Booking>()
                        .Property(b => b.CheckInDate).HasColumnType("date");

            modelBuilder.Entity<Booking>()
                        .Property(b => b.CheckOutDate).HasColumnType("date");
        }
    }
}