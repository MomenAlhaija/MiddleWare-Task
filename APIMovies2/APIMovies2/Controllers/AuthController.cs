using APIMovies2.Model;
using APIMovies2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIMovies2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result=await _authService.RegisterAsync(model); 
            if(!result.IsAuthenticated)
               return BadRequest(result.Message);
            //return Ok(result);
            return Ok(new {Token=result.Token,expireon=result.ExpireOn});
        }
        [HttpPost("Token")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenReguestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.getTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);

        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.AddRoleAsync(model);
            if (! string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(model);
        }

    }
}
