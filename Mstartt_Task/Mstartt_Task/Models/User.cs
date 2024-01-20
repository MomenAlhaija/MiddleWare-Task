using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mstartt_Task.Models
{
    public class User
    {
        public int ID { get; set; }
        public DateTime? Server_DateTime { get; set; }
        public DateTime? DateTime_UTC { get; set; }
        public DateTime? Update_DateTime_UTC { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only English letters and numbers are allowed.")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public DateTime? Date_Of_Birth { get; set; }
    }
}
