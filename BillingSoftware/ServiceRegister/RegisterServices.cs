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
using Billing.Business.AutoMapper;
using Billing.Business.Services.ViewRenderService;
using Billing.Business.Services.RepairingService;
using Billing.Business.Services.UserSessionProfile;
using Billing.Business.Services.QuotationRepairingService;
using Billing.Business.Services.QuotationSparePartService;

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
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IRepairingService, RepairingService>();
            services.AddScoped<IQuotationRepairingService, QuotationRepairingService> ();
            services.AddScoped<UserSessionProfileService>();
            services.AddScoped<IQuotationSparePartService, QuotationSparePartService>();
            #endregion

            #region @@@[------Repository]
            services.AddScoped<ISuperadminRepo, SuperadminRepo>();
            services.AddScoped<IBillRepo, BillRepo>();
            services.AddScoped<IOrganizationRepo, OrganizationRepo>();
            services.AddScoped<IQuotationRepo, QuotationRepo>();
            services.AddScoped<ISparePartsRepo, SparePartsRepo>();
            services.AddScoped<ITaxRepo, TaxRepo>();
            services.AddScoped<IRepairingRepo, RepairingRepo>();
            services.AddScoped<IQuotationRepairingRepo, QuotationRepairingRepo>();
            services.AddScoped<IQuotationSparePartRepo, QuotationSparePartRepo>();
            services.AddScoped<IQuotationGeneratorRepo,QuotationGeneratorRepo>();
            #endregion
            services.AddAutoMapper(typeof(AutoMapperProfiles));


        }
    }
}
