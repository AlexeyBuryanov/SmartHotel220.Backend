using SmartHotel220.Services.Hotels.Domain.Hotel;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор сервисов/служб
    /// </summary>
    public class ServicesGenerator
    {
        private readonly List<HotelService> _commonServices;
        private readonly List<HotelService> _luxuryServices;
        private readonly List<HotelService> _spaServices;
        private readonly List<HotelService> _businessServices;
        private readonly List<HotelService> _familyServices;

        public ServicesGenerator()
        {
            _commonServices = new List<HotelService> {
                new HotelService { Id = 1, Name = "Бесплатный Wi-fi" },
                new HotelService { Id = 2, Name = "Парковка" },
                new HotelService { Id = 3, Name = "ТВ" },
                new HotelService { Id = 4, Name = "Кондиционер" },
                new HotelService { Id = 5, Name = "Сушилка" },
                new HotelService { Id = 6, Name = "Крытый камин" },
                new HotelService { Id = 8, Name = "Завтрак" },
                new HotelService { Id = 10, Name = "Трансфер до аэропорта" },
                new HotelService { Id = 13, Name = "Гимнастический зал" },
                new HotelService { Id = 15, Name = "Ресторан" },
                new HotelService { Id = 16, Name = "Доступно для инвалидов" },
                new HotelService { Id = 17, Name = "Лифт" }
            };

            _luxuryServices = new List<HotelService> {
                new HotelService { Id = 12, Name = "Фитнес клуб" }
            };

            _spaServices = new List<HotelService> {
                new HotelService { Id = 11, Name = "Бассейн" },
                new HotelService { Id = 14, Name = "Джакузи" }
            };
            
            _businessServices = new List<HotelService> {
                new HotelService { Id = 7, Name = "Рабочее пространство" }
            };

            _familyServices = new List<HotelService>();

            _businessServices.Add(new HotelService { Id = 9, Name = "Зона для детей" });
        }

        /// <summary>
        /// Получить все отельные сервисы
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HotelService> GetAllHotelServices()
        {
            return _commonServices.Concat(_businessServices).Concat(_familyServices).Concat(_spaServices).Concat(_luxuryServices);
        }

        /// <summary>
        /// Получить отельные сервисы по типу отеля
        /// </summary>
        public IEnumerable<HotelService> GetHotelServicesByHotelType(HotelType type)
        {
            switch (type) {
                case HotelType.Platinum:
                case HotelType.Gold:
                    return GetAllHotelServices();

                case HotelType.Spa:
                    return _commonServices.Concat(_spaServices);

                case HotelType.Business:
                    return _commonServices.Concat(_businessServices);

                case HotelType.Family:
                    return _commonServices.Concat(_familyServices);

                case HotelType.Ressort:
                    return _commonServices.Concat(_spaServices).Concat(_luxuryServices);

                case HotelType.Economy:
                    return _commonServices;

                default:
                    return _commonServices;
            }
        }

        /// <summary>
        /// Получить сервисы для номера
        /// </summary>
        public IEnumerable<RoomService> GetRoomServices()
        {
            return new[] {
                new RoomService { Id = 1, Name = "Ванна" },
                new RoomService { Id = 2, Name = "Общая ванна" },
                new RoomService { Id = 3, Name = "Кондиционер" },
                new RoomService { Id = 4, Name = "Поддержка экологии" },
                new RoomService { Id = 5, Name = "Рабочий стол" }
            };
        } // GetRoomServices
    } // ServicesGenerator
}