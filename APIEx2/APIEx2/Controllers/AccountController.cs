using APIEx2.DTO;
using APIEx2.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIEx2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager; 
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        [HttpPost]
        public async Task<IActionResult> PostRegister(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) {
                string ErrorMassage = string.Join(" | ",
                    ModelState.Values.SelectMany(E => E.Errors).Select(e => e.ErrorMessage));
                return Problem(ErrorMassage);  
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                UserName = registerDTO.Email,
                PersonName = registerDTO.PersonName
            };
             IdentityResult result= await _userManager.CreateAsync(user,registerDTO.PassWord);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(user);
            }
            else
            {
                string ErrorMassage = string.Join(" | ",
                               result.Errors.Select(e => e.Description));
                return Problem(ErrorMassage);
            }

        }
        public async Task<IActionResult> IsAlreadyRegistered(string email)
        {
          await  _userManager.FindByEmailAsync(email);
           return User==null? Ok(true): Ok(false);

        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> PostLogin(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                string ErrorMassage = string.Join(" | ",
                ModelState.Values.SelectMany(E => E.Errors).Select(e => e.ErrorMessage));
                return Problem(ErrorMassage);
            }
        var result=  await _signInManager.PasswordSignInAsync(loginDto.Email,loginDto.Password,isPersistent:false,lockoutOnFailure:false);
           
            if (result.Succeeded)
            {
                ApplicationUser user =await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null) return NoContent();
                else
                {
                    return Ok(new
                    {
                        PersonName= user.PersonName,
                        Email=user.Email 
                    });
                }
            }
            else
            {
               
                return Problem("Invalied Email or Password");
            }
        }

        [HttpPost("Logout")]
        public async Task<ActionResult<ApplicationUser>> Logout(LoginDto loginDto)
        {
            await _signInManager.SignOutAsync();
            return NoContent(); 
        }
       
    }
}
