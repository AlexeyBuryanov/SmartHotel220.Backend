namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Сервис в номере
    /// </summary>
    public class ServicePerRoom
    {
        /// <summary>
        /// Тип номера
        /// </summary>
        public int RoomTypeId { get; set; }

        /// <summary>
        /// Сервис
        /// </summary>
        public int ServiceId { get; set; }

        public RoomService Service { get; set; }
        public RoomType RoomType { get; set; }
    }
}
