using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SmartHotel220.Services.Hotels.Queries;
using SmartHotel220.Services.Hotels.Services;
using SmartHotel220.Services.Hotels.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер отелей
    /// </summary>
    [Route("[controller]")]
    public class HotelsController : Controller
    {
        private readonly HotelsSearchQuery _hotelsSearchQuery;
        private readonly HotelDetailQuery _hotelDetailQuery;
        private readonly DiscountService _discountSvc;
        private readonly CurrencySettings _currencyConf;

        public HotelsController(HotelsSearchQuery hotelsSearchQuery, HotelDetailQuery hotelDetailQuery,
            DiscountService discountService, IOptions<CurrencySettings> currencyConf)
        {
            _hotelsSearchQuery = hotelsSearchQuery;
            _hotelDetailQuery = hotelDetailQuery;
            _discountSvc = discountService;
            _currencyConf = currencyConf.Value;
        }

        /// <summary>
        /// Поиск отеля по заданным критериям
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult> Search(int? cityId, int? rating, int? minPrice, int? maxPrice)
        {
            var filter = new HotelSearchFilter {
                CityId = cityId,
                Rating = rating,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            var hotels = await _hotelsSearchQuery.Get(filter);

            return Ok(hotels);
        }

        /// <summary>
        /// Получить подробности отеля
        /// </summary>
        /// <param name="id">ИД отеля</param>
        /// <param name="user">Если ИД юзера будет не найден</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id, string user)
        {
            var userId = User.Claims.SingleOrDefault(c => c.Type == "emails")?.Value;

            if (!string.IsNullOrEmpty(user)) {
                userId = user;
            }

            var discount = 0.0d;
            if (!string.IsNullOrEmpty(userId)) {
                discount = await _discountSvc.GetDiscountByCustomer(userId);
            }

            // Получаем отель со всей информацией учитывая скидку
            var hotel = await _hotelDetailQuery.Get(id, discount);

            if (hotel == null) {
                return NotFound();
            }

            // Учитываем конвертацию в ценах
            foreach (var roomSummary in hotel.Rooms) {
                roomSummary.BadgeSymbol = _currencyConf.Badge;
                roomSummary.LocalOriginalRoomPrice = roomSummary.OriginalRoomPrice * _currencyConf.BaseConversion;
                roomSummary.LocalRoomPrice = roomSummary.RoomPrice * _currencyConf.BaseConversion;
            }

            return Ok(hotel);
        }

        /// <summary>
        /// Получить номера по конкретному отелю
        /// </summary>
        [HttpGet("{hotelid:int}/rooms")]
        public async Task<ActionResult> GetRoomsByHotel(int hotelId)
        {
            var rooms = await _hotelDetailQuery.GetRoomsByHotel(hotelId);

            if (rooms == null) {
                return NotFound($"Отель {hotelId} найти невозможно");
            }

            return Ok(rooms);
        } // GetRoomsByHotel
    } // HotelsController
}