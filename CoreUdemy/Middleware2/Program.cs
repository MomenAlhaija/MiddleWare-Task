

using CoreUdemy.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomeMiddleware>();
builder.Services.AddTransient<Middleware>();
var app = builder.Build();

app.Use(async(HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next(context);
});
app.UseMiddleware();
app.UseMyCustomeMiddleware();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 3\n");
});
app.Run();
