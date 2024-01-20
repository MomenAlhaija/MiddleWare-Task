namespace MoviesAPI2.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
