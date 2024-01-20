using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Data;
using TestCoreApp.Models;
using TestCoreApp.Repositry.Base;

namespace TestCoreApp.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeesController : Controller
    {
        private readonly IRepositry<Employee> _mainReposity;
        public EmployeesController( IRepositry<Employee> mainReposity)
        {
          
            _mainReposity = mainReposity;
        }

        // GET: Employees/Employees
        public async Task<IActionResult> Index()
        {
            return View(await _mainReposity.GetAllAsync());

        }

        // GET: Employees/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _mainReposity.FindByIdAsync(id) == null)
            {
                return NotFound();
            }

            var employee = await _mainReposity.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,EmployeePhone,EmployeeEmail,EmployeeAge,EmployeeSalary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _mainReposity.AddAsync(employee); 
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || await _mainReposity.FindByIdAsync(id) == null)
            {
                return NotFound();
            }

            var employee = await _mainReposity.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeePhone,EmployeeEmail,EmployeeAge,EmployeeSalary")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _mainReposity.UpdateOne(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _mainReposity.FindByIdAsync(id)== null)
            {
                return NotFound();
            }

            var employee = await _mainReposity.FindByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _mainReposity.FindByIdAsync(id) == null)
            {
                return Problem("Entity set 'AppDbContext.Employees'  is null.");
            }
            var employee = await _mainReposity.FindByIdAsync(id); ;
            if (employee != null)
            {
                _mainReposity.Delete(employee);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EmployeeExists(int id)
        {
          return await _mainReposity.FindByIdAsync(id)!=null?true:false;
        }
    }
}
