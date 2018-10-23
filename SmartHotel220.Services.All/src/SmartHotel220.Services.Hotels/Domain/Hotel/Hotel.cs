using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Отель
    /// </summary>
    public class Hotel
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Локация (место нахождения)
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City {get;set;}

        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Стартовая цена за ночь
        /// </summary>
        public int StarterPricePerNight => RoomTypes.Min(room => room.Price);

        /// <summary>
        /// Типы номеров
        /// </summary>
        public IEnumerable<RoomType> RoomTypes { get; set; }

        /// <summary>
        /// Конференц-залы
        /// </summary>
        public IEnumerable<ConferenceRoom> ConferenceRooms { get; set; }

        /// <summary>
        /// Сервисы
        /// </summary>
        public IEnumerable<ServicePerHotel> Services { get; set; }

        /// <summary>
        /// Кол-во посещений
        /// </summary>
        public int Visits { get; set; }

        /// <summary>
        /// Время регистрации
        /// </summary>
        public TimeSpan CheckinTime { get; set; }

        /// <summary>
        /// Время выписки
        /// </summary>
        public TimeSpan CheckoutTime { get; set; }

        /// <summary>
        /// Кол-во фото
        /// </summary>
        public int NumPhotos { get; set; }
    }
}