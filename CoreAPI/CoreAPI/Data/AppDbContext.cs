using CoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public virtual DbSet<TodoItems> TodoItems { get; set; }
    }
}
