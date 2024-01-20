using Microsoft.EntityFrameworkCore;
using ReviewCore3.Data;
using ReviewCore3.Exeption;
using ReviewCore3.MiddleWare;
using ReviewCore3.Data;
using ReviewCore3.Exeption;
using ReviewCore3.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<CustomeMiddleWare>();
builder.Services.AddControllersWithViews();


var app = builder.Build();
//app.UseExceptionHandler("/Error");
app.UseExceptionHandlingMiddleware();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
    endpoints.Map("Employee/{Num:int}", async context =>
    {
        int EmployeeId = int.Parse(context.Request.RouteValues["Num"].ToString());
        await context.Response.WriteAsync($"The Employee Id:{EmployeeId}");
    }
));
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello\n");
    await next(context);
});
app.UseMyMidlleWare();
app.UseConvintalMiddleWare();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Goodbye\n");
});
app.Run();