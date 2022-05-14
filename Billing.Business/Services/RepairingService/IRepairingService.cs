using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services.RepairingService
{
    public interface IRepairingService
    {
        Task<bool> AddRepairigWork(RepairingDTO entity);
        List<RepairingDTO> GetAllRepairingwWork();
        Task<RepairingDTO> GetRepairingWorkById(long id);
        Task<bool> UpdateRepairingWork(RepairingDTO repairingDTO);
        Task<bool> DeleteRepairingWork(RepairingDTO repairingDTO);
        IEnumerable<SelectListItem> GetAllRepairingWorkForDropdown();
    }
}
