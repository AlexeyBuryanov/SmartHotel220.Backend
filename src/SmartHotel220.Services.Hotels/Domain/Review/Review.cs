using System;

namespace SmartHotel220.Services.Hotels.Domain.Review
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Review
    {
        public int Id { get; set; }

        /// <summary>
        /// Отель
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Юзер
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя юзера
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Тип номера
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Выставленный рейтинг
        /// </summary>
        public int Rating { get; set; }
    }
}
