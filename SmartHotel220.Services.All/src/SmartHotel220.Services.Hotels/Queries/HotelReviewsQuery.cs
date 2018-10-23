using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Hotels.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Linq.Queryable;

namespace SmartHotel220.Services.Hotels.Queries
{
    /// <summary>
    /// Запросы к отзывам отеля
    /// </summary>
    public class HotelReviewsQuery
    {
        private readonly HotelsDbContext _db;

        public HotelReviewsQuery(HotelsDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Получить отзывы
        /// </summary>
        /// <param name="hotelId">Отель</param>
        /// <param name="take">Кол-во</param>
        public async Task<IEnumerable<HotelReview>> Get(int hotelId, int take = 20)
        {
            return await _db
                .Reviews
                .Where(review => review.HotelId == hotelId)
                .Take(take)
                .Select(review => new HotelReview {
                    User = review.UserName,
                    Room = review.RoomType,
                    Message = review.Message,
                    Rating = review.Rating,
                    Date = review.Date
                })
                .ToListAsync();
        } // Get
    } // HotelReviewsQuery

    public class HotelReview
    {
        public string User { get; set; }
        public string Room { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    } // HotelReview
}