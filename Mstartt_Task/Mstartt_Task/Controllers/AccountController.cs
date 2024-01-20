using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mstartt_Task.Data;
using Mstartt_Task.Models;

namespace Mstartt_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var accounts=_context.Accounts.Include(u=>u.User).ToList();
            return View(accounts.ToList());
        }
        [HttpPost]
        public IActionResult Index(string SearchText,string SelectOption) {

            List<Account> accounts;
            switch (SelectOption)
            {
                case "AccountNumber":
                    accounts = _context.Accounts.Where(a=>a.Account_Number.ToString().Contains(SearchText)).Include(a=>a.User).ToList();
                    break;
                case "AccountID":
                    accounts = _context.Accounts.Where(a => a.Account_Number.ToString().Contains(SearchText)).Include(a => a.User).ToList();
                    break;
                case "UserId":
                    accounts = _context.Accounts.Where(a => a.UserID.ToString().Contains(SearchText)).Include(a => a.User).ToList();
                    break;
                default:
                    accounts = _context.Accounts.Include(a => a.User).ToList();
                    break;

            }

            return View(accounts);

        }
        public void CreateCurrencySelectList(int selectid = 0)
        {
            List<Currency> currencies = new List<Currency>
           {

                new Currency{Id=1,Name="$"},
                new Currency{Id=2,Name="JD"},
                new Currency{Id=3,Name="AED"},
                new Currency{Id=4,Name="EUR"}

           };
            SelectList Status = new SelectList(currencies, "Id", "Name", selectid);
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

        public ActionResult Create() {
            CreateStatuSelectList();
            CreateCurrencySelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            CreateStatuSelectList();
            CreateCurrencySelectList();
            if (ModelState.IsValid)
            {
                account.DateTime_UTC = DateTime.UtcNow;
                account.Server_DateTime = DateTime.Now;
                account.Update_DateTime_UTC = DateTime.UtcNow;
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Edit(int Id) {
            CreateStatuSelectList();
            CreateCurrencySelectList();
            var account = _context.Accounts.FirstOrDefault(a=>a.ID==Id);
            return View(account);
        }
        [HttpPost]
        public IActionResult Edit(Account NewInfo)
        {
            CreateStatuSelectList();
            CreateCurrencySelectList();
          
                var account = _context.Accounts.Where(a => a.ID == NewInfo.ID).FirstOrDefault();
                account.UserID = NewInfo.UserID;
                account.Account_Number = NewInfo.Account_Number;
                account.Balance = NewInfo.Balance;
                account.Currency = NewInfo.Currency;
                account.Status = NewInfo.Status;
                account.Update_DateTime_UTC = DateTime.UtcNow;
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
          
           
        }
        public IActionResult Delete(int id)
        {
            var account= _context.Accounts.FirstOrDefault(x=>x.ID==id);
            account.Status = 3;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}
