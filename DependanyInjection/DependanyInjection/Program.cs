using ServiceContract;
using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICitiesService, CitiesService>();
var app = builder.Build();
if (app.Environment.IsStaging()||app.Environment.IsDevelopment()||
    app.Environment.IsEnvironment("Beta"))
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
