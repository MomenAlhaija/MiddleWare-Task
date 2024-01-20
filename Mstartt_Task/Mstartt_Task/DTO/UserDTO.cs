using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mstartt_Task.DTO
{
    public class UserDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only English letters and numbers are allowed.")]
        [Remote("IsUsernameUnique", "User", HttpMethod = "POST", ErrorMessage = "Username already exists.")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Remote("IsEmailUnique", "User", HttpMethod = "POST", ErrorMessage = "Email address already exists.")]
        public string? Email { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int Gender { get; set; }

        public DateTime? Date_Of_Birth { get; set; }
    }
}
