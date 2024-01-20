using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApplication12.Models;

namespace WebApplication12.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
           
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Item> items { get; set; }  
    }
}
