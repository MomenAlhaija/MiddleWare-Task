using ReviewSomeCoreTopic.Middleware;
using ReviewSomeCoreTopic.Validation;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomeMiddleware>();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.UseExceptionHandler("/Error");
//app.UseExeptionHandlerMiddleware();
app.UseRouting();
app.MapControllers();   
app.UseEndpoints(endpoints =>
{
    endpoints.Map("Employee/{Num:int}", async context =>
    {
       int EmployeeNumber =int.Parse(context.Request.RouteValues["Number"].ToString());
       await context.Response.WriteAsync($"The file Name is {EmployeeNumber}");
    });
}
);
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello\n");
    await next(context);
});
app.useMyCustomeMiddleWare();
app.UseConvintalMiddleWare();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Goodbye\n");
});
app.Run();
