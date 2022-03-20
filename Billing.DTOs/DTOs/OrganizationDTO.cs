using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Billing.Enum.OrganizationEnum;

namespace Billing.DTOs.DTOs
{
    public class OrganizationDTO:BaseDTO
    {
        public string Name { get; set; }
        public OrganizationType? OrganizationType { get; set; }
        public IEnumerable<SelectListItem> OrganizationTypeList { get; set; }
    }
}
