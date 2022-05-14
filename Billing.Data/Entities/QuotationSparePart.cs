using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Entities
{
    [Table("billing_quotation_sparepart")]
    public class QuotationSparePart
    {
        public long Id { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public long SparePartId { get; set; }
        [ForeignKey("SparePartId")]
        public virtual SpareParts SparePart { get; set; }
        public long QuotationId { get; set; }

        [ForeignKey("QuotationId")]
        public virtual Quotation Quotation { get; set; }
    }
}
