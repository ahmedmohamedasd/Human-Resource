using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HumanResource.Data;
using HumanResource.Models;
using HumanResource.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace HumanResource.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext context;

        public AttendancesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Attendances
        [Authorize(Policy ="AttendanceShow")]
        public async Task<IActionResult> Index()
        {
            return View(await context.Attendance.Include(c=>c.Employee).ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await context.Attendance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        [Authorize(Policy = "AttendanceAdd")]
        public IActionResult Create()
        {
            var employees = context.Employees.ToList();
            AttendanceEmployeeViewModel model = new AttendanceEmployeeViewModel
            {
                Employees = employees
            };
            return View(model);
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AttendanceAdd")]
        public async Task<IActionResult> Create( Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                var employee = context.Attendance.Where(x => x.EmployeeSSN == attendance.EmployeeSSN && x.Date == attendance.Date).FirstOrDefault();
                if(employee == null)
                {
                    //var times = context.Holidayes.ToList();
                    //for(int i = 0; i < times.Count; i++)
                    //{
                    //    if(attendance.Date.DayOfWeek.ToString() == times[i].Name)
                    //    {
                    //        ModelState.AddModelError("", "This Day is Holiday You cannot attendance today");
                    //    }
                    //}
                    var employeeIndb = context.Employees.Where(x => x.SSN == attendance.EmployeeSSN).FirstOrDefault();
                    
                    
                     context.Attendance.Add(attendance);
                    await context.SaveChangesAsync();
                    var diffExtra = (decimal)(attendance.EndTime.TotalMinutes - employeeIndb.EndTime.TotalMinutes) / 60;
                    var diffDiscount = (decimal)(attendance.StartTime.TotalMinutes - employeeIndb.StartTime.TotalMinutes) / 60;
                    HourWorks hourWorks = new HourWorks()
                    {
                        Id =(int)attendance.Id,
                        Date = attendance.Date,
                        EmployeeSSN = attendance.EmployeeSSN,
                        Discount = diffDiscount,
                        Extra = diffExtra
                    };

                    context.HourWorks.Add(hourWorks);
                    await context.SaveChangesAsync();
                    
                    return RedirectToAction("Index", "Attendances");
                }
                ModelState.AddModelError("", "Employee Can not Assigned to Same Day More than one!");
            }
            var employees = context.Employees.ToList();
            AttendanceEmployeeViewModel model = new AttendanceEmployeeViewModel
            {
                Employees = employees
            };
            return View(model);
        }

        // GET: Attendances/Edit/5
        [Authorize(Policy = "AttendanceEdit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            var employees = context.Employees.ToList();
            AttendanceEmployeeViewModel model = new AttendanceEmployeeViewModel
            {
                Employees = employees,
                Attendance = attendance
            };
            return View(model);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AttendanceEdit")]
        public async Task<IActionResult> Edit(int id,  Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var attend = context.Attendances.Where(x => x.Id == id).FirstOrDefault();
                    //var date = attend.Date;
                    //var empssn = attend.EmployeeSSN;
                    //var hw = context.HourWorks.Where(x => x.EmployeeSSN == empssn && x.Date == date).FirstOrDefault();


                    //HourWorks hw = context.
                    context.Update(attendance);
                    await context.SaveChangesAsync();
                    var employeeIndb = context.Employees.Where(x => x.SSN == attendance.EmployeeSSN).FirstOrDefault();
                    var diffExtra = (decimal)(attendance.EndTime.TotalMinutes - employeeIndb.EndTime.TotalMinutes) / 60;
                    var diffDiscount = (decimal)(attendance.StartTime.TotalMinutes - employeeIndb.StartTime.TotalMinutes) / 60;

                    HourWorks hourWorks = new HourWorks()
                    {
                        Id =(int)attendance.Id,
                        Date = attendance.Date,
                        Discount = diffDiscount,
                        Extra = diffExtra,
                        EmployeeSSN = attendance.EmployeeSSN
                    };
                    context.HourWorks.Update(hourWorks);
                    await context.SaveChangesAsync();
                   
                   // var hourworks = context.HourWorks.Where(x=>x.Date == att)
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists((int)attendance.Id))
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
            var employees = context.Employees.ToList();
            AttendanceEmployeeViewModel model = new AttendanceEmployeeViewModel
            {
                Employees = employees,
                Attendance = attendance
            };
            return View(attendance);
        }

        


        // POST: Attendances/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Policy = "AttendanceDelete")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var attendance = await context.Attendance.FindAsync(id);
            var hourworks = await context.HourWorks.FindAsync(id);
            context.Attendance.Remove(attendance);
            await context.SaveChangesAsync();
            if (hourworks != null)
            {
                context.HourWorks.Remove(hourworks);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return context.Attendance.Any(e => e.Id == id);
        }
    }
}
