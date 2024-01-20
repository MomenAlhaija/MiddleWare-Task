using System.ComponentModel.DataAnnotations;

namespace Intalio_Task.Model
{
    public class User
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirm_password { get; set; }
        public string Address { get; set; }
        
        public string type { get; set; }

    }
}
