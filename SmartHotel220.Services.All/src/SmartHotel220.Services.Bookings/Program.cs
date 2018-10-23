using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SmartHotel220.Services.Bookings.Data;
using SmartHotel220.Services.Bookings.Domain.Booking;
using SmartHotel220.Services.Bookings.Extensions;
using System;
using System.Linq;

namespace SmartHotel220.Services.Bookings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDbContext<BookingsDbContext>((context, services) => {
                    var test = new Booking {
                        Id = 1,
                        CheckInDate = DateTime.MinValue,
                        CheckOutDate = DateTime.MinValue,
                        ClientEmail = "test@mail.com",
                        IdHotel = 1,
                        IdRoomType = 1,
                        NumberOfAdults = 1,
                        NumberOfChildren = 0,
                        NumberOfBabies = 0,
                        TotalCost = 200
                    };
					var alreadySeeded = context.Bookings.Any();
					if (!alreadySeeded) {
						context.Bookings.Add(test);
					}
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
