using Microsoft.EntityFrameworkCore;
using ReviewTheCore.Data;
using ReviewTheCore.Exeption;
using ReviewTheCore.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomeMiddleWare>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();
//app.UseExceptionHandler("/Error");
app.UseExceptionHandlingMiddleware();
app.UseStaticFiles();   
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
    endpoints.Map("Employee/{Num:int}", async context =>
    {
        int EmployeeId =int.Parse(context.Request.RouteValues["Num"].ToString());
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