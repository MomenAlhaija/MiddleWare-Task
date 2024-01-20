using Intalio_Task.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intalio_Task.Data;
using Microsoft.EntityFrameworkCore;
using Intalio_Task.Model;

namespace Intalio_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private  readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users=await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int? id)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Users(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,User Edituser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id==id);
            if(user == null)
            {
                return NotFound();
            }
            user.Name = Edituser.Name;
            user.Email = Edituser.Email;
            user.Password = Edituser.Password;
            user.Age = Edituser.Age;
            user.Address = Edituser.Address;
            user.Confirm_password = Edituser.Confirm_password;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        { 
            var user=await _context.Users.FirstOrDefaultAsync(u=>u.Id==id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}
