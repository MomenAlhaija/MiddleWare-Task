using Download_API.Exeption;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DbComtext;
using WebApplication6.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<PublisherService>();
builder.Services.AddTransient<AuthorService>();
builder.Services.AddTransient<BookService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Defualt");
builder.Services.AddDbContext<AppdbContect>(options => options.UseSqlServer(connectionString)); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.ConfigureBuilderInException();
app.MapControllers();

app.Run();
