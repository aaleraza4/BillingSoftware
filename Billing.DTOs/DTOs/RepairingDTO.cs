﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class RepairingDTO:BaseDTO
    {
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
    }
}
