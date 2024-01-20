using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReviewAPI.Data;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("Defualt"))
    );
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
#region sec
//builder.Services.AddSwaggerGen(
//    option =>
//    {
//        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//        {
//            Name = "Authorization",
//            Type = SecuritySchemeType.ApiKey,
//            Scheme = "Bearer",
//            BearerFormat = "JWT",
//            In = ParameterLocation.Header,
//            Description = "Enter your JWT Key"

//        });
//        option.AddSecurityRequirement(new OpenApiSecurityRequirement
//        {
//            {
//                new OpenApiSecurityScheme
//                {
//                    Reference=new OpenApiReference
//                    {
//                        Type=ReferenceType.SecurityScheme,
//                        Id="Bearer"
//                    },
//                    Name="Bearer",
//                   In = ParameterLocation.Header,

//                },
//                new List<string>()
//            }
//        });

//    });
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());  
app.UseAuthorization();

app.MapControllers();

app.Run();
