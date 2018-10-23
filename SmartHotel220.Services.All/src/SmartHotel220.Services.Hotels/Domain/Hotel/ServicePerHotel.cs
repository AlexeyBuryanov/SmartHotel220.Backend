namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Сервис в отеле
    /// </summary>
    public class ServicePerHotel
    {
        /// <summary>
        /// Отель
        /// </summary>
        public int HotelId { get; set; }

        /// <summary>
        /// Сервис
        /// </summary>
        public int ServiceId { get; set; }

        public HotelService Service { get; set; }
        public Hotel Hotel { get; set; }
    }
}
