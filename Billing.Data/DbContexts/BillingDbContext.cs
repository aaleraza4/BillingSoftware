using Billing.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.DbContexts
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {

        }
        public DbSet<SuperadminAccount> superadminAccounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
