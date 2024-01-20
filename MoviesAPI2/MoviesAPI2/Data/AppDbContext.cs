
using Microsoft.EntityFrameworkCore;
using MoviesAPI2.Models;

namespace MoviesAPI2.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Genre> Genres { get; set; }    
    }
}
