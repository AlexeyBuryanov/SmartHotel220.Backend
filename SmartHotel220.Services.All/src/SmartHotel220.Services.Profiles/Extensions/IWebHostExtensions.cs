using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace SmartHotel220.Services.Profiles.Extensions
{
    /// <summary>
    /// Расширение для IWebHost. Для миграции и заполнения базы при первоначальной загрузке
    /// </summary>
    public static class IWebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try {
                    logger.LogInformation($"Миграция базы данных, связанной с контекстом {typeof(TContext).Name}");
                    context.Database.Migrate();
                    seeder(context, services);
                    logger.LogInformation($"Мигрировала база данных, связанная с контекстом {typeof(TContext).Name}");
                } catch (Exception ex) {
                    logger.LogError(ex, $"Произошла ошибка при миграции базы данных, используемой в контексте {typeof(TContext).Name}");
                } // try-catch
            } // using
            return webHost;
        } // MigrateDbContext
    } // IWebHostExtensions
}