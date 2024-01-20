using Microsoft.EntityFrameworkCore;
using APIEx2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using APIEx2.Identity;


namespace APIEx2.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,Guid>   
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {
            
        }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(
            new City
            {
                CityId = Guid.NewGuid(),
                CityName = "Irbid"
            },
            new City
            {
                CityId = Guid.NewGuid(),
                CityName = "Amman"
            }
            );
        }
    }
}
