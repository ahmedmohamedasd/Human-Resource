using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class SalaryReport
    {
        
        public string EmployeeSSn { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public int Absence { get; set; }
        public decimal TotalExtra { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalSalary { get; set; }
        public int Attendance { get; set; }
        public int Holidayes { get; set; }
    }
}
