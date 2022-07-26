using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.DTOs.DTOs
{
    public class UserSessionProfileDTO
    {
        public string UserId { get; set; }
        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TrackerNo { get; set; }
        public string QuotationNo { get; set; }
    }
}
