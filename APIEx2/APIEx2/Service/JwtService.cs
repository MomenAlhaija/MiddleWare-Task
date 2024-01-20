using APIEx2.DTO;
using APIEx2.Identity;
using APIEx2.ServiceContract;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIEx2.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthonticationResponse CreteToken(ApplicationUser user)
        {
          DateTime ExxpireDate=  DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:Expiration_Minutes"]));

            Claim[] claims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Email),
            new Claim(ClaimTypes.Name,user.PersonName)
        };
            SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                );
            SigningCredentials signingCredentials=new  SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(_configuration.);
    }
    }
}
