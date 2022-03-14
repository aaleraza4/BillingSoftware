using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public class SparePartsRepo : Repository<SpareParts>, ISparePartsRepo
    {
        public SparePartsRepo(BillingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
