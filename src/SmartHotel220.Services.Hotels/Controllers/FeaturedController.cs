using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Hotels.Queries;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер рекомендаций/фич для отеля
    /// </summary>
    [Route("[controller]")]
    public class FeaturedController : Controller
    {
        private readonly FeaturedItemsHotelsQuery _featuredQuery;

        public FeaturedController(FeaturedItemsHotelsQuery featuredQuery)
        {
            _featuredQuery = featuredQuery;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var userid = (string)null;

            if (User.Identity.IsAuthenticated) {
                userid = User.Claims.First(c => c.Type == "emails").Value;
            }

            // Если пользователь авторизован даём конкретные рекомендации.
            // Иначе рекомендации по умолчанию
            var hotels = userid != null 
                             ? await _featuredQuery.GetForUser(userid) 
                             : await _featuredQuery.Get();

            return Ok(hotels);
        } // Get
    } // FeaturedController
}