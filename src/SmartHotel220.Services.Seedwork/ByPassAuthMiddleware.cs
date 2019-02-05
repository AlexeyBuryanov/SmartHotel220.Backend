using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHotel220.Services.Seedwork
{
    /// <summary>
    /// Аутентификация ByPass с использованием Claims Identity
    /// </summary>
    internal class ByPassAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private string _currentUserId;

        public ByPassAuthMiddleware(RequestDelegate next)
        {
            _next = next;
            _currentUserId = null;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;

            if (path == "/noauth") {
                var userid = context.Request.Query["userid"];

                if (!string.IsNullOrEmpty(userid)) {
                    _currentUserId = userid;
                }

                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/string";

                await context.Response.WriteAsync($"Пользователь изменён на {_currentUserId}");
            } else if (path == "/noauth/reset") {
                _currentUserId = null;
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/string";

                await context.Response.WriteAsync("Пользователь не установлен. Токен только для защищённых конечных точек.");
            } else {
                var currentUserId = _currentUserId;

                var authHeader = context.Request.Headers["Authorization"];

                if (authHeader != StringValues.Empty) {
                    var header = authHeader.FirstOrDefault();

                    if (!string.IsNullOrEmpty(header) && header.StartsWith("Email ") && header.Length > "Email ".Length) {
                        currentUserId = header.Substring("Email ".Length);
                    } // if
                } // if

                if (!string.IsNullOrEmpty(currentUserId)) {
                    var user = new ClaimsIdentity(new[] {
                        new Claim("emails", currentUserId),
                        new Claim("name", "Demo user"),
                        new Claim("nonce", Guid.NewGuid().ToString()),
                        new Claim("ttp://schemas.microsoft.com/identity/claims/identityprovider", "ByPassAuthMiddleware"),
                        new Claim("nonce", Guid.NewGuid().ToString()),
                        new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname", "User"),
                        new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", "Microsoft")
                    }, "ByPassAuth");

                    context.User = new ClaimsPrincipal(user);
                } // if

                await _next.Invoke(context);
            } // if
        } // Invoke
    } // ByPassAuthMiddleware
}