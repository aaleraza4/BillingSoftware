using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Data.Repository;

namespace Billing.Data.Repos
{
    public class QuotationRepairingRepo : Repository<Billing.Data.Entities.QuotationRepairing>, IQuotationRepairingRepo
    {
        public QuotationRepairingRepo(BillingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
