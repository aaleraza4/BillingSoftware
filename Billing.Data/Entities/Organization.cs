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
        public ICollection<Quotation> Quotations{ get; set; }
        public ICollection<Bill> Bills{ get; set; }
    }
}
