using Microsoft.AspNetCore.Builder;

namespace SmartHotel220.Services.Seedwork
{
    /// <summary>
    /// Расширение для IApplicationBuilder
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Промежуточная аутентификация от microsoft. Используется для демонстрации AAD B2C
        /// </summary>
        public static IApplicationBuilder UseByPassAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ByPassAuthMiddleware>();
        }
    }
}
