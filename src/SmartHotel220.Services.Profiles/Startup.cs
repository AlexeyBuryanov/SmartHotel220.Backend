using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartHotel220.Services.Profiles.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace SmartHotel220.Services.Profiles
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
                c.SwaggerDoc("v1", new Info { Title = "Hotels Api", Version = "v1" });
            });

            // Добавляем контекст БД
            services.AddDbContext<ProfilesDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

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

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            // Добавляем использование кросс доменных запросов (Cross Origin Resource Sharing)
            // Для запросов из приложения с одного адреса (или домена) к приложению, которое размещено по другому адресу
            app.UseCors(builder => {
                builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            // Настройка использования Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                var path = string.IsNullOrEmpty(pbase) || pbase == "/" ? "/" : $"{pbase}/";
                c.SwaggerEndpoint($"{path}swagger/v1/swagger.json", "Profiles Api");
            });

            app.UseMvc();
        } // Configure
    } // Startup
}