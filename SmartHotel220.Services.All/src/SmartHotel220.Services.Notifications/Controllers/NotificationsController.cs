using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHotel220.Services.Notifications.Services;
using System;
using System.Linq;

namespace SmartHotel220.Services.Notifications.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Контроллер уведомлений
    /// </summary>
    [Route("notifications")]
    public class NotificationsController : Controller
    {
        private readonly NotificationsService _notifSvc;

        public NotificationsController(NotificationsService notifSvc)
        {
            _notifSvc = notifSvc;
        }

        /// <summary>
        /// Получить для пользователя
        /// </summary>
        [Authorize]
        [HttpGet]
        public IActionResult GetByUser(int seq = -1)
        {
            var now = DateTime.Now;
            var userid = User.Claims.First(c => c.Type == "emails").Value;
            var data = _notifSvc.GetNotificationsForUser(userid)
                .Where(n => n.Seq > seq)
                .Where(n => n.Time <= now)  
                .Take(6);

            return Ok(data);
        } // GetByUser
    } // NotificationsController
}
