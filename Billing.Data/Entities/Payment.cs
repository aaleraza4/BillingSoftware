using Billing.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Billing.Enum.PaymentEnum;

namespace Billing.Data.Entities
{
    [Table("billing_payment")]
    public class Payment : BaseEntity
    {
        public string ReferenceNo { get; set; }
        public PaymentType PaymentTypeId { get; set; }
        public PaymentMethod PaymentMethodId { get; set; }
        public double TotalAmount { get; set; }
        public long BillId { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }
    }
}
