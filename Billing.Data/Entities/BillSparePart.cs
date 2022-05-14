using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Entities
{
    [Table("billing_bill_sparepart")]
    public class BillSparePart
    {
        public long Id { get; set; }
        public long Rate { get; set; }
        public int Quantity { get; set; }
        public long SparePartId { get; set; }
        [ForeignKey("SparePartId")]
        public virtual SpareParts SparePart { get; set; }
        public long BillId { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }
    }
}
