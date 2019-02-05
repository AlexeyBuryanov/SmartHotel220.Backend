using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Bookings.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Bookings.Queries
{
    /// <summary>
    /// Запрос на получение брони по пользователю
    /// </summary>
    public class UserBookingQuery
    {
        private readonly BookingsDbContext _db;

        public UserBookingQuery(BookingsDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Получить все бронирования пользователя (последние 100)
        /// </summary>
        public async Task<IEnumerable<UserBooking>> GetAll(string userId)
        {
            return await _db
                .Bookings
                .Where(booking => booking.ClientEmail == userId)
                .OrderByDescending(booking => booking.CheckOutDate)
                .Take(100)
                .Select(booking => new UserBooking {
                    Id = booking.Id,
                    HotelId = booking.IdHotel,
                    From = booking.CheckInDate,
                    To = booking.CheckOutDate,
                    Adults = booking.NumberOfAdults,
                    Babies = booking.NumberOfBabies,
                    Kids = booking.NumberOfChildren,
                    Price = booking.TotalCost
                })
                .ToListAsync();
        }

        /// <summary>
        /// Получить последнюю бронь
        /// </summary>
        public async Task<UserBooking> GetLatest(string userId)
        {
            return await _db
                .Bookings
                .Where(booking => booking.ClientEmail == userId)
                .OrderByDescending(booking => booking.CheckOutDate)
                .Select(booking => new UserBooking {
                    Id = booking.Id,
                    HotelId = booking.IdHotel,
                    From = booking.CheckInDate,
                    To = booking.CheckOutDate,
                    Adults = booking.NumberOfAdults,
                    Babies = booking.NumberOfBabies,
                    Kids = booking.NumberOfChildren
                })
                .FirstOrDefaultAsync();
        } // GetLatest
    } // UserBookingQuery

    /// <summary>
    /// Пользовательская бронь
    /// </summary>
    public class UserBooking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public byte Adults { get; set; }
        public byte Babies { get; set; }
        public byte Kids { get; set; }
        public decimal Price { get; set; }
    } // UserBooking
}