using APIMovies2.Model;

namespace APIMovies2.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> AllMovies(int Genraid = 0);
        Task<Movie> GetMovieById(int id);

        
        Task<Movie>  Add(Movie movie);

        Task<Movie> Edit(Movie movie);

        Task<Movie> Delete(Movie movie);

    }
}
