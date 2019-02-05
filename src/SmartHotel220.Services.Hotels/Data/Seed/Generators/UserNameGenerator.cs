using System;
using System.Collections.Generic;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    public class UserNameGenerator
    {
        private static readonly List<string> Names = new List<string>
        {
            "Софи Стивенсон", "Арно Миронович", "Тимофей Петрович", "Захарова Анфиса", "Шульц Владлен",
            "Полякова Маргарита", "Кузнецова Алла", "Трофимов Гремислав", "Морозов Афанасий", "Журавель Андрей",
            "Натаниэль Фитцджеральд", "Оливия Коэн", "Мартин Тодд", "Даррелл Рассел",
            "Демьянов Нифонт", "Данилова Любомила", "Ахметзянова Изабелла", "Белозёров Станислав",
            "Полякова Харитина", "Игнатьева Любовь", "Яковлев Анатолий", "Борисова Инна", "Константинова Сильва",
            "Барбара Рид", "Милли Стрикленд", "Эстелла Хаммонд", "Томми Нгуен", "Билли Мосс", "Нелл Грин"
        };

        public string GetName()
        {
            var random = new Random();
            var name = Names[random.Next(0, Names.Count)];

            return name;
        } // GetName
    } // UserNameGenerator
}