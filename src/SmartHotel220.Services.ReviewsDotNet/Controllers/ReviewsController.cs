using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Reviews.Query;

namespace SmartHotel220.Services.Reviews.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер отзывов
    /// </summary>
    [Route("[controller]")]
    public class ReviewsController : Controller
    {
        private readonly ReviewsQueries _queries;           // запросы
        private readonly FormatDateService _formatDateSvc;  // сервис предоставляет форматирование даты

        public ReviewsController(ReviewsQueries queries, FormatDateService fds)
        {
            _queries = queries;
            _formatDateSvc = fds;
        }

        /// <summary>
        /// Получить отзывы по id отеля
        /// </summary>
        [Route("hotel/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var reviews = await _queries.GetByHotel(id);

            foreach (var  review in reviews) {
                review.FormattedDate = _formatDateSvc.FormatAsString(review.Submitted);
            }

            return Ok(reviews);
        } // Get
    } // ReviewsController
}
