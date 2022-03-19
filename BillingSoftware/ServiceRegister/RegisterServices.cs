using Billing.Business.DbInitializer;
using Billing.Data.DbContexts;
using Billing.Data.Repository;
using Billing.Data.Repos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Billing.Business.Services;
using Billing.Data.Entities;
using Microsoft.AspNetCore.Identity;
using BillingSoftware.Middlewares;

namespace BillingSoftware.ServiceRegister
{
    public static class RegisterServices
    {
        /// <summary>
        /// Method to configure application level services with the di container
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment Env)
        {

            services.AddRazorPages();
            services.AddDbContext<BillingDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")
                                  ));
            services.AddIdentity<Users, Roles>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<BillingDbContext>();
            services.AddScoped<IUserClaimsPrincipalFactory<Users>, MyUserClaimsPrincipalFactory>();

            // configure DI for application services
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            services.AddHttpContextAccessor();
            #region @@@[------Services]
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<ISparePartsService, SparePartsService>();
            services.AddScoped<ITaxService, TaxService>();
            #endregion

            #region @@@[------Repository]
            services.AddScoped<ISuperadminRepo, SuperadminRepo>();
            services.AddScoped<IBillRepo, BillRepo>();
            services.AddScoped<IOrganizationRepo, OrganizationRepo>();
            services.AddScoped<IQuotationRepo, QuotationRepo>();
            services.AddScoped<ISparePartsRepo, SparePartsRepo>();
            services.AddScoped<ITaxRepo, TaxRepo>();
            #endregion
            services.AddAutoMapper(typeof(Startup));


        }
    }
}
