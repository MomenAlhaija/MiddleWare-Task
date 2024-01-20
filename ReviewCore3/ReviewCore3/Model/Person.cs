using ReviewTheCore.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReviewCore3.Model
{
    public class Person
    {
        [Required]
        [Key]
        public int? Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        [StringLength(9,ErrorMessage ="The Max Length for the First Name is 9")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        [StringLength(9, ErrorMessage = "The Max Length for the Last Name is 9")]
        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="The Email invalied Format")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Invalied Phone Number")]
        public string? Phone { get; set; }

        public string? Address { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="The Password doesnt Match")]
        public string? ConfirmPassword { get; set;}
        [Range(100,1000,ErrorMessage ="The Salary must between 100 and 1000")]
        public double? Salary { get; set; }
        [AgeValidate(18,60,ErrorMessage ="The Age Must between 18 and 60")]
        public int? Age { get;set; }


    }
}
