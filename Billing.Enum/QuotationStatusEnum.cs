using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public enum QuotationStatusEnum : int
    {
        [Description("Approved")]
        Approved = 1,
        [Description("Reject")]
        Reject
    }
}
