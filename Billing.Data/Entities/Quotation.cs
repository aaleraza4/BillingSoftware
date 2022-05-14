using Billing.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_quotation")]
    public class Quotation : BaseEntity
    {
        public string QuotationNo { get; set; }
        public long OrganizationId { get; set; }
        public decimal? GSTTaxAmount { get; set; }
        public decimal? FederalServiceTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int? LaborAmount { get; set; }
        public int? RepairAmount { get; set; }
        public bool IsActive { get; set; }
        public QuotationStatusEnum Status { get; set; }
        public string CarNo { get; set; }
        public ICollection<QuotationSparePart> QuotationSpareParts { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
    }
}
