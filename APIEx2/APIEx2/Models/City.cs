﻿using System.ComponentModel.DataAnnotations;
namespace APIEx2.Models
{
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
       
        public string? CityName { get; set; }


    }
}
