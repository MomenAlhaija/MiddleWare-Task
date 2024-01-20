using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer
{
    public class MainRepositry<T> : IRepositry<T> where T : class
    {
        private readonly AppDbContext _context;
        public MainRepositry(AppDbContext context)
        {
            _context = context;
        }
        public void AddItem(T item)
        {
          _context.Set<T>().Add(item);  
          _context.SaveChanges();
        }

        public async void EditItemAsync(T item, int Id)
        {
            var Item = await _context.Set<T>().FindAsync(Id);
            _context.Set<T>().Update(item);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
           
        }

        public async void RemoveItemAsync(T item, int Id)
        {
            var Item = await _context.Set<T>().FindAsync(Id);
            _context.Remove(Item);
            _context.SaveChanges();
        }

        public async Task<bool> IsFound(int Id)
        {
            var item =await _context.Set<T>().FindAsync(Id);
            return item!=null? true:false;
        }
    }
}
