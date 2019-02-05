using Microsoft.EntityFrameworkCore;
using SmartHotel220.Services.Hotels.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Linq.Queryable;

namespace SmartHotel220.Services.Hotels.Queries
{
    /// <summary>
    /// Запросы связанные с городами
    /// </summary>
    public class CitiesQuery
    {
        private readonly HotelsDbContext _db;

        public CitiesQuery(HotelsDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Получить города начинающийся на
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="take">Кол-во</param>
        /// <returns></returns>
        public async Task<IEnumerable<CityResult>> Get(string name = "", int take = 5)
        {
            return await _db
                .Cities
                .Where(city => city.Name.StartsWith(name))
                .Take(take)
                .Select(city => new CityResult {
                    Id = city.Id,
                    Name = city.Name,
                    Country = city.Country
                })
                .ToListAsync();
        }

        /// <summary>
        /// Получить города по дефолту
        /// </summary>
        public Task<IEnumerable<CityResult>> GetDefaultCities()
        {
            return Task.FromResult(new[] {
                new CityResult { Id = 10, Name = "Нью-Йорк", Country = "США"},
                new CityResult { Id = 11, Name = "Санкт-Петербург", Country = "Россия"},
                new CityResult { Id = 1,  Name = "Киев", Country = "Украина"},
                new CityResult { Id = 30,  Name = "Рим", Country = "Италия"},
                new CityResult { Id = 20,  Name = "Барселона", Country = "Испания" }
            } as IEnumerable<CityResult>);
        } // GetDefaultCities
    } // CitiesQuery

    public class CityResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    } // CityResult
}