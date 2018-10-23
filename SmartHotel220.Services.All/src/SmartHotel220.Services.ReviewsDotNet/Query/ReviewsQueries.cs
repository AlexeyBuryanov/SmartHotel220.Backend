using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Reviews.Data;

namespace SmartHotel220.Services.Reviews.Query
{
    /// <summary>
    /// Запросы
    /// </summary>
    public class ReviewsQueries
    {
        private readonly ReviewsDbContext _db;

        public ReviewsQueries(ReviewsDbContext db) => _db = db;

        /// <summary>
        /// Получить отзывы по айди отеля
        /// </summary>
        public async Task<IEnumerable<Review>> GetByHotel(int hotelid)
        {
            var result = await _db.Reviews.Where(r => r.HotelId == hotelid)
                                          .OrderByDescending(r => r.Submitted)
                                          .ToListAsync();

            return result;
        } // GetByHotel
    } // ReviewsQueries
}