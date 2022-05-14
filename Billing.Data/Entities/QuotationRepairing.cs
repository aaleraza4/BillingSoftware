using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_bill_QuotationRepairing")]
    public class QuotationRepairing
    {
        public long Id { get; set; }
        public long RepairingId { get; set; }
        public long Rate { get; set; }
        [ForeignKey("RepairingId")]
        public virtual Repairing Repairing { get; set; }
        public long QuotationId { get; set; }

        [ForeignKey("QuotationId")]
        public virtual Quotation Quotation { get; set; }
    }
}
