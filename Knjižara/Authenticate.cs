using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Knjižara
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Authenticate
    {
        private readonly RequestDelegate _next;

        public Authenticate(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticateExtensions
    {
        public static IApplicationBuilder UseAuthenticate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Authenticate>();
        }
    }
}
