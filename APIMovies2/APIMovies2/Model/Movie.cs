namespace APIMovies2.Model
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int? Year { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StateLine { get; set; }

        public byte[] Poster { get; set; }

        public int GenreId { get; set; }

        public Genre? Genres { get; set; }
    }
}
