using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Knjižara.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Guest
    {
        private readonly RequestDelegate _next;

        public Guest(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/Account"))
            {
                if (httpContext.Session.GetString("_UserRole") != null)
                {
                    if (httpContext.Session.GetInt32("_UserRole") == 2)
                    {
                        httpContext.Response.Redirect("/Admin/Books");
                    } else
                    {
                        httpContext.Response.Redirect("/");
                    }
                }
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GuestExtensions
    {
        public static IApplicationBuilder UseGuest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Guest>();
        }
    }
}
