using DAL.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositries
{
    public class MainRepositry<T> : IRepositry<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public MainRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
