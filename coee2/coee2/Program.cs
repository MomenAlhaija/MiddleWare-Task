using coee2.Controllers;

var builder = WebApplication.CreateBuilder(args) ;
builder.Services.AddControllers() ;
builder.Services.AddMvc() ;
builder.Services.AddControllers().AddXmlSerializerFormatters() ;
var app = builder.Build();
app.UseStaticFiles() ;
app.UseRouting() ;
app.MapControllers();
app.Run();