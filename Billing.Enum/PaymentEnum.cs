﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Enum
{
    public class PaymentEnum
    {
        public enum PaymentType : int
        {
            FullyPaid= 1,
            PartialPaid,
        }
    }
}
