using Microsoft.AspNetCore.Mvc;

namespace SmartHotel220.Services.Bookings.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
