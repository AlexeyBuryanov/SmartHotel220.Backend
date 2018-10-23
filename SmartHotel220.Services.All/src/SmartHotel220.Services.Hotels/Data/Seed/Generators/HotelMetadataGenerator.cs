using System.Collections.Generic;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор метаданных для отеля
    /// </summary>
    public class HotelMetadataGenerator
    {
        public IEnumerable<HotelSeedMetada> Data => _data;
        private static readonly List<HotelSeedMetada> _data = new List<HotelSeedMetada> {
            new HotelSeedMetada("Sh220 Платина", 5, HotelType.Platinum, 1996),
            new HotelSeedMetada("Sh220 Золото", 5, HotelType.Gold, 1998),
            new HotelSeedMetada("Sh220 SPA", 5, HotelType.Spa, 2000),
            new HotelSeedMetada("Sh220 Бизнес", 4, HotelType.Business, 2006),
            new HotelSeedMetada("Sh220 Семейный", 4, HotelType.Family, 2010),
            new HotelSeedMetada("Sh220 Курортный", 4, HotelType.Ressort, 2008),
            new HotelSeedMetada("Sh220 Экономный", 3, HotelType.Economy, 2015)
        };

        private static readonly List<string> ConferenceRoomNames = new List<string> {
            "Крутой зал",
            "Классный зал",
            "Бизнес зал",
            "Деловой зал",
            "Для избранных",
            "Бизнес презентации"
        };

        public static string GetConferenceRoomName(HotelType type)
        {
            return ConferenceRoomNames[(int)type % ConferenceRoomNames.Count];
        }
    } // HotelMetadataGenerator


    public class HotelSeedMetada
    {
        // Типы номеров отличаются кол-вом спален
        public const int ROOMTYPE_SINGLE = 1;
        public const int ROOMTYPE_DOUBLE = 2;
        public const int ROOMTYPE_DOUBLE2 = 3;
        public const int ROOMTYPE_LUXURY = 4;

        /// <summary>
        /// Префикс в названии отеля
        /// </summary>
        public string Prefix { get; }
        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; }

        /// <summary>
        /// Тип номера
        /// </summary>
        public HotelType HotelType { get; }
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; }

        public HotelSeedMetada(string name, int rating, HotelType type, int year)
        {
            HotelType = type;
            Prefix = name;
            Rating = rating;
            Year = year;
        }

        /// <summary>
        /// Типы номеров в зависимости от типа отеля
        /// </summary>
        public (int single, int @double) RoomTypes {
            get {
                switch (HotelType) {
                    case HotelType.Platinum:
                    case HotelType.Gold:
                        return (ROOMTYPE_SINGLE, ROOMTYPE_LUXURY);

                    case HotelType.Family:
                    case HotelType.Business:
                    case HotelType.Economy:
                        return (ROOMTYPE_SINGLE, ROOMTYPE_DOUBLE);

                    case HotelType.Spa:
                    case HotelType.Ressort:
                        return (ROOMTYPE_SINGLE, ROOMTYPE_DOUBLE2);

                    default:
                        return (ROOMTYPE_SINGLE, ROOMTYPE_DOUBLE);
                } // switch
            } // get
        } // RoomTypes
    } // HotelSeedMetada


    public enum HotelType
    {
        Platinum = 1,
        Gold = 2,
        Spa = 3,
        Business = 4,
        Family = 5,
        Ressort = 6,
        Economy = 7
    } // HotelType
}