using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IOFile = System.IO.File;

namespace SmartHotel220.Services.Configuration.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Глобальные настройки в виде конфига
    /// </summary>
    [Route("cfg", Name = "MainConfigRoute")]
    public class ConfigController : Controller
    {
        /// <summary>
        /// Получить конфиг
        /// </summary>
        [HttpGet("{file}")]
        public async Task<IActionResult> GetConfig(string file)
        {
            var fname = $@"cfg{Path.DirectorySeparatorChar}{file}.json";

            if (IOFile.Exists(fname)) {
                var data = await IOFile.ReadAllBytesAsync(fname);
                // Возвращаем в JSON'e
                return File(data, "application/json");
            }

            return NotFound($"Не найден файл '{file}'");
        }

        /// <summary>
        /// Получить все конфиги (их имена) без расширения
        /// </summary>
        [HttpGet("")]
        public IActionResult GetAllConfigNames()
        {
            const string path = "cfg";

            var files = Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly)
                                 .Select(Path.GetFileNameWithoutExtension);

            return Ok(files);
        } // GetAllConfigNames
    } // ConfigController
}