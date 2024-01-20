using APIMovies2.Model;

namespace APIMovies2.DTO
{
    public class MoviesDTO
    {

        [MaxLength(100)]
        public string Name { get; set; }

        public int? Year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StateLine { get; set; }

        public IFormFile Poster { get; set; }


        public int GenreId { get; set; }
    }
}
