using APIMovies2.DTO;
using APIMovies2.Model;

namespace APIMovies2.Services
{
    public interface IGenersService
    {
        Task<IEnumerable<Genre>> AllGener();
        Task<Genre> newGeners(Genre dto);
        Task<Genre> SingleGenre(int id);
      
        Task<Genre> Edit(Genre dto);

        Task<Genre> delete(Genre dto);

        Task<bool> isValiedGenre(int id);
    }
}
