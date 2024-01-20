namespace ReviewSomeCoreTopic.Middleware
{
    public class MyCustomeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Start My Custome MiddleWare\n");
            await next(context);
            await context.Response.WriteAsync("End My Custome MiddleWare\n");
        }
    }
}
