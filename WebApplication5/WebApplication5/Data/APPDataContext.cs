using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class APPDataContext:DbContext
    {
        public APPDataContext(DbContextOptions<APPDataContext> Option):base(Option)
        {
            
        }
        public DbSet<Item> Items { get; set; }  
    }
}
