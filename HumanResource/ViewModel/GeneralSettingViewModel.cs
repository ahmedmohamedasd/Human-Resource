using HumanResource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.ViewModel
{
    public class GeneralSettingViewModel
    {
        public GeneralSettingViewModel()
        {
            Holidayes = new List<Holidayes>();
        }
        public List<Holidayes> Holidayes { get; set; }
       
        public ExtraAndDiscount ExtraAndDiscount { get; set; }

       
    }
}
