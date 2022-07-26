using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services.UserSessionProfile
{
    public class UserSessionProfileService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserSessionProfileService(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public UserSessionProfileDTO GetUserModel()
        {

            UserSessionProfileDTO ob = new UserSessionProfileDTO();
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Identity != null && httpContextAccessor.HttpContext.User.Claims != null)
            {
                ob.UserId = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserID")?.Value;
                ob.UserRole = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserRole")?.Value;
                ob.FirstName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "FirstName")?.Value;
                ob.LastName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "LastName")?.Value;
                ob.Email = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
                ob.TrackerNo = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "TrackerNo")?.Value;
                ob.QuotationNo = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "QuotationNo")?.Value;
                return ob;
            }
            return null;
        }

        public bool IsClaimExists(string claimName)
        {

            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.User != null && httpContextAccessor.HttpContext.User.Identity != null && httpContextAccessor.HttpContext.User.Claims != null)
            {
                return httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == claimName);
            }
            return false;
        }
    }
}
