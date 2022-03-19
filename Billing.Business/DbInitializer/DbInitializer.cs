using Billing.Common.ExtensionMethods;
using Billing.Data.DbContexts;
using Billing.Data.Entities;
using Billing.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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
            bool res = await AddRolesMeta();
            await AddSuperadminAsync();
        }
        public async Task<bool> AddRolesMeta()
        {
            var isSuccessfull = true;
            var _roleManager = _serviceProvider.GetRequiredService<RoleManager<Roles>>();
            var rolesList = System.Enum.GetValues(typeof(RoleEnum.Role)).Cast<RoleEnum.Role>().ToList();

            //EnumDescriptionExtention.GetEnumList<Roles>().ToList();
            foreach (var role in rolesList)
            {
                var roleExist = await RoleNameExists(role.GetEnumDescription(), _roleManager);
                if (!roleExist)
                {
                    var result = await _roleManager.CreateAsync(new Roles()
                    {
                        Name = role.GetEnumDescription(),
                        Description = role.GetEnumDescription()
                    });
                    if (!result.Succeeded)
                    {
                        isSuccessfull = false;
                        break;
                    }
                }
            }
            return isSuccessfull;
        }
        private async Task<bool> RoleNameExists(string Name, RoleManager<Roles> RoleService)
        {
            var role_obj = await RoleService.FindByNameAsync(Name);
            if (role_obj != null)
                return true;
            else
                return false;
        }

        public async Task AddSuperadminAsync()
        {
            var _userManager = _serviceProvider.GetRequiredService<UserManager<Users>>();
            var uniqueGuid = Guid.NewGuid();

            var superAdminEmail = configuration["SuperadminUser:Email"];
            var superAdminPassword = configuration["SuperadminUser:Password"];
            var superAdminFirstName = configuration["SuperadminUser:FirstName"];
            var superAdminLastName = configuration["SuperadminUser:LastName"];

            var user = await _userManager.FindByEmailAsync(superAdminEmail);
            if (user == null)
            {
                var userResult = await _userManager.CreateAsync(new Users()
                {
                    Id = uniqueGuid.ToString(),
                    Email = superAdminEmail,
                    UserName = superAdminEmail,
                    EmailConfirmed = true,
                    FirstName = superAdminFirstName,
                    LastName = superAdminLastName,
                }, superAdminPassword);
                if (userResult.Succeeded)
                {
                    user = await _userManager.FindByEmailAsync(superAdminEmail);
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }
    }
}
