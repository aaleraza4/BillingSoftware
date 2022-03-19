using Microsoft.AspNetCore.Identity;

namespace Billing.Data.Entities
{
    public class Roles : IdentityRole
    {
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
