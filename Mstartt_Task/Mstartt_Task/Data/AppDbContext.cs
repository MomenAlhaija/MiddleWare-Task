using Microsoft.EntityFrameworkCore;
using Mstartt_Task.Models;

namespace Mstartt_Task.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions option) : base(option) 
        {
         
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }    

    }
}
