
namespace APIMovies2.Model
{
    public class Genre
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
