using APIMovies2.Helpers;
using APIMovies2.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIMovies2.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;

        }
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel
                {
                    Message = "Email is already reigster"

                };
            }
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                return new AuthModel
                {
                    Message = "User Name is already reigster"

                };
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                firstName = model.FirstName,
                lastName = model.LastName,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) {

                var Errors = string.Empty;
                foreach (var Error in result.Errors)
                {
                    Errors += $"{Error.Description} ,";
                }
                return new AuthModel
                {
                    Message = Errors

                };
            }
            await _userManager.AddToRoleAsync(user, "User");
            var jwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                Email = user.Email,
                ExpireOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName,
            };
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issure,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DuraationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        public async Task<AuthModel> getTokenAsync(TokenReguestModel model)
        {
            var AuthModel=new AuthModel();
            var user=await _userManager.FindByEmailAsync(model.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                AuthModel.Message = "Email or password is Not Correct";
                return AuthModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var RoleList = await _userManager.GetRolesAsync(user);


            AuthModel.IsAuthenticated = true;
            AuthModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            AuthModel.Email = user.Email;
            AuthModel.UserName = user.UserName;
            AuthModel.ExpireOn = jwtSecurityToken.ValidTo;
            AuthModel.Roles=RoleList.ToList();



            return AuthModel;
        }
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
                return $"User Name or Role invalid";
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
                return $"User Name or Role invalid";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "User already assigned to this Role";

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? string.Empty : "Something went wrong";


        }

    }
}

