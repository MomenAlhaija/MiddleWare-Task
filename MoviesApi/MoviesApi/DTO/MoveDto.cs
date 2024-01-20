using MoviesApi.Models;

namespace MoviesApi.DTO
{
    public class MoveDto
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }

        public int Year { get; set; }
        public Double Rate { get; set; }

        [MaxLength(2500)]
        public string StoreLine { get; set; }


        public IFormFile Poster { get; set; }


        public int GenreId { get; set; }
    }
}
