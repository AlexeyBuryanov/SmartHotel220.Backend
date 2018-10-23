using System;
using System.Collections.Generic;

namespace SmartHotel220.Services.Notifications.Services
{
    /// <summary>
    /// Сервис уведомлений
    /// </summary>
    public class NotificationsService
    {
        private const int START_HOUR = 8;
        private const int INC_MINUTES = 15;
        private const int MAX_NOTIFS = 50;

        /// <summary>
        /// Получить уведомления для пользователя
        /// </summary>
        public IEnumerable<Notification> GetNotificationsForUser(string userid)
        {
            var notifs = new List<Notification> {
                new Notification {
                    Type = NotificationType.BeGreen,
                    Text = "Температура в вашей комнате была отрегулирована для экономии энергии при сохранении вашего комфорта."
                },
                new Notification
                {
                    Type = NotificationType.Hotel,
                    Text = "В баре скоро начнётся новое шоу!"
                },
                new Notification {
                    Type = NotificationType.Room,
                    Text = "Ваша комната была убрана."
                },
                new Notification {
                    Type = NotificationType.Hotel,
                    Text = "SPA доступна сегодня до 11 вечера!"
                },
                new Notification {
                    Type = NotificationType.BeGreen,
                    Text = "Окружающий свет был отрегулирован в соответствии с новыми погодными условиями."
                },
                new Notification {
                    Type = NotificationType.Hotel,
                    Text = "Насладитесь нашим широким выбором пива в баре SmartHotel220."
                },
                new Notification {
                    Type = NotificationType.BeGreen,
                    Text = "Одно полотенце было заменено в вашем номере!"
                },
                new Notification {
                    Type = NotificationType.Room,
                    Text = "В вашем номере ждет подарок, любезно предоставленный отелем. Наслаждайся!"
                }
            };

            var today = DateTime.Now.Date;

            for (var idx = 0; idx < MAX_NOTIFS; idx++) {
                var notif = notifs[idx % notifs.Count];
                notif.Seq = idx;
                notif.Time = today.AddMinutes(idx * INC_MINUTES);

                // возвращаем уведомление и запоминаем текущую позицию за счёт yield
                yield return notif;
            } // for idx
        } // GetNotificationsForUser
    } // NotificationsService
}