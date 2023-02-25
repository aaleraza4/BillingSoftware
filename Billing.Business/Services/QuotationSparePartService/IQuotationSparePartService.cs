using Billing.DTOs.DTOs;
using System.Threading.Tasks;

namespace Billing.Business.Services.QuotationSparePartService
{
    public interface IQuotationSparePartService
    {
        Task<SparePartForMultiSelectDTO[]> GetAllSparePartsAgainstQuotation(long id);
        Task<string> GetAllSparePartsByQuotationId(long id);
        Task<(bool TaxApplied, decimal Price,int Quantity, long Primarykey)> GetSparePartAndQuotationInfo(long QuotationId, long SparePartId);
    }
}
