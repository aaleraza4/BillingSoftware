﻿using Billing.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.DbContexts
{
    public class BillingDbContext : IdentityDbContext<Users, Roles, string>
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {

        }
        public DbSet<Users> superadminAccounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<SpareParts> SpareParts { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Roles> Roles  { get; set; }
        public DbSet<BillSparePart> BillSpareParts { get; set; }
        public DbSet<QuotationSparePart> QuotationSpareParts  { get; set; }
        public DbSet<Repairing> Repairings  { get; set; }
        public DbSet<QuotationRepairing> QuotationRepairings  { get; set; }
        public DbSet<QuotationGenerator> QuotationGenerators  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-01NOACQ\\MSSQLSERVER2019;Database=db_BillingCompany;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
