using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Hotels.Data;
using SmartHotel220.Services.Hotels.Domain.Hotel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Queries
{
    /// <summary>
    /// Запросы по сервисам
    /// </summary>
    public class ServicesQuery
    {
        private readonly HotelsDbContext _db;

        public ServicesQuery(HotelsDbContext db) => _db = db;

        /// <summary>
        /// Получить все отельные сервисы
        /// </summary>
        public async Task<IEnumerable<HotelService>> GetAllHotelServices()
        {
            return await _db.HotelServices.OrderBy(s => s.Id).ToListAsync();
        }

        /// <summary>
        /// Получить все сервисы в номере
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoomService>> GetAllRoomServices()
        {
            return await _db.RoomServices.OrderBy(s => s.Id).ToListAsync();
        } // GetAllRoomServices
    } // ServicesQuery
}