using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SmartHotel220.Services.Hotels.Data;
using SmartHotel220.Services.Hotels.Data.Seed;
using SmartHotel220.Services.Hotels.Extensions;

namespace SmartHotel220.Services.Hotels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<HotelsDbContext>((context, services) => {
                    var db = services.GetService<HotelsDbContext>();
                    HotelsDbContextSeed.Seed(db);
                })
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .UseApplicationInsights()
                   .Build();
    }
}
