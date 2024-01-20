namespace MoviesApi.DTO
{
    public class CreateGenresDtocs
    {
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
