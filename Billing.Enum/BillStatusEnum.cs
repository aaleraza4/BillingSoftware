using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public enum BillStatusEnum : int
    {
        [Description("Paid")]
        Paid = 1,
        [Description("Pending")]
        Pending,
    }
}
