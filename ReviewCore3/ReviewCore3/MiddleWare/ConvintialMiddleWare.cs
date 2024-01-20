using System.Runtime.CompilerServices;

namespace ReviewCore3.MiddleWare
{
    public class ConvintialMiddleWare
    {
        private readonly RequestDelegate _requestDelegate;

        public ConvintialMiddleWare(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task  Invoke(HttpContext context) {
            await context.Response.WriteAsync("Start My Convintial MiddleWare\n");
            await _requestDelegate(context);
            await context.Response.WriteAsync("End My Convintial MiddleWare\n");
        }
    }
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder? UseConvintalMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConvintialMiddleWare>();   
        }
    }
}
