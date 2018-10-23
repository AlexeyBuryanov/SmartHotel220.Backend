using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SmartHotel220.Services.Discount.Controllers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Discount.Services
{
    /// <summary>
    /// Сервис/служба лояльности
    /// </summary>
    public class LoyaltyService
    {
        private readonly string _url;
        private readonly ILogger _logger;

        public LoyaltyService(string url, ILogger<LoyaltyService> logger)
        {
            _url = url;
            _logger = logger;
        }

        /// <summary>
        /// Получить лояльность по клиенту
        /// </summary>
        /// <param name="userOrAlias">Пользователь или псевдоним</param>
        public async Task<Loyalty> GetLoyaltyByCustomer(string userOrAlias)
        {
            try {
                using (var client = new HttpClient()) {
                    // Запрос к API профилей
                    var response = await client.GetAsync($"{_url}profiles/{userOrAlias}");

                    // Если успешно
                    if (response.IsSuccessStatusCode) {
                        // Получаем json
                        var json = await response.Content.ReadAsStringAsync();
                        // Парсим профиль
                        dynamic profileResult = JObject.Parse(json);
                        // Получаем лояльность
                        int loyaltyAsInteger = profileResult.loyalty;

                        return (Loyalty)loyaltyAsInteger;
                    } else {
                        _logger.LogWarning($"Получено {response.StatusCode} ('{response.ReasonPhrase}') при вызове службы профиля для {userOrAlias}");

                        return Loyalty.None;
                    } // if
                } // using
            } catch (Exception ex) {
                _logger.LogError($"Исключение {ex.GetType().Name} ('{ex.Message}') при подключении к службе профиля {_url}");

                return Loyalty.None;
            } // try-catch
        } // GetLoyaltyByCustomer
    } // LoyaltyService
}