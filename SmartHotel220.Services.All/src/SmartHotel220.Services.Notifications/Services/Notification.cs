using System;

namespace SmartHotel220.Services.Notifications.Services
{
    public class Notification
    {
        /// <summary>
        /// Последовательность
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// Дата и время
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public NotificationType Type { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
    } // Notification

    public enum NotificationType
    {
        BeGreen,
        Room,
        Hotel,
        Other
    } // NotificationType
}