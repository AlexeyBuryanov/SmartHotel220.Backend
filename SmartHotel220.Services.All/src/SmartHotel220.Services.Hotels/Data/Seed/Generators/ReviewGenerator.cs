using SmartHotel220.Services.Hotels.Domain.Hotel;
using SmartHotel220.Services.Hotels.Domain.Review;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор отзывов
    /// </summary>
    public class ReviewGenerator
    {
        /// <summary>
        /// Сгенерировать отзывы для отелей
        /// </summary>
        public List<Review> GetReviews(List<Hotel> hotels, int reviewPerhotel = 25)
        {
            var userNameGenerator = new UserNameGenerator();
            var reviews = new List<Review>();
            var random = new Random();
            var comments = GetComments();

            hotels.ForEach(hotel => {
                for (var i = 0; i < reviewPerhotel; i++) {
                    var message = comments[random.Next(0, comments.Count)];
                    var roomType = hotel.RoomTypes.ElementAt(random.Next(0, hotel.RoomTypes.Count()));

                    reviews.Add(new Review {
                        HotelId = hotel.Id,
                        Date = GetRandomDate(),
                        Message = message,
                        RoomType = roomType.Name,
                        UserName = userNameGenerator.GetName(),
                        Rating = random.Next(3, 5)
                    });
                } // for i
            });

            return reviews;
        }

        private DateTime GetRandomDate()
        {
            var random = new Random();
            var minDate = new DateTime(2005, 1, 1);

            var maxDays = (DateTime.Today - minDate).Days;

            return minDate.AddDays(random.Next(maxDays));
        }

        private IList<string> GetComments()
        {
            return new List<string> {
                "Отличный отель. Лобби и ресторан впечатляют. Завтрак и ужин действительно хорошие. Сервис отличный и один из лучших в Лондоне.",
                "В ресторане и баре замечательно! Достаточно живой, и отлично подходит для бизнес-ланчей. Попробуйте ветчину и сыр тосты очень вкусные! Мы не заботились о нашей комнате; однако, условия порой спартанские.",
                "Мне очень нравится это место с чистыми и контролируемыми планшетами, с отличным выбором фильмов (отлично после долгого дня в офисе) и, самое главное, всегда дружелюбный персонал ...",
                "Отель расположен прямо за горой, с великолепными местами для завтрака и рядом с рынком. Двухспальный номер остаётся по той же цене, что и номер для одного, поэтому приводите друга с кем вы бы разделили двуспальную кровать.",
                "люблю этот отель: большой бар внизу, номера были немного больше, чем у конкурента, и это прямо за углом от ворот ... обязательно остановимся здесь снова",
                "Модный отель с лучшим лаунджем, который я когда-либо видел. Уютное место с удобными кроватями. Номера небольшие, но все в порядке. Забавный высокотехнологичный комфорт.",
                "Отличная концепция. Современный, не слишком чистый. Супер удобные кровати. Планшет Samsung, который контролирует все в вашей комнате, скорее представляет собой трюк, чем удобный инструмент.",
                "С того момента, как вы входите, вы можете сразу понять, почему этот отель был включен в список ежегодных World Architecture Festival Awards...",
                "Невероятно! Простые слова не могут описывать этого. Спа - это первоклассный декор, изысканный элегантный и красивый, как и все, кто здесь работает.",
                "фантастический отель, отличный сервис, прекрасная окружающая среда, довольно престижно, но не претендует на лучший номер, среди лучших, в которых я оставался. Хорошо, рекомендую",
                "Большой коктейль-бар с живой музыкой. Персонал изумительный и внимательный, не раздражает.",
                "Есть ли какая-то работа? Возьмите ноутбук и сидите на одном из удобных диванов. Отличный сигнал Wi-Fi и множество доступных точек.",
                "Объединяет целостность и характер исторического здания с простым и одновременно сложным дизайном. В отеле есть 173 номера, ресторан, два бара, место для проведения мероприятий, конференц-залы и привлекательный вестибюль."
            };
        } // GetComments
    } // ReviewGenerator
}