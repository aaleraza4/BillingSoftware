using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Business.Services.QuotationRepairingService
{
    public class QuotationRepairingService : IQuotationRepairingService
    {
        private readonly IQuotationRepairingRepo _quotationRepairingRepo;
        public QuotationRepairingService(IQuotationRepairingRepo quotationRepairingRepo)
        {
            _quotationRepairingRepo = quotationRepairingRepo;
        }

        public async Task<RepairingWorkForMultiSelectDTO[]> GetAllRepairingWorkAgainstQuotation(long id)
        {
            var DbModel = await _quotationRepairingRepo.GetAll().Include(x=>x.Repairing).Where(x => x.QuotationId == id).Select(x => new RepairingWorkForMultiSelectDTO
            {
                Id = x.Repairing.Id,
                Text = x.Repairing.Name
            }).ToArrayAsync();
            return DbModel;
        }
    }
}
