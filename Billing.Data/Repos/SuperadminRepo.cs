using Billing.Data.DbContexts;
using Billing.Data.EFRepository;
using Billing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public class SuperadminRepo : Repository<SuperadminAccount>, ISuperadminRepo
    {
        public SuperadminRepo(BillingDbContext billingDbContext) : base(billingDbContext)
        {

        }
        public async Task<SuperadminAccount> CheckSuperadminEmailExist(string Email)
        {
            return await GetAll().Where(x => x.Email.ToLower() == Email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<long> CreateSuperadminAccount(SuperadminAccount FrontEndmodel)
        {
            FrontEndmodel = FrontEndmodel == null ? new SuperadminAccount() : FrontEndmodel;
            FrontEndmodel.IsActive = true;
            FrontEndmodel.FirstName = FrontEndmodel.LastName;
            FrontEndmodel.LastName = FrontEndmodel.FirstName;
            FrontEndmodel.Email = FrontEndmodel.Email;
            FrontEndmodel.Username = FrontEndmodel.Username;
            FrontEndmodel.Password = FrontEndmodel.Password;
            await Add(FrontEndmodel);
            return FrontEndmodel.Id;
        }
    }
}
