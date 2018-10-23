using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Bookings.Commands;
using SmartHotel220.Services.Bookings.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Bookings.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер API для бронирования
    /// </summary>
    [Route("[controller]")]
    public class BookingsController : Controller
    {
        /// <summary>
        /// Для получения брони
        /// </summary>
        private readonly UserBookingQuery _userBookingQuery;
        /// <summary>
        /// Для создания брони
        /// </summary>
        private readonly CreateBookingCommand _createBookingCommand;

        public BookingsController(UserBookingQuery userBookingQuery, CreateBookingCommand createBookingCommand)
        {
            _userBookingQuery = userBookingQuery;
            _createBookingCommand = createBookingCommand;
        }

        /// <summary>
        /// Получить последние 100 броней последнего пользователя
        /// </summary>
        [HttpGet]
        [Authorize]
        public Task<ActionResult> Get()
        {
            var userId = User.Claims.Single(c => c.Type == "emails").Value;

            return GetBookingsOfUser(userId);
        }

        /// <summary>
        /// Получить последние 100 броней пользователя
        /// </summary>
        [HttpGet("{email}")]
        [Authorize]
        public async Task<ActionResult> Get(string email)
        {
            var userId = User.Claims.Single(c => c.Type == "emails").Value;

            if (!string.IsNullOrEmpty(email) && userId != email) {
                return NotFound(new { Message = $"Бронирований для {email} не найдено" });
            }

            return await GetBookingsOfUser(userId);
        }

        /// <summary>
        /// Самая последняя бронь самого последнего пользователя
        /// </summary>
        [HttpGet("latest")]
        [Authorize]
        public Task<ActionResult> GetLatest()
        {
            var userId = User.Claims.Single(c => c.Type == "emails").Value;

            return GetLatestBookingOfUser(userId);
        }

        /// <summary>
        /// Самая последняя бронь конкретного пользователя
        /// </summary>
        [HttpGet("latest/{email}")]
        [Authorize]
        public async Task<ActionResult> GetLatest(string email)
        {
            var userId = User.Claims.Single(c => c.Type == "emails").Value;

            if (!string.IsNullOrEmpty(email) && userId != email) {
                return NotFound(new { Message = $"Бронирования для {email} не найдено" });
            }

            return await GetLatestBookingOfUser(userId);
        }

        /// <summary>
        /// Создать бронь
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody]BookingRequest bookingRequest)
        {
            var userId = User.Claims.First(c => c.Type == "emails").Value;

            if (!string.IsNullOrEmpty(bookingRequest.UserId) && bookingRequest.UserId != userId) {
                return BadRequest("Значение userId должно быть зарегистрированным идентификатором пользователя");
            }

            bookingRequest.UserId = userId;

            await _createBookingCommand.Execute(bookingRequest);

            return Ok();
        }

        /// <summary>
        /// Получить все бронирования пользователя (последние 100)
        /// </summary>
        private async Task<ActionResult> GetBookingsOfUser(string userId)
        {
            var bookings = await _userBookingQuery.GetAll(userId);

            if (bookings == null) {
                return NotFound();
            }

            return Ok(bookings);
        }

        /// <summary>
        /// Получить последнюю бронь конкретного пользователя
        /// </summary>
        private async Task<ActionResult> GetLatestBookingOfUser(string userId)
        {
            var booking = await _userBookingQuery.GetLatest(userId);

            if (booking == null) {
                return NotFound();
            }

            return Ok(booking);
        } // GetLatestBookingOfUser
    } // BookingsController
}