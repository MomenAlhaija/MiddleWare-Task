using Microsoft.EntityFrameworkCore;
using ReviewCore3.Model;
using System;

namespace ahmad.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ToDoItems> ToDoItems { get; set; } 
    
    }
}
