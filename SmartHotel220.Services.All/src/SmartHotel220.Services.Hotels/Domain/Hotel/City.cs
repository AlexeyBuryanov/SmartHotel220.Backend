namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Longitude { get; set; }
    }
}
