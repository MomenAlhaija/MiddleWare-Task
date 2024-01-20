namespace ReviewCore3.MiddleWare
{
    public class CustomeMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Start My Custome MiddleWare\n");
            await next(context);
            await context.Response.WriteAsync("End My Custome MiddleWare\n");
        }
    }
    public static class UseMyCustomeMiddleWare
    {
        public static IApplicationBuilder UseMyMidlleWare(this IApplicationBuilder builder) {
            
            return builder.UseMiddleware<CustomeMiddleWare>();
        }
    }
}
