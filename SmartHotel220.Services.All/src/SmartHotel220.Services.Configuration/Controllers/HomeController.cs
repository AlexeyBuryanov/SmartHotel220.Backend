using Microsoft.AspNetCore.Mvc;

namespace SmartHotel220.Services.Configuration.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToRoute("MainConfigRoute");
        }
    }
}
