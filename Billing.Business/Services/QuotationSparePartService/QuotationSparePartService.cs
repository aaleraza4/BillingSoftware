using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Business.Services.QuotationSparePartService
{
    public class QuotationSparePartService : IQuotationSparePartService
    {
        private readonly IQuotationSparePartRepo _quotationSparePartRepo;
        private readonly ISparePartsRepo _sparePartsRepo;
        public QuotationSparePartService(IQuotationSparePartRepo quotationSparePartRepo,
            ISparePartsRepo sparePartsRepo)
        {
            _quotationSparePartRepo = quotationSparePartRepo;
            _sparePartsRepo = sparePartsRepo;
        }

        public async Task<SparePartForMultiSelectDTO[]> GetAllSparePartsAgainstQuotation(long id)
        {
            var DbModel = await _quotationSparePartRepo.GetAll().Include(x => x.SparePart).Where(x => x.QuotationId == id).Select(x => new SparePartForMultiSelectDTO
            {
                Id = x.SparePart.Id,
                Name = x.SparePart.Name
            }).ToArrayAsync();
            return DbModel;
        }

        public async Task<string> GetAllSparePartsByQuotationId(long id)
        {
            var DbModel = await _quotationSparePartRepo
               .GetAll()
               .Include(x => x.Quotation)
               .Where(x => x.QuotationId == id && x.Quotation.IsDeleted != true)
               .Select(x => x.SparePartId.ToString())
               .ToArrayAsync();
            return string.Join(",", DbModel);
        }

        public async Task<(bool TaxApplied, decimal Price,int Quantity,long Primarykey)> GetSparePartAndQuotationInfo(long QuotationId, long SparePartId)
        {
            var DbModel = await _quotationSparePartRepo
              .GetAll()
              .Include(x => x.Quotation)
              .Where(x => x.QuotationId == QuotationId && x.SparePartId == SparePartId).FirstOrDefaultAsync();
            if(DbModel == null)
            {
                var sparePartModel = await _sparePartsRepo.GetAll().Where(x => x.IsDeleted != true && x.Id == SparePartId).FirstOrDefaultAsync();
                return (false, sparePartModel?.Price ?? 0, 0, 0);
            }
            return (DbModel?.TaxApplied??false,DbModel?.Rate??0,DbModel?.Quantity??0,DbModel?.Id??0);
        }
    }
}
