using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class SparePartDTO : BaseDTO
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Price { get; set; }
    }

    public class SparePartFieldDTO
    {
        public long SparePartId  { get; set; }
        public string SparePartName { get; set; }
        public int SparePartQuantity { get; set; }
        public decimal Price { get; set; }
        public bool TaxApply { get; set; }
    }

    public class SparePartForMultiSelectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
