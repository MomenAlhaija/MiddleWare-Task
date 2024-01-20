using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Use(async (HttpContext context,RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context);
});
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello again");
    await next(context);
});
app.Run(async (HttpContext context) => {
   await context.Response.WriteAsync("Hello again");

});
app.Run();

