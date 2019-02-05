using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Hotels.Domain.Hotel;
using SmartHotel220.Services.Hotels.Domain.Review;

namespace SmartHotel220.Services.Hotels.Data
{
    public class HotelsDbContext : DbContext
    {
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<RoomService> RoomServices { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public HotelsDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Используем алгоритм Hi/Lo для генерации уникальных идентификаторов,
            // которые в последствии образуют последовательности (sequences) баз данных
            // и которые затем кэшируются, масштабируются и решают проблемы параллелизма.
            // Рекомендуется использовать
            modelBuilder.Entity<Hotel>().Property(h => h.Id).ForSqlServerUseSequenceHiLo("hotelseq");

            // Используем комплексные типы
            modelBuilder.Entity<Hotel>().OwnsOne(h => h.Address);
            modelBuilder.Entity<Hotel>().OwnsOne(h => h.Location);

            // Указываем, что будет хранится только время
            modelBuilder.Entity<Hotel>().Property(h => h.CheckinTime).HasColumnType("time");
            modelBuilder.Entity<Hotel>().Property(h => h.CheckoutTime).HasColumnType("time");

            modelBuilder.Entity<HotelService>().Property(s => s.Id).ValueGeneratedNever();
            modelBuilder.Entity<HotelService>().Property(s => s.Name).HasMaxLength(32);

            modelBuilder.Entity<ServicePerHotel>().HasKey(sph => new { sph.HotelId, sph.ServiceId });

            modelBuilder.Entity<RoomService>().Property(s => s.Id).ValueGeneratedNever();
            modelBuilder.Entity<RoomService>().Property(s => s.Name).HasMaxLength(32);

            modelBuilder.Entity<ServicePerRoom>().HasKey(sph => new { sph.RoomTypeId, sph.ServiceId });

            modelBuilder.Entity<City>().Property(c => c.Id).ValueGeneratedNever();
        } // OnModelCreating
    } // HotelsDbContext
}