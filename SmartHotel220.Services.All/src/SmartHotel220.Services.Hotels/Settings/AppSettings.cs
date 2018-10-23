namespace SmartHotel220.Services.Hotels.Settings
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
