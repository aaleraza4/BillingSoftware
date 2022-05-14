using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public interface ITaxService
    {
        Task<bool> AddTax(TaxDTO entity);
        List<TaxDTO> GetAllTax();
        Task<TaxDTO> GetTaxById(long id);
        Task<bool> UpdateTax(TaxDTO taxDTO);
        Task<bool> DeleteTax(TaxDTO taxDTO);
        IEnumerable<SelectListItem> GetAllTaxsForDropdown();
    }
}
