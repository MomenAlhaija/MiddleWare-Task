using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MoviesApi.Models;
using System.Security.Cryptography.Xml;

var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("Defualt");
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(connectionstring));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(Options =>
{ 
    Options.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "v1",
        Title = "TestAPI",   
        Description="MufirstAPI",
        TermsOfService=new Uri("https://www.google.com"),
        Contact=new OpenApiContact { 
        
            Name ="Momen",
            Email="haijamomen4@gmail.com",
            Url=new Uri("https://www.google.com")
        },
        License=new OpenApiLicense
        {
            Name = "License",
            Url=new Uri("https://www.google.com")
        }
    });
    Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme= "Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description="Enter Your JWT Key"


    });
    Options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                },
                Name="Bearer",
                In=ParameterLocation.Header
            },
            new List<string>() 
        }
    });

});

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
