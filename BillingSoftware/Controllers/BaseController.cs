using Billing.Business.Services.UserSessionProfile;
using Billing.Common.Utils;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSoftware.Controllers
{
    public class BaseController : Controller
    {
        public UserSessionProfileDTO SessionUser
        {
            get
            {
                using var serviceScope = ServiceActivator.GetScope();
                return serviceScope.ServiceProvider.GetRequiredService<UserSessionProfileService>().GetUserModel();
            }

        }
    }
}
