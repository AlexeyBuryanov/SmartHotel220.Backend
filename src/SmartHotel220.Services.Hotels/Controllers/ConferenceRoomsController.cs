using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Hotels.Queries;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер залов для конференций
    /// </summary>
    [Route("[controller]")]
    public class ConferenceRoomsController : Controller
    {
        private readonly ConferenceRoomSearchQuery _conferenceRoomSearchQuery;

        public ConferenceRoomsController(ConferenceRoomSearchQuery conferenceRoomSearchQuery)
        {
            _conferenceRoomSearchQuery = conferenceRoomSearchQuery;
        }

        /// <summary>
        /// Поиск конференц-зала
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult> Search(int? cityId, int? rating, int? minPrice, int? maxPrice, int? guests)
        {
            var filter = new ConferenceRoomSearchFilter {
                CityId = cityId,
                Rating = rating,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Guests = guests
            };

            var conferenceRooms = await _conferenceRoomSearchQuery.Get(filter);

            return Ok(conferenceRooms);
        } // Search
    } // ConferenceRoomsController
}