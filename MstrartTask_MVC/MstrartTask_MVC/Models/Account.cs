using System.ComponentModel.DataAnnotations;

namespace MstrartTask_MVC.Models
{
    public class Account
    {
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        public DateTime? Server_DateTime { get; set; }
        public DateTime? DateTime_UTC { get; set; }
        public DateTime? Update_DateTime_UTC { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Account number must be 7 digits.")]

        public string? Account_Number { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public string? Currency { get; set; }
        [Required]
        public int Status { get; set; }
        public User? User { get; set; }
    }
}
