using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MstrartTask_MVC.Data;
using MstrartTask_MVC.Models;

namespace MstrartTask_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users=_context.Users;
            if(users == null)
                return NotFound("Not Found Any User");
            else
                return View(users);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(string SearchText, string SelectOption)
        {
            try
            {
                List<User> users;
                switch (SelectOption)
                {
                    case "Email":
                        users = _context.Users.Where(u => u.Email.Contains(SearchText)).ToList();
                        break;
                    case "UserName":
                        users = _context.Users.Where(u => u.Username.Contains(SearchText)).ToList();
                        break;
                    case "ID":
                        users = _context.Users.Where(u => u.ID.ToString().Contains(SearchText)).ToList();
                        break;
                    default:
                        users = _context.Users.ToList();
                        break;
                }
                return View(users);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }

        }
        public void CreateSelectList(int selectid = 0)
        {
            List<Gender> genders = new List<Gender>
           {

                new Gender{Id=1,Name="Male"},
                new Gender{Id=2,Name="Female"}
           };
            SelectList Genders = new SelectList(genders, "Id", "Name", selectid);
            ViewBag.GenderList = Genders;
        }
        public void CreateStatuSelectList(int selectid = 0)
        {
            List<Status> status = new List<Status>
           {

                new Status{Id=1,Name="Accept"},
                new Status{Id=2,Name="pending"},
                new Status{Id=3,Name="Delete"}
           };
            SelectList Status = new SelectList(status, "Id", "Name", selectid);
            ViewBag.Status = Status;
        }
        public IActionResult Create()
        {
            CreateStatuSelectList();
            CreateSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                CreateStatuSelectList(user.Status);
                CreateSelectList(user.Gender);
                if (ModelState.IsValid)
                {
                    var FoundEmail = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                    var FoundUerName = _context.Users.FirstOrDefault(u => u.Username == user.Username);
                    if (FoundEmail != null)
                    {
                        ViewBag.Found = "The Email is already Exist";
                        return View(user);
                    }
                    if (FoundUerName != null)
                    {
                        ViewBag.Found = "The UserName is already Exist";
                        return View(user);

                    }
                    user.Server_DateTime = DateTime.Now;
                    user.DateTime_UTC = DateTime.UtcNow;
                    user.Update_DateTime_UTC = DateTime.UtcNow;
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            CreateStatuSelectList();
            CreateSelectList();
            var user = await _context.Users.FindAsync(id);
            if (id == null || _context.Users == null|| user==null)
            {
                return NotFound();
            }
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user,string saveButton)
        {
            try
            {
                var oldInfo = await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
                CreateStatuSelectList(oldInfo.Status);
                CreateSelectList(oldInfo.Gender);

                if (id != user.ID || oldInfo == null)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var FoundEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Email != user.Email);
                    var FoundUserName = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Username != user.Username);

                    if (FoundEmail != null)
                    {
                        ViewBag.Found = "The Email is already Exist";
                        return View(user);
                    }

                    if (FoundUserName != null)
                    {
                        ViewBag.Found = "The UserName is already Exist";
                        return View(user);
                    }

                    user.Server_DateTime = oldInfo.Server_DateTime;
                    user.DateTime_UTC = oldInfo.DateTime_UTC;
                    user.Update_DateTime_UTC = DateTime.UtcNow;

                    _context.Entry(oldInfo).CurrentValues.SetValues(user);
                    await _context.SaveChangesAsync();
                    switch (saveButton)
                    {
                        case "Save":
                            return RedirectToAction("Index");
                        case "SaveandContinue":
                            ViewBag.EditSuccess = "The Informations are been updated Successfully";
                            return View(user);
                        default:
                            return RedirectToAction(nameof(Index));
                    }
                }

                return View(user);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(m => m.ID == id);
                if (id == null || _context.Users == null || user == null)
                {
                    return NotFound();
                }
                else
                {
                    user.Status = 3;
                    var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserID == user.ID);
                    if (account != null)
                    {
                        account.Status = 3;
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

       
        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
