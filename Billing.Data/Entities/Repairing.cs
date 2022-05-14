using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Entities
{
    [Table("billing_Repairing")]
    public class Repairing:BaseEntity
    {
        public string Name { get; set; }
    }
}
