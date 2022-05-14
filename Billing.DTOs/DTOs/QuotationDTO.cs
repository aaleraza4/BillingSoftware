using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class QuotationDTO : BaseDTO
    {
        public string QuotationNo { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public string[] Taxs { get; set; }
        public double TotalAmount { get; set; }
        public int LaborAmount { get; set; }
        public int RepairAmount { get; set; }
        public bool IsAactive { get; set; }
        public string Status { get; set; }
        public string CarNo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public long WorkTypeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public long OrganizationId { get; set; }
        public IEnumerable<SelectListItem> OrganizationList { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public long SparePartId { get; set; }
        public IEnumerable<SelectListItem> SparePartList { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public long QuotationStatusId { get; set; }
        public IEnumerable<SelectListItem> QuotationStatusList { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public long TaxId { get; set; }
        public IEnumerable<SelectListItem> TaxList { get; set; }
    }
}
