using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Billing.Business.DbInitializer
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly IConfiguration configuration;
        private readonly BillingDbContext glmsPortalDbContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _environment;

        public DatabaseInitializer(IConfiguration config,
                    BillingDbContext glmsPortalDbContext,
                    IServiceProvider serviceProvider,
                    IHostingEnvironment environment
                    )
        {

            this.configuration = config;
            this.glmsPortalDbContext = glmsPortalDbContext;
            this._serviceProvider = serviceProvider;
            _environment = environment;
        }



        public async Task MigrateDbsAsync()
        {
            #region [Update the license db schema]
            await glmsPortalDbContext.Database.MigrateAsync();
            #endregion
        }


        public async Task SeedDataAsync()
        {
            await AddSuperadminAsync();
        }

        public async Task<long?> AddSuperadminAsync()
        {
            var _superadminManager = _serviceProvider.GetRequiredService<ISuperadminRepo>();
            var superAdminEmail = configuration["SuperadminUser:Email"];
            var superAdminPassword = configuration["SuperadminUser:Password"];
            var superAdminFirstName = configuration["SuperadminUser:FirstName"];
            var superAdminLastName = configuration["SuperadminUser:LastName"];
            var SuperadminModel = await _superadminManager.CheckSuperadminEmailExist(superAdminEmail);
            if (SuperadminModel == null)
            {
                return await _superadminManager.CreateSuperadminAccount(new SuperadminAccount()
                {
                    Email = superAdminEmail,
                    Username = superAdminEmail,
                    FirstName = superAdminFirstName,
                    LastName = superAdminLastName,
                    Password = superAdminPassword,
                });
            }
            return null;
        }
    }
}
