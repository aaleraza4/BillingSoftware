﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class BaseDTO
    {
        
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
