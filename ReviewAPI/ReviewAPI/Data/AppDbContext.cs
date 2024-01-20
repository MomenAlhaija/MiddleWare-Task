using Microsoft.EntityFrameworkCore;
using ReviewAPI.Model;

namespace ReviewAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }    
    }
}
