using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public class QuotationGeneratorRepo : Repository<Billing.Data.Entities.QuotationGenerator>, IQuotationGeneratorRepo
    {
        private readonly IConfiguration _configuration;
        private readonly long QuotationId = 0001;
        public QuotationGeneratorRepo(BillingDbContext dbContext,
            IConfiguration configuration) : base(dbContext)
        {
            _configuration = configuration;
        }
        public async Task<long> AddNewQuotaionNumber(long LastQuotationNumber)
        {
            if (!await GetAll().AnyAsync())
            {
                var QuotationGeneratorDbModel = new QuotationGenerator();
                QuotationGeneratorDbModel.IncrQuotationId = QuotationId;
                await Add(QuotationGeneratorDbModel);
                return QuotationGeneratorDbModel.IncrQuotationId;
            }
            var DbModel = await GetAll().Where(x => x.IncrQuotationId == LastQuotationNumber).FirstOrDefaultAsync();
            if(DbModel != null)
            {
                var QuotationGeneratorDbModel = new QuotationGenerator();
                QuotationGeneratorDbModel.IncrQuotationId = DbModel.IncrQuotationId ++;
                await Add(QuotationGeneratorDbModel);
                return QuotationGeneratorDbModel.IncrQuotationId;
            }
            return QuotationId;
        }

        public async Task<long> GetLastQuotationNumber()
        {
            if (! await GetAll().AnyAsync())
            {
                return QuotationId;
            }
            return await GetAll().OrderByDescending(x => x.Id).Select(x => x.IncrQuotationId).FirstOrDefaultAsync();
        }
    }
}
