using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class Holidayes
    {
        
        public int Id { get; set; }

        public string? Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
