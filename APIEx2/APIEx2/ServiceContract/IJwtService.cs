using APIEx2.DTO;
using APIEx2.Identity;

namespace APIEx2.ServiceContract
{
    public interface IJwtService
    {
        AuthonticationResponse CreteToken(ApplicationUser user); 
    }
}
