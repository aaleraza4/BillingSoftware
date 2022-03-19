using Billing.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BillingSoftware.Middlewares
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Users, Roles>

    {
        public MyUserClaimsPrincipalFactory(
        UserManager<Users> userManager,
        RoleManager<Roles> roleManager,
        IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor) { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Users user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var _roles = await UserManager.GetRolesAsync(user);
            var userRole = _roles != null && _roles.Count > 0 ? _roles.FirstOrDefault() : string.Empty;

            var trackerNo = Guid.NewGuid().ToString();

            //if (ApplicationExtensions.IsStudent(userRole))
            //{
            //    var student = await students.GetAll().FirstOrDefaultAsync(x => x.UserId == user.Id);
            //    studentid = (student?.Id) ?? 0;
            //}
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? string.Empty));
            identity.AddClaim(new Claim("LastName", user.LastName ?? string.Empty));
            identity.AddClaim(new Claim("UserID", user.Id ?? string.Empty));
            identity.AddClaim(new Claim("Email", user.Email ?? string.Empty));
            identity.AddClaim(new Claim("UserRole", userRole));
            identity.AddClaim(new Claim("TrackerNo", trackerNo));

            return identity;
        }
    }
}
