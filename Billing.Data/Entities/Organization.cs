using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Billing.Enum.OrganizationEnum;

namespace Billing.Data.Entities
{
    [Table("billing_organization")]
    public class Organization:BaseEntity
    {
        public string Name { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public List<Quotation> Quotations{ get; set; }
        public List<Bill> Bills{ get; set; }

    }
}
