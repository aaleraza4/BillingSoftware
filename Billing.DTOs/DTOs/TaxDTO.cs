using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class TaxDTO:BaseDTO
    {
        public string Type { get; set; }
        public double Percent { get; set; }
    }
}
