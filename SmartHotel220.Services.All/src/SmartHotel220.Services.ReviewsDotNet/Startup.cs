using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartHotel220.Services.Reviews.Config;
using SmartHotel220.Services.Reviews.Data;
using SmartHotel220.Services.Reviews.Query;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartHotel220.Services.Reviews
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
            if (!string.IsNullOrEmpty(Configuration["k8sname"])) {
                services.EnableKubernetes();
            }

            // Добавляем swagger generator
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Reviews Api", Version = "v1" });
            });

            // Transient - объект сервиса создается каждый раз, когда к нему обращается запрос
            services.AddTransient<FormatDateService>();
            services.AddTransient<ReviewsQueries>();

            // Добавляем сервисы для использования опций
            services.AddOptions();
            // Конфиг для формата даты
            services.Configure<DateFormatConfig>(Configuration);

            // Добавляем контекст БД
            services.AddEntityFrameworkNpgsql().AddDbContext<ReviewsDbContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        // Этот метод вызывается во время выполнения. Используется для настройки конвейера HTTP-запросов.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Настройка фабрики логов
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Trace);

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

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            // Настройка использования Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                var path = string.IsNullOrEmpty(pbase) || pbase == "/" ? "/" : $"{pbase}/";
                c.SwaggerEndpoint($"{path}swagger/v1/swagger.json", "Reviews Api");
            });

            app.UseMvc();
        } // Configure
    } // Startup
}