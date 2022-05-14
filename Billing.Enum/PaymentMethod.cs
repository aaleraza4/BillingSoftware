using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public enum PaymentMethod : int
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Cheque")]
        Cheque,
    }
}
