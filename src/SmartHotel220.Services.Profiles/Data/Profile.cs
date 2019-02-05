namespace SmartHotel220.Services.Profiles.Data
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }

        /// <summary>
        /// Айди пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Псевдоним
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Лояльность
        /// </summary>
        public Loyalty Loyalty { get; set; }
    }
}
