namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Конференц-зал
    /// </summary>
    public class ConferenceRoom
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
        /// Вместимость
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Цена в час
        /// </summary>
        public int PricePerHour { get; set; }

        /// <summary>
        /// Кол-во фото
        /// </summary>
        public int NumPhotos {get; set;}
    }
}
