using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class OfficialVacations
    {
        public int? Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage ="Min Length is 4 charachter")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
