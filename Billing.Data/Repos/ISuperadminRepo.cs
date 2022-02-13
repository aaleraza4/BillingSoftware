using Billing.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public interface ISuperadminRepo
    {
        Task<long> CreateSuperadminAccount(SuperadminAccount FrontEndmodel);
        Task<SuperadminAccount> CheckSuperadminEmailExist(string Email);
    }
}
