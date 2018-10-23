using SmartHotel220.Services.Hotels.Domain.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор отелей
    /// </summary>
    public class HotelsGenerator
    {
        /// <summary>
        /// Получить отели
        /// </summary>
        /// <param name="cities">Города</param>
        /// <param name="hotelsPerCity">Отелей на город</param>
        public List<Hotel> GetHotels(IEnumerable<City> cities, int hotelsPerCity = 3)
        {
            var pointGenerator = new GeoPointGenerator();
            var hotelNameGenerator = new HotelMetadataGenerator();
            var addressGenerator = new AddressGenerator();
            var cityGenerator = new CitiesGenerator();
            var servicesGenerator = new ServicesGenerator();
            var hotels = new List<Hotel>();

            foreach (var city in cities) {
                // Получаем типы отелей для города
                var hotelTypes = cityGenerator.GetHotelTypesPerCity(city.Id);

                foreach (var hotelType in hotelTypes) {
                    var hotelmetadata = hotelNameGenerator.Data.Single(hmd => hmd.HotelType == hotelType);
                    var random = new Random();
                    var rating = hotelmetadata.Rating;
                    var location = pointGenerator.GetClosePoint((city.Latitude, city.Longitude), 1000);
                    var (latitude, longitude) = location;

                    // Формируем отель
                    var hotel = new Hotel {
                        Name = $"{hotelmetadata.Prefix} {city.Name}",
                        Description = $"Роскошный отель {rating}-звёзд расположенный в {city.Name} который был открыт в {hotelmetadata.Year}. В отеле есть качественные номера и современная, хорошо оборудованная конференц-зона, где могут разместиться мероприятия любого типа на 100 человек. Это идеальная остановка в пути. Расположение идеально подходит для отдыха или бизнеса. Если вы просто хотите расслабиться, здесь можно прогуляться, велосипедные прогулки или автомобильные экскурсии в местные причудливые и исторические деревни и города в живописных окрестностях. Также вы можете расслабиться в нашей финской сауне, био-сауне, инфракрасной сауне, джакузи. Или заняться спортом в тренажерном зале. После расслабляющего ужина и горячительного напитка в нашем баре со сном не должно быть проблем в одном из наших уютных и комфортабельных номеров. Наш молодой и дружелюбный персонал здесь, чтобы приветствовать вас и служить вам. Надеемся увидеть вас в ближайшее время!",
                        City = city,
                        Address = new Address {
                            PostCode = addressGenerator.GetPostCode(),
                            Street = addressGenerator.GetStreet()
                        },
                        CheckinTime = new TimeSpan(15, 0, 0),
                        CheckoutTime = new TimeSpan(12, 0, 0),
                        Location = new Location { Latitude = latitude, Longitude = longitude },
                        Rating = rating,
                        Visits = random.Next(10000, 30000),
                        NumPhotos = 1,
                        RoomTypes = new[] {
                            GetRoomType(hotelmetadata.RoomTypes.single),
                            GetRoomType(hotelmetadata.RoomTypes.@double)
                        },
                        ConferenceRooms = new[] {
                            new ConferenceRoom {
                                Name = $"{HotelMetadataGenerator.GetConferenceRoomName(hotelType)}",
                                Rating = rating,
                                Capacity = 40,
                                PricePerHour = 190,
                                NumPhotos = 3
                            }
                        }
                    };

                    // Формируем сервисы отеля
                    hotel.Services = servicesGenerator.GetHotelServicesByHotelType(hotelType)
                        .Select(hs => new ServicePerHotel {
                            Service = hs,
                            Hotel = hotel
                        }).ToList();

                    hotels.Add(hotel);
                } // foreach
            } // foreach

            return hotels;
        } // GetHotels

        /// <summary>
        /// Определение номера по типу
        /// </summary>
        private RoomType GetRoomType(int type)
        {
            var serviceGenerator = new ServicesGenerator();
            RoomType room;

            switch (type) {
                case HotelSeedMetada.ROOMTYPE_SINGLE:
                    room = new RoomType {
                        Name = "Одноместный номер",
                        Capacity = 1,
                        Description = "Наши одноместные номера имеют площадь в 26м² с кроватью размером в 1,60 м.",
                        Price = 180,
                        NumPhotos = 3,
                        SingleBeds = 1
                    };
                    room.Services = serviceGenerator.GetRoomServices()
                        .Select(rs => new ServicePerRoom { RoomType = room, Service = rs }).ToList();
                    return room;

                case HotelSeedMetada.ROOMTYPE_DOUBLE:
                    room = new RoomType {
                        Name = "Двуместный номер",
                        Capacity = 2,
                        Description = "Двухместные номера имеют площадь в 32м² и две односпальные кровати 1,40 м",
                        Price = 300,
                        NumPhotos = 4,
                        TwinBeds = 2
                    };
                    room.Services = serviceGenerator.GetRoomServices()
                        .Select(rs => new ServicePerRoom { RoomType = room, Service = rs }).ToList();
                    return room;

                case HotelSeedMetada.ROOMTYPE_DOUBLE2:
                    room = new RoomType {
                        Name = "Двуместный номер",
                        Capacity = 2,
                        Description = "Двухместные номера имеют площадь в 40м² и две односпальные кровати 3,20 м",
                        Price = 400,
                        NumPhotos = 2,
                        TwinBeds = 2,
                    };
                    room.Services = serviceGenerator.GetRoomServices()
                        .Select(rs => new ServicePerRoom { RoomType = room, Service = rs }).ToList();
                    return room;

                case HotelSeedMetada.ROOMTYPE_LUXURY:
                    room = new RoomType {
                        Name = "Роскошный номер",
                        Capacity = 2,
                        Description = "Роскошный номер площадью 42 м² с двуспальной кроватью размера 3,20 м.",
                        Price = 500,
                        NumPhotos = 3,
                        DoubleBeds = 1,
                    };
                    room.Services = serviceGenerator.GetRoomServices()
                        .Select(rs => new ServicePerRoom { RoomType = room, Service = rs }).ToList();
                    return room;

                default:
                    return null;
            } // switch
        } // GetRoomType
    } // HotelsGenerator
}