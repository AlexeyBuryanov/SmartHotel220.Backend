using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Hotels.Queries;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроль отзывов
    /// </summary>
    [Route("[controller]")]
    public class ReviewsController : Controller
    {
        private readonly HotelReviewsQuery _hotelReviewsQuery;

        public ReviewsController(HotelReviewsQuery hotelReviewsQuery)
        {
            _hotelReviewsQuery = hotelReviewsQuery;
        }

        /// <summary>
        /// Получить отзывы для отеля
        /// </summary>
        [HttpGet("{hotelId:int}")]
        public async Task<ActionResult> Get(int hotelId)
        {
            var reviews = await _hotelReviewsQuery.Get(hotelId);

            return Ok(reviews);
        } // Get
    } // ReviewsController
}