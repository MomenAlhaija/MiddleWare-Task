using System.ComponentModel.DataAnnotations;

namespace APIEx2.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage ="The Email is Required")]
        [EmailAddress(ErrorMessage ="The Email should be prepare the Email format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The Password is Required")]
        public string Password { get; set; }



    }
}
