using Billing.Data.Repository;
using System.Threading.Tasks;

namespace Billing.Data.Repos
{
    public interface IQuotationGeneratorRepo : IRepository<Billing.Data.Entities.QuotationGenerator>
    {
        Task<long> GetLastQuotationNumber();
        Task<long> AddNewQuotaionNumber(long LastQuotationNumber);
    }
}
