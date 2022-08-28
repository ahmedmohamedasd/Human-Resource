using HumanResource.Data;
using HumanResource.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext context;
        public SalaryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Policy = "SalaryShow")]
        public IActionResult Index(int? mm , int? yy )
        {
            var month =DateTime.Now.Month;
            var year = DateTime.Now.Year;
            
            var cyear = yy;
            var cmonth = mm;
            if(mm == null && yy == null)
            {
                cmonth = month;
                cyear = year;
            }
            else
            {
                cyear = yy;
                cmonth = mm;
            }
            IEnumerable<SalaryReport> salaryReport = context.HourWorks
                                                     .Where(x=> x.Date.Month == cmonth && x.Date.Year == cyear)
                                                     .GroupBy(p => new { p.EmployeeSSN })
                                                     .Select(c => new SalaryReport
                                                     {
                                                         EmployeeSSn = c.Key.EmployeeSSN,
                                                         TotalExtra = c.Sum(p => p.Extra),
                                                         TotalDiscount = c.Sum(p => p.Discount),
                                                         Attendance= c.Count(),
                                                         EmployeeName = context.Employees.Where(x=>x.SSN ==c.Key.EmployeeSSN).First().Name,
                                                         Salary = context.Employees.Where(x => x.SSN == c.Key.EmployeeSSN).First().Salary

                                                     });
            if(!salaryReport.Any())
            {
                ViewBag.Year = cyear;
                ViewBag.Month = cmonth;
                Console.WriteLine("hello");
                return View(salaryReport);
            }
            decimal totalextra = context.ExtraAndDiscounts.FirstOrDefault().Extra;
            decimal totalDiscount = context.ExtraAndDiscounts.FirstOrDefault().Discount;
            int dayes = 0;
            if(cmonth == DateTime.Now.Month && cyear == DateTime.Now.Year)
            {
                dayes = DateTime.Now.Day;
            }
            else
            {
                dayes = DateTime.DaysInMonth((int)cyear, (int)cmonth);
            }
            //Check Date
             
            DateTime StartDate = new DateTime((int)cyear, (int)cmonth, 1);
            DateTime EndDate = new DateTime((int)cyear, (int)cmonth, dayes);
            List<DateTime> dateList = new List<DateTime>();
            int interval = 1;
            dateList.Add(StartDate);
            //create List of Dates 
            while(StartDate.AddDays(interval) <= EndDate)
            {
                StartDate = StartDate.AddDays(interval);
                dateList.Add(StartDate);
                
            }

            //Get List of Holidayes
            var holidayes = context.Holidayes.ToList();
            var vacations = context.OfficialVacations.ToList();
            int counter = 0;
            for(int i = 0; i < dateList.Count; i++)
            {
                for(int k = 0; k < holidayes.Count; k++)
                {
                    if (dateList[i].ToString("dddd") == holidayes[k].Name && holidayes[k].IsSelected == true)
                    {
                        counter++;
                    }
                }
                for(int j = 0; j < vacations.Count; j++)
                {
                    if(dateList[i] == vacations[j].Date)
                    {
                        counter++;
                    }
                }
                
            }
            
            List<SalaryReport> model = new List<SalaryReport>();
            
            foreach(var item in salaryReport)
            {
                model.Add(item);
            }
            for(int i = 0; i < model.Count; i++)
            {
                var hourstart = context.Employees.Where(x => x.SSN == model[i].EmployeeSSn).FirstOrDefault().StartTime;
                var hourEnd = context.Employees.Where(x => x.SSN == model[i].EmployeeSSn).FirstOrDefault().EndTime;
                var hourWorks = (int)( hourEnd.TotalHours - hourstart.TotalHours);
                decimal hour = calculateHourSalary(model[i].Salary , hourWorks);
                model[i].TotalSalary = (int)(((model[i].Attendance + counter) * (model[i].Salary / 30)) +
                                                 (hour * (model[i].TotalExtra * totalextra)) -
                                                 (hour * (model[i].TotalDiscount * totalDiscount)));
                model[i].Absence = dayes -  (model[i].Attendance + counter);
                model[i].Holidayes = counter;
                                                 
            }

           

            //var totalExtra = context.HourWorks
            //                 .GroupBy(x => x.EmployeeSSN)
            //                 .Select(;
            ViewBag.Year = cyear;
            ViewBag.Month = cmonth;
            return View(model);
        }
        static decimal calculateHourSalary(decimal salary , int hourWorks)
        {
            decimal day = salary / 30;
            decimal hour = day / hourWorks;
            return hour;
        }
        //var salary = from p in context.HourWorks
                      //join s in context.Attendances on p.Id equals s.Id
            //             where (p.Id == 1010)
            //             let tottalprice = (p.Extra * s.Id)
            //             //group p by p.EmployeeSSN into Group
            //             select new { name = p.EmployeeSSN, Extra = tottalprice };


                      //var extra = context.HourWorks.Join(context.Attendances, x => x.Id, p => p.Id,
                      //                   (xx, pp) => new { x = xx, p = pp })
                      //                   .Where(x=>x.x.EmployeeSSN == "15454")
                      //                   .Sum(z => z.x.Extra);
    }
}
