using SmartHotel220.Services.Hotels.Domain.Hotel;
using System.Collections.Generic;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор городов
    /// </summary>
    public class CitiesGenerator
    {
        private readonly Dictionary<int, HotelType[]> _hotelTypesPerCity;

        public CitiesGenerator()
        {
            _hotelTypesPerCity = new Dictionary<int, HotelType[]> {
                { 1, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Spa } },
                { 2, new[] { HotelType.Gold, HotelType.Business, HotelType.Ressort } },

                { 10, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Business } },
                { 11, new[] { HotelType.Family, HotelType.Ressort, HotelType.Economy } },
                { 12, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Family } },
                { 13, new[] { HotelType.Business, HotelType.Ressort, HotelType.Economy } },

                { 20, new[] { HotelType.Gold, HotelType.Spa, HotelType.Business } },
                { 21, new[] { HotelType.Gold, HotelType.Family, HotelType.Economy } },
                { 22, new[] { HotelType.Gold, HotelType.Family, HotelType.Ressort } },

                { 30, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Ressort } },
                { 31, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Ressort } },

                { 40, new[] { HotelType.Platinum, HotelType.Gold, HotelType.Spa } },
                { 41, new[] { HotelType.Gold, HotelType.Business, HotelType.Ressort } },
                { 42, new[] { HotelType.Gold, HotelType.Spa, HotelType.Business } }
            };
        }

        /// <summary>
        /// Типы отелей для конкретного города
        /// </summary>
        /// <param name="cityId">Город (айди)</param>
        public HotelType[] GetHotelTypesPerCity(int cityId) => _hotelTypesPerCity[cityId];

        public List<City> GetCities()
        {
            var cities = new List<City> {
                new City { Id = 1, Name = "Киев", Country = "Украина", Latitude = 50.4501f, Longitude = 30.5234f },
                new City { Id = 2, Name = "Москва", Country = "Россия", Latitude = 55.755826f, Longitude = 37.6172999f },

                new City { Id = 10, Name = "Нью-Йорк", Country = "США", Latitude = 40.712784f, Longitude = -74.005941f },
                new City { Id = 11, Name = "Санкт-Петербург", Country = "Россия", Latitude = 59.9342802f, Longitude = 30.3350986f },
                new City { Id = 12, Name = "Донецк", Country = "Украина", Latitude = 48.015883f, Longitude = 37.80285f },
                new City { Id = 13, Name = "Сиэтл", Country = "США", Latitude = 47.6062095f, Longitude = -122.3320708f },

                new City { Id = 20, Name = "Барселона", Country = "Испания", Latitude = 41.385064f, Longitude = 2.173403f },
                new City { Id = 21, Name = "Онтарио", Country = "Канада", Latitude = 43.653226f, Longitude = -79.3831843f },
                new City { Id = 22, Name = "Бари", Country = "Италия", Latitude = 41.1171231f, Longitude = 16.8719764f },

                new City { Id = 30, Name = "Рим", Country = "Италия", Latitude = 41.9027008f, Longitude = 12.4962352f },
                new City { Id = 31, Name = "Рокфорд", Country = "США", Latitude = 42.2752286f, Longitude = -89.0892887f },

                new City { Id = 40, Name = "Лас-Вегас", Country = "США", Latitude = 36.1699412f, Longitude = -115.1398296f },
                new City { Id = 41, Name = "Одесса", Country = "Украина", Latitude = 46.482526f, Longitude = 30.7233095f },
                new City { Id = 42, Name = "Харьков", Country = "Украина", Latitude = 49.9935f, Longitude = 36.230383f }
            };

            return cities;
        } // GetCities
    } // CitiesGenerator
}
