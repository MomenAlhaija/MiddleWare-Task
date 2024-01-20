using ReviewSomeCoreTopic.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReviewSomeCoreTopic.Models
{
    public class Person
    {
        [Required]
        [Key]
        public Guid PersonId { get; set; }

        [DisplayName("Person Name")]
        [Required(ErrorMessage ="The Person Name is Required")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="Name Length should between 2 and 10")]
        public string PersonName { get; set; }
        [DateOfBirthValidation(1900,2023)]
        public DateTime? DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage ="Invalied Email")]
        public string? Email { get; set; }

        [Phone(ErrorMessage ="Invalied Phone Number")]
        public string? Phone { get; set; }

        [Range(2f,100f,ErrorMessage ="the Price Sould between 2 and 100")]
        public float Price { get; set; }    
        [Required]
        public string password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="The Password doesn't match")]
        public string ConfirmPassword { get;set; }

    }
}
