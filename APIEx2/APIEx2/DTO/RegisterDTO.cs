using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace APIEx2.DTO
{
    public class RegisterDTO
    {

        [Required(ErrorMessage ="Person Name is Required")]
        public string? PersonName { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="The Email should be in a proper Email format")]
        [Remote(action: "Email is Already Registered", controller: "Account", ErrorMessage = "Email is Already USe")]

        public string? Email { get; set; }


        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "The  Phone Number should be in a proper Phone format")]
        [Remote(action: "The Phone Number is Already Registered", controller: "Account", ErrorMessage = "Phone Number is Already Use")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "PassWord is Required")]
        public string? PassWord { get; set; }

        [Required(ErrorMessage = "Confirm PassWord is Required")]
        [Compare("PassWord",ErrorMessage ="The Password Doesn't Match")]
        public string? ConfirmPassword { get; set; }

    }
}
