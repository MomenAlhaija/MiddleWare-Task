using Microsoft.AspNetCore.Identity;

namespace APIMovies2.Model
{
    public class ApplicationUser:IdentityUser
    {
        [MaxLength(50)]
        public string firstName { get; set; }

        [MaxLength(50)]
        public string lastName { get; set; }
    }
}
