using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Knjižara.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserHasAccess
    {
        private readonly RequestDelegate _next;

        public UserHasAccess(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/Admin"))
            {
                if (httpContext.Session.GetString("_UserRole") != null 
                    && httpContext.Session.GetInt32("_UserRole") != 2)
                {
                    httpContext.Response.Redirect("/");
                }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserHasAccessExtensions
    {
        public static IApplicationBuilder UseUserHasAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserHasAccess>();
        }
    }
}
