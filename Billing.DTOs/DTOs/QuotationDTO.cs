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
        public QuotationDTO()
        {
            SparePartDTOList = new List<SparePartFieldDTO>();
            RepairWorkDTOList = new List<RepairingWorkFieldDTO>();
        }
        public string QuotationNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public string  SparePartSerializeString { get; set; }
        public string  RepairingSerializeString { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string CarNo { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public long WorkTypeId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public long OrganizationId { get; set; }
        public IEnumerable<SelectListItem> OrganizationList { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public long CustomerId { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string SparePartId { get; set; }
        public IEnumerable<SelectListItem> SparePartList { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string ReparingWorkId { get; set; }
        public IEnumerable<SelectListItem> RepairingWorkList { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public long QuotationStatusId { get; set; }
        public IEnumerable<SelectListItem> QuotationStatusList { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public long OrganizationTypeId { get; set; }
        public string SpareParts { get; set; }
        public string RepairingWorks { get; set; }
        public IEnumerable<SelectListItem> OrganizationTypeList { get; set; }
        public List<SparePartFieldDTO> SparePartDTOList { get; set; }
        public List<RepairingWorkFieldDTO> RepairWorkDTOList { get; set; }
        public string ReparingIds { get; set; }
        public string SparepartIds { get; set; }
    }


    public class RequestQuotationDTO 
    {
        public RequestQuotationDTO()
        {
            SparePartList = new List<SparePartFieldDTO>();
            RepairWorkList = new List<RepairingWorkFieldDTO>();
        }
        public string QuotationNo { get; set; }
        public long Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string  SparePartSerializeString { get; set; }
        public string  RepairingSerializeString { get; set; }
        public string CarNo { get; set; }
        public int WorkTypeId { get; set; }
        public long OrganizationId { get; set; }
        public long CustomerId { get; set; }
        public long OrganizationTypeId { get; set; }
        public string UserId { get; set; }
        public List<SparePartFieldDTO> SparePartList { get; set; }
        public List<RepairingWorkFieldDTO> RepairWorkList { get; set; }
    }


    public class QuotationListDTO
    {
        public string OrganizationTypeName { get; set; }
        public string CarNo { get; set; }
        public string QuotationNo { get; set; }
        public double TotalAmount { get; set; }
        public string TotalRepairTax { get; set; }
        public string TotalGstTax { get; set; }
        public string StatusName { get; set; }
        public long Id { get; set; }

    }


}
