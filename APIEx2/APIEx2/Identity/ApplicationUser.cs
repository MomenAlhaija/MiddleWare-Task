using Microsoft.AspNetCore.Identity;

namespace APIEx2.Identity
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
