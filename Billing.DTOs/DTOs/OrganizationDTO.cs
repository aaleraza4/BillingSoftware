using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Billing.Enum.OrganizationEnum;

namespace Billing.DTOs.DTOs
{
    public class OrganizationDTO:BaseDTO
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public OrganizationType? OrganizationType { get; set; }
        public IEnumerable<SelectListItem> OrganizationTypeList { get; set; }
    }
}
