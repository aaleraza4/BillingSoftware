using Billing.DTOs.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Business.Services.QuotationRepairingService
{
    public interface IQuotationRepairingService
    {
        Task<RepairingWorkForMultiSelectDTO[]> GetAllRepairingWorkAgainstQuotation(long id);
        Task<string> GetAllRepairingWorkByQuotationId(long id);
        Task<(bool TaxApplied, decimal Price,long PrimaryKey)> GetRepairingWorkAndQuotationInfo(long QuotationId, long RepairingWorkId);
    }
}
