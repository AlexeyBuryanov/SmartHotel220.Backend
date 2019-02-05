using System.Collections.Generic;

namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Тип номера
    /// </summary>
    public class RoomType
    {
        public int Id { get; set; }

        /// <summary>
        /// Отель
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Вместимость
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Две односпалки (кол-во)
        /// </summary>
        public int DoubleBeds { get; set; }

        /// <summary>
        /// Одна односпалка (кол-во)
        /// </summary>
        public int SingleBeds { get; set; }

        /// <summary>
        /// Большая двуспалка (кол-во)
        /// </summary>
        public int TwinBeds { get; set; }

        /// <summary>
        /// Кол-во фото
        /// </summary>
        public int NumPhotos { get; set; }

        /// <summary>
        /// Сервисы в этом типе номера
        /// </summary>
        public IEnumerable<ServicePerRoom> Services { get; set; }
    }
}
