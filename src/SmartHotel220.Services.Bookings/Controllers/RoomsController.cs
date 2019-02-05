using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Bookings.Queries;
using System;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Bookings.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер номеров
    /// </summary>
    [Route("[controller]")]
    public class RoomsController : Controller
    {
        private readonly OccupancyQuery _occupancyQuery;

        public RoomsController(OccupancyQuery occupancyQuery)
        {
            _occupancyQuery = occupancyQuery;
        }

        /// <summary>
        /// Предсказать занятость комнаты/номера
        /// </summary>
        [HttpGet("{idRoom}/occupancy")]
        public async Task<IActionResult> PredictRoomOcupation(int idRoom, string date)
        {
            // Если дата нормальная
            if (DateTime.TryParse(date, 
                                  System.Globalization.CultureInfo.InvariantCulture, 
                                  System.Globalization.DateTimeStyles.None, 
                                  out var dt)) {
                // Получаем заполненность номера в солнечную и не солнечную погоду
                var (sunny, notSunny) = await _occupancyQuery.GetRoomOcuppancy(dt, idRoom);

                return Ok(new { OcuppancyIfSunny = sunny, OccupancyIfNotSunny = notSunny });
            } else {
                return BadRequest("Недействительная дата " + date);
            }
        } // PredictRoomOcupation
    } // RoomsController
}