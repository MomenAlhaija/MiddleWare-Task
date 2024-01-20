using System.ComponentModel.DataAnnotations;

namespace ReviewAPI.DTO
{
    public class GenreDTO
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
