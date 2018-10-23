using SmartHotel220.Services.Bookings.Domain.Booking;

namespace SmartHotel220.Services.Bookings.Data.Repositories
{
    public class BookingRepository
    {
        private readonly BookingsDbContext _db;

        public BookingRepository(BookingsDbContext db)
        {
            _db = db;
        }

        public void Add(Booking booking)
        {
            _db.Bookings.Add(booking);
        }
    }
}
