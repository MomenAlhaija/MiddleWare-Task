﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
