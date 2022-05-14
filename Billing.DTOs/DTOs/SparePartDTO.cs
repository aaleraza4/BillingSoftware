using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class SparePartDTO : BaseDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class SparePartFieldDTO
    {
        public string SparePartId  { get; set; }
        public string SparePartName { get; set; }
        public string SparePartQuantity { get; set; }
    }
}
