using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class TaxDTO : BaseDTO
    {
        [Required(ErrorMessage = "This field is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Percent { get; set; }
}
}
