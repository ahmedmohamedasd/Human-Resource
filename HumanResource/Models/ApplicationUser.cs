﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
