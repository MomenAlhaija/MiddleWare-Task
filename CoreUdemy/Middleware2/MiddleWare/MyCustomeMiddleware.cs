namespace CoreUdemy.MiddleWare
{
    public class MyCustomeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("my custom Middleware started\n");
            await next(context);
            await context.Response.WriteAsync("my custom Middleware End\n");

        }
    }
}
