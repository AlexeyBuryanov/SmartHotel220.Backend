using System;

namespace SmartHotel220.Services.Reviews.Data
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Review
    {
        public int Id { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Submitted { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Отель
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        public string FormattedDate { get; set; }
    }
}
