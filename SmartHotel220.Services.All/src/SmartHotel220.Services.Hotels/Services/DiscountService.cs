using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Hotels.Services
{
    /// <summary>
    /// Служба по скидкам
    /// </summary>
    public class DiscountService
    {
        private readonly string _url;
        private readonly ILogger _logger;

        public DiscountService(string url, ILogger<DiscountService> logger)
        {
            _url = url;
            _logger = logger;
        }

        /// <summary>
        /// Получить скидку по id клиента из отдельного микро-сервиса
        /// </summary>
        public async Task<double> GetDiscountByCustomer(string customerid)
        {
            try {
                using (var client = new HttpClient()) {
                    var response = await client.GetAsync($"{_url}discounts/{customerid}");

                    if (response.IsSuccessStatusCode) {
                        var json = await response.Content.ReadAsStringAsync();
                        dynamic discountResult = JObject.Parse(json);
                        double dvalue = discountResult.discount;

                        return dvalue;
                    } else {
                        _logger.LogWarning($"Получено {response.StatusCode} ('{response.ReasonPhrase}') при вызове дисконтного сервиса для {customerid}");

                        return 0.0d;
                    } // if-else
                } // using
            } catch (Exception ex) {
                _logger.LogError($"Исключение {ex.GetType().Name} ('{ex.Message}') при подключении к дисконтному сервису по {_url}");

                return 0.0d;
            } // try-catch
        } // GetDiscountByCustomer
    } // DiscountService
}