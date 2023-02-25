using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public class QuotationSparePartRepo : Repository<QuotationSparePart>, IQuotationSparePartRepo
    {
        public QuotationSparePartRepo(BillingDbContext dbContext) : base(dbContext)
        {

        }

    }
}
