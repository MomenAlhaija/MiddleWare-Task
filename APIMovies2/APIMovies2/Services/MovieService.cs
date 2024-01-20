using APIMovies2.Data;
using APIMovies2.Model;
using Microsoft.EntityFrameworkCore;

namespace APIMovies2.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Movie> Add(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task<IEnumerable<Movie>> AllMovies(int Genraid = 0)
        {
            
            var Movies = await _context.Movies.Include(p => p.Genres).OrderBy(m => m.Name).ToListAsync();
            if(Genraid!=0)
            {
                 Movies = await _context.Movies.Include(p => p.Genres).OrderBy(m => m.Name).Where(m=>m.GenreId== Genraid).ToListAsync();

            }
            return Movies;
        }

        public async Task<Movie> Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return movie;
            
        }

        public async Task<Movie> Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task<Movie> GetMovieById(int id)
        {
           var movie= await _context.Movies.Include(p => p.Genres).FirstOrDefaultAsync(p => p.Id == id);
            return movie!;

        }
    }
}
