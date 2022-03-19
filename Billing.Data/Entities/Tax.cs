using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_tax")]
    public class Tax:BaseEntity
    {
        public string Type { get; set; }
        public double Percent { get; set; }
        public ICollection<Quotation> Quotations { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
