using Billing.Data.Entities;
using Billing.Data.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BillingSoftware.Middlewares
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Users, Roles>

    {
        private readonly IQuotationRepo _quotationRepo;
        public MyUserClaimsPrincipalFactory(
        UserManager<Users> userManager,
        RoleManager<Roles> roleManager,
        IOptions<IdentityOptions> optionsAccessor,
        IQuotationRepo quotationRepo) : base(userManager, roleManager, optionsAccessor) { 
        _quotationRepo = quotationRepo;
        
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Users user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var _roles = await UserManager.GetRolesAsync(user);
            var userRole = _roles != null && _roles.Count > 0 ? _roles.FirstOrDefault() : string.Empty;
            string QuotationNo = await _quotationRepo.GetAll().OrderByDescending(x => x.Id).Select(x => x.QuotationNo).FirstOrDefaultAsync();
            var trackerNo = Guid.NewGuid().ToString();
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? string.Empty));
            identity.AddClaim(new Claim("LastName", user.LastName ?? string.Empty));
            identity.AddClaim(new Claim("UserID", user.Id ?? string.Empty));
            identity.AddClaim(new Claim("Email", user.Email ?? string.Empty));
            identity.AddClaim(new Claim("UserRole", userRole));
            identity.AddClaim(new Claim("TrackerNo", trackerNo));
            identity.AddClaim(new Claim("QuotationNo", QuotationNo?.ToString() ?? "0"));
            return identity;
        }
    }
}
