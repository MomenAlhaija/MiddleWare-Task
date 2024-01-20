using Intalio_Task.Model;
using Microsoft.EntityFrameworkCore;

namespace Intalio_Task.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
       public DbSet<User> Users { get; set; }


    }
}
