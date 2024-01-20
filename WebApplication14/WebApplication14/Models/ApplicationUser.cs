using Microsoft.AspNetCore.Identity;

namespace WebApplication14.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
