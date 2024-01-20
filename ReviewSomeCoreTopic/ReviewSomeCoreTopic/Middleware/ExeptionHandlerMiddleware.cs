using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ReviewSomeCoreTopic.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExeptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExeptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
             await   httpContext.Response.WriteAsync("Errrrrrrrrrror\n");

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExeptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExeptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExeptionHandlerMiddleware>();
        }
    }
}
