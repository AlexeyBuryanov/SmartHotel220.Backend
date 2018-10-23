using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartHotel220.Services.Configuration
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Этот метод вызывается во время выполнения. Используется для добавления сервисов в контейнер зависимостей.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Этот метод вызывается во время выполнения. Используется для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Базовый путь, если есть
            var pbase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pbase)) {
                app.UsePathBase(pbase);
            }

            // Добавляем использование кросс доменных запросов (Cross Origin Resource Sharing)
            // Для запросов из приложения с одного адреса (или домена) к приложению, которое размещено по другому адресу
            app.UseCors(builder => {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseMvc();
        } // Configure
    } // Startup
}