namespace SmartHotel220.Services.Bookings.Settings
{
    public class AppSettings
    {
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }
}
