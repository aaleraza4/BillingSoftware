using Billing.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_bill")]
    public class Bill : BaseEntity
    {
        public string BillNo { get; set; }
        public decimal? GSTTaxAmount { get; set; }
        public decimal? FederalServiceTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int? LaborAmount { get; set; }
        public int? RepairAmount { get; set; }
        public bool IsActive { get; set; }
        public BillStatusEnum Status { get; set; }
        public string CarNo { get; set; }
        public long OrganizationId { get; set; }
        public long QuotationId { get; set; }
        public ICollection<BillSparePart> BillSpareParts { get; set; }
        public ICollection<Payment> Payments { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

    }
}
