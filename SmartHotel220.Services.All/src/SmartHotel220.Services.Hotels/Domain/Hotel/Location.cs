namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Локация (место нахождения)
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Отель
        /// </summary>
        public int HotelId { get; set; }

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
