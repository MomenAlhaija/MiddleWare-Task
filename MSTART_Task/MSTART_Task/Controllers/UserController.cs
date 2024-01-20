using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSTART_Task.Data;
using MSTART_Task.DTO;
using MSTART_Task.Models;
using System.Reflection.Metadata;

namespace MSTART_Task.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserController(AppDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            var users= _context.Users;
            return View(users.ToList());
        }
        [HttpGet]
        public IActionResult Create() { 

            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(UserDTO user) {
          
             
               var newUser = _mapper.Map<User>(user);
                newUser.DateTime_UTC = DateTime.UtcNow;
                newUser.Update_DateTime_UTC = DateTime.UtcNow;
                newUser.Server_DateTime= DateTime.Now;
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }


    }
}
