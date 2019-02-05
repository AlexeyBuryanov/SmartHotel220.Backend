using System;

namespace SmartHotel220.Services.Bookings.Domain.Booking
{
    /// <summary>
    /// Бронирование
    /// </summary>
    public class Booking
    {
        public int Id { get; set; }

        /// <summary>
        /// Отель
        /// </summary>
        public int IdHotel { get; set; }

        /// <summary>
        /// Тип номера
        /// </summary>
        public int IdRoomType { get; set; }

        /// <summary>
        /// Клиентская почта
        /// </summary>
        public string ClientEmail { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Дата выписки
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Кол-во взрослых
        /// </summary>
        public byte NumberOfAdults { get; set; }

        /// <summary>
        /// Кол-во детей
        /// </summary>
        public byte NumberOfChildren { get; set; }

        /// <summary>
        /// Кол-во маленьких детей
        /// </summary>
        public byte NumberOfBabies { get; set; }

        /// <summary>
        /// Общая стоимость
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}
