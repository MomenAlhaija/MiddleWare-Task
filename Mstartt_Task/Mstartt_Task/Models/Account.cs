using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Mstartt_Task.Models
{
    public class Account
    {
        public int ID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int UserID { get; set; }
        public DateTime? Server_DateTime { get; set; }
        public DateTime? DateTime_UTC { get; set; }
        public DateTime? Update_DateTime_UTC { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Account number must be 7 digits.")]

        public string? Account_Number { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public decimal Balance { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string? Currency { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Status { get; set; }
        public User User { get; set; }
    }
}
