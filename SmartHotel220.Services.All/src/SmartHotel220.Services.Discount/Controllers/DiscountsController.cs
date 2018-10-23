using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Discount.Services;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Discount.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контролирует скидки
    /// </summary>
    [Route("[controller]")]
    public class DiscountsController : Controller
    {
        private readonly LoyaltyService _loyaltyService;

        public DiscountsController(LoyaltyService loyaltyService) => _loyaltyService = loyaltyService;

        /// <summary>
        /// Получить скидку для юзера
        /// </summary>
        [Route("{userid}")]
        [HttpGet]
        public async Task<IActionResult> GetDiscountPerUser(string userid)
        {
            // Получаем уровень лояльности клиента
            var loyaltyLevel = await _loyaltyService.GetLoyaltyByCustomer(userid);

            var discount = 0.0d;

            // В зависимости от уровня лояльности
            switch (loyaltyLevel) {
                case Loyalty.Silver:
                    discount = 0.05d;
                    break;

                case Loyalty.Platnum:
                    discount = 0.10d;
                    break;

                case Loyalty.Latinum:
                    discount = 0.20d;
                    break;

                default:
                    discount = 0.0d;
                    break;
            } // switch

            var discountResult = new {
                Discount = discount
            };

            return Ok(discountResult);
        } // GetDiscountPerUser
    } // DiscountsController


    public enum Loyalty
    {
        None = 0,
        Silver = 1,
        Platnum = 2,
        Latinum = 3
    } // Loyalty
}