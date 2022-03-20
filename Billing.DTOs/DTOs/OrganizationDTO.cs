using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
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
