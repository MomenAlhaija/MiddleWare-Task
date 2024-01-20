using Microsoft.EntityFrameworkCore;
using APIpref.Models;
namespace APIpref.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(new City
            {
                CityId = Guid.NewGuid(),
                CityName = "Irbid"
            });
        }
    }
}
