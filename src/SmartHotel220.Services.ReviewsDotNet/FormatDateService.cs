using System;
using Microsoft.Extensions.Options;
using SmartHotel220.Services.Reviews.Config;

namespace SmartHotel220.Services.Reviews
{
    /// <summary>
    /// Сервис для форматирования дат
    /// </summary>
    public class FormatDateService
    {
        // Конфиг
        private readonly DateFormatConfig _cfg;

        public FormatDateService(IOptions<DateFormatConfig> cfg)
        {
            _cfg = cfg.Value;
        }

        public string FormatAsString(DateTime date)
        {
            if (!string.IsNullOrEmpty(_cfg.DateFormat)) {
                return date.ToString(_cfg.DateFormat);
            } else {
                return date.ToLongDateString() + " " + date.ToLongTimeString();
            } // if
        } // FormatAsString
    } // FormatDateService
}
