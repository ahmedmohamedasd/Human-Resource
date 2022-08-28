using HumanResource.Data;
using HumanResource.Models;
using HumanResource.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Policy = "EmployeeShow")]
        public IActionResult Index()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }
       
        [HttpGet]
        [Authorize(Policy = "EmployeeAdd")]
        public IActionResult AddEmployee()
        {
            Employee model = new Employee();
            model.Countries = new SelectList(GetCountries(),"Name","Name");
           
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "EmployeeAdd")]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index", "Employees");
            }
            else
            {
                employee.Countries = new SelectList(GetCountries(), "Name", "Name");
                return View(employee);
            }
            
           
        }
        
        [HttpGet]
        [Authorize(Policy = "EmployeeEdit")]
        public IActionResult EditEmployee(string ssn)
        {
            var employee = context.Employees.FirstOrDefault(x => x.SSN == ssn);
            if(employee == null)
            {
                return View("NotFound");
            }
            employee.Countries = new SelectList(GetCountries(), "Name", "Name");
            return View(employee);
        }
       
        [HttpPost]
        [Authorize(Policy = "EmployeeEdit")]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //var EmpInDb = await context.Employees.FindAsync(employee.SSN);
                if(employee.SSN == null)
                {
                    return NotFound();
                }
                 context.Employees.Update(employee);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            employee.Countries = new SelectList(GetCountries(), "Name", "Name");
            return View(employee);
        }
        
        [HttpPost]
        [Authorize(Policy = "EmployeeDelete")]
        public async Task<IActionResult> DeleteEmpoyee(string ssn)
        {
            var employee = await context.Employees.FindAsync(ssn);
            if(employee == null)
            {
                return NotFound();
            }
             context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IEnumerable<Countries> GetCountries()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                 .Select(x => new Countries
                 {
                     Id = new RegionInfo(x.LCID).Name,
                     Name = new RegionInfo(x.LCID).EnglishName
                 }).GroupBy(c => c.Id)
                   .Select(c => c.First())
                   .OrderBy(x => x.Name);
        }

    }
}
