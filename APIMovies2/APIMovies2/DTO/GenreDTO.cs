namespace APIMovies2.DTO
{
    public class GenreDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
