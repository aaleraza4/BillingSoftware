using Billing.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Billing.Enum.OrganizationEnum;

namespace Billing.Data.Entities
{
    [Table("billing_quotation")]
    public class Quotation : BaseEntity
    {
        public Quotation()
        {
            QuotationSpareParts = new List<QuotationSparePart>();
            QuotationRepairings = new List<QuotationRepairing>();
        }
        public string QuotationNo { get; set; }
        public long OrganizationId { get; set; }
        public OrganizationType OrganizationTypeId { get; set; }
        public decimal? GSTTaxAmount { get; set; }
        public decimal? FederalServiceTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public QuotationStatusEnum Status { get; set; }
        public WorkTypeEnum WorkTypeId { get; set; }
        public string CarNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<QuotationSparePart> QuotationSpareParts { get; set; }
        public ICollection<QuotationRepairing> QuotationRepairings { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
    }
}
