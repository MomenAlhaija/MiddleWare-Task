using ReviewAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace ReviewAPI.DTO
{
    public class MovieDTO
    {

        [MaxLength(100)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Storline { get; set; }

        public IFormFile Poster { get; set; }

        public int GenreId { get; set; }

    }
}
