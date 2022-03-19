﻿using System;
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

        public List<Payment> Payments { get; set; }

        [ForeignKey("FK_billing_organization")]
        public long OrganizationId { get; set; }

        public ICollection<Tax> Taxs { get; set; }

        public ICollection<SpareParts> SpareParts{ get; set; }


    }
}
