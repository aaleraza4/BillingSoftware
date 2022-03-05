using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_bill")]
    public class Bill:BaseEntity
    {
        public string BillNo { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public double ApplicableTax { get; set; }
        public string Organization { get; set; }
        public double TotalAmount { get; set; }
        public int LaborAmount { get; set; }
        public int RepairAmount { get; set; }
        public bool IsAactive { get; set; }
        public string Status { get; set; }
    }
}
