using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public enum WorkTypeEnum : int
    {
        [Description("Spare Part")]
        SparePart = 1,
        [Description("Repair")]
        Repair,
        [Description("All")]
        All
    }
}
