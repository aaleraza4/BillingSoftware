using Billing.Data.DbContexts;
using Billing.Data.Repository;
using Billing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public class SuperadminRepo : Repository<Users>, ISuperadminRepo
    {
        public SuperadminRepo(BillingDbContext billingDbContext) : base(billingDbContext)
        {

        }
        public async Task<Users> CheckSuperadminEmailExist(string Email)
        {
            return await GetAll().Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefaultAsync();
        }
    }
}
