using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public interface IOrganizationService
    {
        Task<bool> AddOrganization(OrganizationDTO entity);
        List<OrganizationDTO> GetAllOrganization();
        Task<OrganizationDTO> GetOrganizationById(long id);
        Task<bool> UpdateOrganization(OrganizationDTO organizationDTO);
        Task<bool> DeleteOrganization(long id);
        IEnumerable<SelectListItem> GetAllOrganizationForDropdown();
    }
}
