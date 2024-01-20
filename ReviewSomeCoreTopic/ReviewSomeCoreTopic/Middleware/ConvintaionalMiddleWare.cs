using Microsoft.OpenApi.Writers;
using System.Runtime.InteropServices.ObjectiveC;

namespace ReviewSomeCoreTopic.Middleware
{
    public class ConvintaionalMiddleWare
    {
        private readonly RequestDelegate _next;
        public ConvintaionalMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) {

            await context.Response.WriteAsync("Start My Convintioal Middleware\n");
            await _next(context);
            await context.Response.WriteAsync("End My Convintioal Middleware\n");

        }
    }
}
