using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class ExtraAndDiscount
    {
        public int? Id { get; set; }

        [Required]
        public int Extra { get; set; }
        [Required]
        public int Discount { get; set; }
    }
}
