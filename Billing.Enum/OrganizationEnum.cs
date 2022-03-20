using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public class OrganizationEnum
    {
        public enum OrganizationType
        {
            [Description("Organization")]
            organization = 1,
            [Description("Customer")]
            customer = 2,
        }
    }
}
