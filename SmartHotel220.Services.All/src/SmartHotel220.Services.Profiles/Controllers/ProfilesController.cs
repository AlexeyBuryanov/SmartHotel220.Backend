using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Profiles.Data;
using System.Linq;

namespace SmartHotel220.Services.Profiles.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер профилей (учётных записей)
    /// </summary>
    [Route("[controller]")]
    public class ProfilesController : Controller
    {
        private readonly ProfilesDbContext _db;

        public ProfilesController(ProfilesDbContext ctx)
        {
            _db = ctx;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(string id)
        {
            var profile = _db.Profiles.SingleOrDefault(p => p.UserId == id);

            // Если по айди ничего не нашли, то ищем по псевдониму
            if (profile == null) {
                profile = _db.Profiles.FirstOrDefault(p => p.Alias == id);
            }

            return profile != null 
                       ? (IActionResult)Ok(profile) 
                       : (IActionResult)NotFound();
        } // Get
    } // ProfilesController
}