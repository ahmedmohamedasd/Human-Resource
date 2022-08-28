using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Models
{
    public class HourWorks
    {
        public int Id { get; set; }
        
        public string EmployeeSSN { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public decimal Extra { get; set; }
        
        public decimal Discount { get; set; }
    }
}
