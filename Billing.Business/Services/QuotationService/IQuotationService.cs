using Billing.DTOs.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public interface IQuotationService
    {
        Task<ResponseDTO> AddUpdateQuotation(RequestQuotationDTO entity);
        Task<List<QuotationListDTO>> GetAllQuotation();
        Task<QuotationDTO> GetQuotationById(long id);
        Task<bool> UpdateQuotation(QuotationDTO QuotationDTO);
        Task<bool> DeleteQuotation(long id);
    }
}
