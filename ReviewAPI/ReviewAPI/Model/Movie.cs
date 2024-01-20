using System.ComponentModel.DataAnnotations;

namespace ReviewAPI.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Storline { get; set; }

        public byte[] Poster { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

    }
}
