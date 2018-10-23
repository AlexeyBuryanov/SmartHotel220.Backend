using SmartHotel220.Services.Hotels.Data.Seed.Generators;
using System.Linq;

namespace SmartHotel220.Services.Hotels.Data.Seed
{
    /// <summary>
    /// Для заполнения базы
    /// </summary>
    public class HotelsDbContextSeed
    {
        public static void Seed(HotelsDbContext db)
        {
            // Проверка на заполненность
            var alreadySeeded = db.Cities.Any();
            if (alreadySeeded) {
                return;
            }

            var servicesGenerator = new ServicesGenerator();
            var citiesGenerator = new CitiesGenerator();
            var hotelsGenerator = new HotelsGenerator();
            var reviewGenerator = new ReviewGenerator();

            // Заполняем отельные сервисы
            var hotelServices = servicesGenerator.GetAllHotelServices();
            foreach (var service in hotelServices) {
                db.HotelServices.Add(service);
            }
            db.SaveChanges();

            // Заполняем сервисы для номеров
            var roomServices = servicesGenerator.GetRoomServices();
            foreach (var service in roomServices) {
                db.RoomServices.Add(service);
            }
            db.SaveChanges();

            // Заполняем города
            var cities = citiesGenerator.GetCities();
            cities.ForEach(city => db.Cities.Add(city));
            db.SaveChanges();

            var hotels = hotelsGenerator.GetHotels(cities);
            hotels.ForEach(hotel => db.Hotels.Add(hotel));
            db.SaveChanges();

            var reviews = reviewGenerator.GetReviews(hotels);
            reviews.ForEach(review => db.Reviews.Add(review));
            db.SaveChanges();
        } // Seed
    } // HotelsDbContextSeed
}