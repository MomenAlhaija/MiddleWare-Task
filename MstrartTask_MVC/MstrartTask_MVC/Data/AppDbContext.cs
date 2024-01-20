using Microsoft.EntityFrameworkCore;
using MstrartTask_MVC.Models;

namespace MstrartTask_MVC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {

            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
