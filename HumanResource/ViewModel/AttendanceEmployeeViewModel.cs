using HumanResource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.ViewModel
{
    public class AttendanceEmployeeViewModel
    {
        public Attendance Attendance { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
