using HumanResource.Data;
using HumanResource.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class Attendance
    {
        public int? Id { get; set; }

        [ForeignKey("EmployeeSSN")]
        public string EmployeeSSN { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Date :")]
        [DataType(DataType.Date)]
        [Required]
        [CheckDateAttendance]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [StartTimeAttendance]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [EndTimeAttendance]
        public TimeSpan EndTime { get; set; }

    }
}
