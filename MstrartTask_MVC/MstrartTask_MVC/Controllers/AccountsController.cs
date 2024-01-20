using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MstrartTask_MVC.Data;
using MstrartTask_MVC.Models;

namespace MstrartTask_MVC.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = _context.Accounts.Include(a => a.User);
            return View(await accounts.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string SelectOption, string SearchText)
        {
            try
            {
                List<Account> accounts;
                switch (SelectOption)
                {
                    case "UserId":
                        accounts = await _context.Accounts.Include(a => a.User).Where(a => a.UserID.ToString() == SearchText).ToListAsync();
                        break;
                    case "AccountID":
                        accounts = await _context.Accounts.Include(a => a.User).Where(a => a.ID.ToString() == SearchText).ToListAsync();
                        break;
                    case "AccountNumber":
                        accounts = await _context.Accounts.Include(a => a.User).Where(a => a.Account_Number == SearchText).ToListAsync();
                        break;
                    default:
                        accounts = await _context.Accounts.Include(a => a.User).ToListAsync();
                        break;
                }
                return View(accounts);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public void CreateCurrencySelectList(string selected = "$")
        {
           
                List<Currency> currencies = new List<Currency>
            {

                new Currency{semboly="$",Name="dollar"},
                new Currency{semboly="JD",Name="Jordan Dinar"},
                new Currency{semboly="AED",Name="Emirati Dirham"},
                new Currency{semboly="EUR",Name="Euro"}

            };
                SelectList Status = new SelectList(currencies, "semboly", "Name", selected);
                ViewBag.currencies = Status;
            
           

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
            CreateCurrencySelectList();
            CreateStatuSelectList();
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Username");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            try
            {
                CreateCurrencySelectList(account.Currency);
                CreateStatuSelectList(account.Status);
                account.Server_DateTime = DateTime.Now;
                account.Update_DateTime_UTC = DateTime.UtcNow;
                account.DateTime_UTC = DateTime.UtcNow;
                ViewData["UserID"] = new SelectList(_context.Users, "ID", "Username", account.UserID);
                if (ModelState.IsValid)
                {
                    var FoundAccountNumber = _context.Accounts.FirstOrDefault(x => x.Account_Number == account.Account_Number);
                    if (FoundAccountNumber != null)
                    {
                        ViewBag.Found = "The Account Number is Already Exist";
                        return View(account);
                    }

                    _context.Add(account);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(account);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            CreateStatuSelectList();
            CreateCurrencySelectList();
            var account = await _context.Accounts.FindAsync(id); 
            if (id == null  || account == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Username", account.UserID);
            return View(account);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Account account,string Save)
        {
            try
            {
                var oldinfo = await _context.Accounts.FindAsync(id);
                ViewData["UserID"] = new SelectList(_context.Users, "ID", "Username", account.UserID);
                CreateStatuSelectList(oldinfo.Status);
                CreateCurrencySelectList(oldinfo.Currency);
                var FoundAccountNumber = _context.Accounts.FirstOrDefault(x => x.Account_Number == account.Account_Number && x.Account_Number != oldinfo.Account_Number);
                if (FoundAccountNumber != null)
                {
                    ViewBag.Found = "The Account Number is Already Exist";
                    return View(account);
                }

                if (id != account.ID || oldinfo == null || !AccountExists(account.ID))
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    account.Server_DateTime = oldinfo.Server_DateTime;
                    account.DateTime_UTC = oldinfo.DateTime_UTC;
                    account.Update_DateTime_UTC = DateTime.UtcNow;
                    _context.Entry(oldinfo).CurrentValues.SetValues(account);
                    _context.SaveChanges();
                    switch (Save)
                    {
                        case "save":
                            return RedirectToAction(nameof(Index));
                        case "saveandcontinue":
                            ViewBag.Updte = "The Information is been Updated Successfully";

                            return View(account);
                        default:
                            return RedirectToAction(nameof(Index));
                    }
                }
                return View(account);
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var account = await _context.Accounts
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ID == id);
                if (id == null || _context.Accounts == null || account == null)
                {
                    return NotFound();
                }
                else
                {
                    account.Status = 3;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }


        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
