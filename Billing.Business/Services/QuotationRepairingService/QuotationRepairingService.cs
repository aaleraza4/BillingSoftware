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
        private readonly IRepairingRepo _repairingRepo;
        public QuotationRepairingService(IQuotationRepairingRepo quotationRepairingRepo,
            IRepairingRepo repairingRepo)
        {
            _quotationRepairingRepo = quotationRepairingRepo;
            _repairingRepo = repairingRepo;
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

        public async Task<string> GetAllRepairingWorkByQuotationId(long id)
        {
            var DbModel = await _quotationRepairingRepo
                .GetAll()
                .Include(x => x.Repairing)
                .Include(x => x.Quotation)
                .Where(x => x.QuotationId == id && x.Quotation.IsDeleted != true)
                .Select(x => x.RepairingId.ToString())
                .ToArrayAsync();
            return string.Join(",",DbModel);
        }

        public async Task<(bool TaxApplied, decimal Price, long PrimaryKey)> GetRepairingWorkAndQuotationInfo(long QuotationId, long RepairingWorkId)
        {
            var DbModel = await _quotationRepairingRepo
              .GetAll()
              .Include(x => x.Quotation)
              .Where(x => x.QuotationId == QuotationId && x.RepairingId == RepairingWorkId).FirstOrDefaultAsync();
            if (DbModel == null)
            {
                var repairingWorkModel = await _repairingRepo.GetAll().Where(x => x.IsDeleted != true && x.Id == RepairingWorkId).FirstOrDefaultAsync();
                return (false, 0, 0);
            }
            return (DbModel?.TaxApplied ?? false, DbModel?.Rate ?? 0,DbModel?.Id??0);
        }
    }
}
