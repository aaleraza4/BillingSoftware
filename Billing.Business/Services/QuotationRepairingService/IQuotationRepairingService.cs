using Billing.DTOs.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Business.Services.QuotationRepairingService
{
    public interface IQuotationRepairingService
    {
        Task<RepairingWorkForMultiSelectDTO[]> GetAllRepairingWorkAgainstQuotation(long id);
    }
}
