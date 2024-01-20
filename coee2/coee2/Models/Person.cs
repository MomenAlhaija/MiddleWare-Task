using coee2.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace coee2.Models
{
    public class Person:IValidatableObject
    {
        [Required(ErrorMessage ="{0} can't be Empty or null")]
        [DisplayName("Person Name")]
        [StringLength(6,MinimumLength =2,ErrorMessage ="{0} Length must between 2-6 character Only")]
        //[RegularExpression("^[A-Za-z .]$",ErrorMessage ="{0} must contain only on letters")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage ="The Email invalied")]
        public string? Email { get; set; }
        [Phone(ErrorMessage ="The Phone Number is Not Correct")]
        public string? Phone { get; set; }
        public string? Password { get; set; }

        [BindNever]
        public int? PresentAge { get; set; }   
        [Required]
        [Compare("Password",ErrorMessage ="The Password Not Match")]
        public string? ConfirmPassword { get; set; }

        [Range(0.00000000002,99.99999,ErrorMessage ="The Price must greater 0 and less than 100")]
        public double? Price { get; set;}

        [MinYear(1900,2023)]
        public DateTime? DateOfBirth { get; set; }
        public override string ToString()
        {
            return $"Person-Object\n" + $"Person Name:{PersonName}\n" + $"Email:{Email}\n" + $"Password:{Password}\n" + $"Phone Number {Phone}\n" + $"Price:{Price}\n";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && PresentAge.HasValue == false)
            {
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied",
                     new[] { nameof(PresentAge) });
            }
            
        }
    }
}
