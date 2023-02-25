using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Data.Entities
{
    [Table("billing_QuotationGenerator")]

    public class QuotationGenerator
    {
        [Key]
        public long Id { get; set; }
        public long IncrQuotationId { get; set; }
    }
}
