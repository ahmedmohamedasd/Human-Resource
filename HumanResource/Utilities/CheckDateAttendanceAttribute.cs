using HumanResource.Data;
using HumanResource.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Utilities
{
    public class CheckDateAttendanceAttribute :ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext
                         .GetService(typeof(ApplicationDbContext));
            var attendance = (Attendance)validationContext.ObjectInstance;
            var employee = context.Employees.Where(x => x.SSN == attendance.EmployeeSSN).FirstOrDefault().DateOfContract;
            var holidayes = context.Holidayes.ToList();
            var vacations = context.OfficialVacations.ToList();
            for(int i = 0;i<holidayes.Count; i++)
            {
                if(attendance.Date.ToString("dddd") == holidayes[i].Name  && holidayes[i].IsSelected == true)
                {
                    return new ValidationResult("this Day is a Holiday You Cannot Add Employee for Today");
                }
            }
            for(int i = 0; i < vacations.Count; i++)
            {
                if(attendance.Date == vacations[i].Date)
                {
                    return new ValidationResult("This day is Official Vacation You Can not Add Employee For Today");
                }
            }
            
            if(employee > attendance.Date)
            {
                return new ValidationResult("Attendance Date Canot be Before Date of Contract");
            }

            return ValidationResult.Success;
        }
    }
}
