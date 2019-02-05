using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Hotels.Queries;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер сервисов/служб
    /// </summary>
    [Route("[controller]")]
    public class ServicesController : Controller
    {
        private readonly ServicesQuery _svcQuery;

        public ServicesController(ServicesQuery svcQuery)
        {
            _svcQuery = svcQuery;
        }

        /// <summary>
        /// Получить службы для отеля
        /// </summary>
        [HttpGet("hotel")]
        public async Task<IActionResult> GetHotelServices()
        {
            var data = await _svcQuery.GetAllHotelServices();

            return Ok(data);
        }

        /// <summary>
        /// Получить службы для номера
        /// </summary>
        [HttpGet("room")]
        public async Task<IActionResult> GetRoomServices()
        {
            var data = await _svcQuery.GetAllRoomServices();

            return Ok(data);
        } // GetRoomServices
    } // ServicesController
}