using System;
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

    public class RepairingWorkFieldDTO
    {
        public long RepairingWorkId { get; set; }
        public string RepairingWorkName { get; set; }
        public decimal RepairingWorkPrice { get; set; }
        public bool TaxApply { get; set; }
    }
    public class RepairingWorkForMultiSelectDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
    }
}
