using HumanResource.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Utilities
{
    public class StartTimeAttendanceAttribute :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var attendance= (Attendance)validationContext.ObjectInstance;
            var startTime = attendance.StartTime.Hours;

            return (startTime > 0) ? ValidationResult.Success : new ValidationResult("Time Can not Be Zero ");
        }
    }
}
