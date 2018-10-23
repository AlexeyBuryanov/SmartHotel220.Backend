using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Hotels.Queries;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контролирует города
    /// </summary>
    [Route("[controller]")]
    public class CitiesController : Controller
    {
        private readonly CitiesQuery _citiesQueries;

        public CitiesController(CitiesQuery citiesQueries)
        {
            _citiesQueries = citiesQueries;
        }

        /// <summary>
        /// Получить город по имени или список по умолчанию
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get(string name = "")
        {
            var cities = string.IsNullOrEmpty(name) ?
                             await _citiesQueries.GetDefaultCities() :
                             await _citiesQueries.Get(name);

            return Ok(cities);
        } // Get
    } // CitiesController
}