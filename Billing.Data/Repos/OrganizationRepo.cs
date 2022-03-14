using Billing.Data.Repository;
using Billing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Data.DbContexts;

namespace Billing.Data.Repos
{
    public class OrganizationRepo : Repository<Organization>, IOrganizationRepo
    {
        public OrganizationRepo(BillingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
