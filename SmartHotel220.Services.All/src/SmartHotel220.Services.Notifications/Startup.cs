using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SmartHotel220.Services.Notifications.Services;
using SmartHotel220.Services.Seedwork;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace SmartHotel220.Services.Notifications
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
            // Transient - объект сервиса создается каждый раз, когда к нему обращается запрос
            services.AddTransient<NotificationsService>();

            if (!string.IsNullOrEmpty(Configuration["k8sname"])) {
                services.EnableKubernetes();
            }

            // Добавляем swagger generator
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Notifications Api", Version = "v1" });
            });

            // Настраиваем swagger generator
            services.ConfigureSwaggerGen(swaggerGen => {
                // Active Directory B2C
                var b2cConfig = Configuration.GetSection("b2c");
                var authority = string.Format("https://login.microsoftonline.com/{0}/oauth2/v2.0", b2cConfig["Tenant"]);

                swaggerGen.AddSecurityDefinition("Swagger", new OAuth2Scheme {
                    AuthorizationUrl = authority + "/authorize",
                    Flow = "implicit",
                    TokenUrl = authority + "/connect/token",
                    Scopes = new Dictionary<string, string> {
                        { "openid", "User offline" },
                    }
                });
            });

            // Добавляем аутентификацию (Active Directory B2C)
            // используя JwtBearer для Open ID Connect
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtOpt => {
                var b2cConfig = Configuration.GetSection("b2c");
                jwtOpt.Authority = string.Format("https://login.microsoftonline.com/tfp/{0}/{1}/v2.0/",
                                                 b2cConfig["tenant"], b2cConfig["policy"]);
                jwtOpt.TokenValidationParameters = new TokenValidationParameters {
                    ValidAudiences = b2cConfig["audiences"].Split(',')
                };
            });

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

            app.UseByPassAuth();
            app.UseAuthentication();

            // Настройка использования Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                var path = string.IsNullOrEmpty(pbase) || pbase == "/" ? "/" : $"{pbase}/";

                c.InjectOnCompleteJavaScript($"{path}swagger-ui-b2c.js");
                c.SwaggerEndpoint($"{path}swagger/v1/swagger.json", "Notifications Api");
                // AAD B2C
                var b2cConfig = Configuration.GetSection("b2c");
                c.ConfigureOAuth2(b2cConfig["ClientId"], "y", "z", "z", "",
                    new {
                        p = "B2C_1_SignUpInPolicy",
                        prompt = "login",
                        nonce = "defaultNonce"
                    });
            });

            app.UseMvc();
        } // Configure
    } // Startup
}