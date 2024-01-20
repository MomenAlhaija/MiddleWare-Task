using APIMovies2.Data;
using APIMovies2.Model;
using Microsoft.EntityFrameworkCore;

namespace APIMovies2.Services
{
    public class Generaservice : IGenersService
    {
        private readonly AppDbContext _context; 
        public Generaservice(AppDbContext conrtext)
        {
          _context = conrtext;  
        }
        public async Task<IEnumerable<Genre>> AllGener()
        { 
                var Geners = await _context.Genres.OrderBy(p => p.Name).ToListAsync();
                return Geners;
        }

       public async Task<Genre>  delete(Genre dto)
        {
          _context.Genres.Remove(dto);
            _context.SaveChanges(); 
            return dto;
        }

        public async Task<Genre> Edit(Genre dto)
        {
            _context.Genres.Update(dto);
            _context.SaveChanges(); 
            return dto;
        }
       public async Task<Genre>  SingleGenre(int id)
        {
            var g= await _context.Genres.SingleOrDefaultAsync(p => p.Id == id);
            return g; 
        }
        public async Task<Genre> newGeners(Genre dto)
        {
            await _context.Genres.AddAsync(dto);
            _context.SaveChanges();
            return dto;
        }

        public Task<bool> isValiedGenre(int id)
        {
            return _context.Genres.AnyAsync(p => p.Id == id);

        }
    }
}
