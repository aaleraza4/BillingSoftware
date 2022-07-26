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
        public decimal Price { get; set; }
    }

    public class SparePartFieldDTO
    {
        public long SparePartId  { get; set; }
        public string SparePartName { get; set; }
        public int SparePartQuantity { get; set; }
        public decimal Price { get; set; }
        public bool TaxApply { get; set; }
    }
}
