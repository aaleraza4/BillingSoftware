using Billing.Business.DbInitializer;
using Billing.Data.DbContexts;
using Billing.Data.EFRepository;
using Billing.Data.Repos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


      
            // configure DI for application services
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            services.AddHttpContextAccessor();

            #region @@@[------Services]
            #endregion

            #region @@@[------Repository]
            services.AddScoped<ISuperadminRepo, SuperadminRepo>();
            #endregion

        }
    }
}
