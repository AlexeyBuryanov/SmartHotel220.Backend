using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SmartHotel220.Services.Profiles.Data;
using SmartHotel220.Services.Profiles.Data.Seed;
using SmartHotel220.Services.Profiles.Extensions;

namespace SmartHotel220.Services.Profiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                  .MigrateDbContext<ProfilesDbContext>((context, services) => {
                      var db = services.GetService<ProfilesDbContext>();
                      ProfilesDbContextSeed.Seed(db);
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
