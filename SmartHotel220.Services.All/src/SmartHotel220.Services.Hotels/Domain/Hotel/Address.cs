namespace SmartHotel220.Services.Hotels.Domain.Hotel
{
    /// <summary>
    /// Адрес
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostCode { get; set; }
    }
}
