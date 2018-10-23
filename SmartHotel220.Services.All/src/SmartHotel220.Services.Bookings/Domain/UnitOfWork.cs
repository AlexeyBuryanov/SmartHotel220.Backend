using System.Threading.Tasks;
using SmartHotel220.Services.Bookings.Data;

namespace SmartHotel220.Services.Bookings.Domain
{
    public class UnitOfWork
    {
        private readonly BookingsDbContext _db;

        public UnitOfWork(BookingsDbContext db)
        {
            _db = db;
        }

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
