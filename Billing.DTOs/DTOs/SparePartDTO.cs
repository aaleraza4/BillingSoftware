using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class SparePartDTO:BaseDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
