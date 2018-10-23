using System;

namespace SmartHotel220.Services.Hotels.Data.Seed.Generators
{
    /// <summary>
    /// Генератор гео-точек
    /// </summary>
    public class GeoPointGenerator
    {
        /// <summary>
        /// Получить ближайшую точку
        /// </summary>
        /// <param name="coordinate">Координаты</param>
        /// <param name="radius">Радиус</param>
        /// <returns>Координаты</returns>
        public (double Latitude, double Longitude) GetClosePoint((double Latitude, double Longitude) coordinate, int radius)
        {
            var random = new Random();
            
            double radiusInDegrees = radius / 111300f;

            double u = random.NextDouble();
            double v = random.NextDouble();

            double w = radiusInDegrees * Math.Sqrt(u);
            double t = 2 * Math.PI * v;

            double x = w * Math.Cos(t);
            double y = w * Math.Sin(t);

            double newX = x / Math.Cos(coordinate.Latitude);

            double foundLongitude = newX + coordinate.Longitude;
            double foundLatitude = y + coordinate.Latitude;

            return (Latitude: foundLatitude, Longitude: foundLongitude);
        } // GetClosePoint
    } // GeoPointGenerator
}