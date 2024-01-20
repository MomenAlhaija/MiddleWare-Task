using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mstartt_Task.Data;
using Mstartt_Task.DTO;
using Mstartt_Task.Models;
using System.Security.Cryptography.Xml;

namespace Mstartt_Task.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public void CreateSelectList(int selectid=0)
        {
           List<Gender> genders = new List<Gender>
           {

                new Gender{Id=1,Name="Male"},
                new Gender{Id=2,Name="Female"}
           };
           SelectList Genders = new SelectList(genders,"Id","Name",selectid);
           ViewBag.GenderList= Genders;
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
        public IActionResult Index()
        {
                var users = _context.Users;
            return View(users.ToList());
        }
        [HttpPost]
        public IActionResult Index(string SearchText,string SelectOption)
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
                default :
                    users=_context.Users.ToList();
                    break;
            }
            return View(users);

        }


       

        public IActionResult Create() {
            CreateStatuSelectList();
            CreateSelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user) {
            try
            {
                CreateStatuSelectList();
                CreateSelectList();
                var FoundEmail = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                var FoundUserName = _context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (ModelState.IsValid)
                {
                    if (FoundEmail != null)
                    {
                        ViewBag.Found = "mail address already exists.";

                        return View();
                    }
                    else if (FoundUserName != null)
                    {

                        ViewBag.Found = "User Name already exists.";
                        return View();

                    }
                    user.Server_DateTime = DateTime.Now;
                    user.DateTime_UTC = DateTime.UtcNow;
                    user.Update_DateTime_UTC = DateTime.UtcNow;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

    
        public IActionResult Edit(int id)
        {

            CreateStatuSelectList();
            CreateSelectList();
            var user = _context.Users.Find(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return NotFound("Not found the User");
            }
        }


        [HttpPost]
        public IActionResult Edit(User NewInfo,int Id,string saveButton)
        {
            try
            {
                CreateStatuSelectList();
                CreateSelectList();
                var user = _context.Users.Where(u => u.ID == NewInfo.ID).FirstOrDefault();
                var FoundEmail = _context.Users.FirstOrDefault(u => u.Email == NewInfo.Email && u.Email != user.Email);
                var FoundUserName = _context.Users.FirstOrDefault(u => u.Username == NewInfo.Username && u.Username != user.Username);
                if (FoundEmail != null)
                {
                    ViewBag.Found = "mail address already exists.";

                    return View();
                }
                else if (FoundUserName != null)
                {

                    ViewBag.Found = "User Name already exists.";

                    return View();

                }

                if (ModelState.IsValid && user != null)
                {
                    user.First_Name = NewInfo.First_Name;
                    user.Last_Name = NewInfo.Last_Name;
                    user.Status = NewInfo.Status;
                    user.Username = NewInfo.Username;
                    user.Email = NewInfo.Email;
                    user.Gender = NewInfo.Gender;
                    user.Date_Of_Birth = NewInfo.Date_Of_Birth;
                    user.Update_DateTime_UTC = DateTime.UtcNow;
                    _context.Users.Update(user);
                    _context.SaveChanges();

                    if (saveButton == "Save")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        ViewBag.EditSuccess = "The Informations are been updated Successfully";
                        return View(NewInfo);
                    }

                }
                else
                {
                    return View(NewInfo);
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }






        }
        public IActionResult Delete(int? id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(u => u.ID == id);
                if (user == null)
                {
                    return NotFound("Not found the user");
                }
                else
                {
                    user.Status = 3;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
       
     

        
    

    }
}
