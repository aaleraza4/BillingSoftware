using AutoMapper;
using Billing.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepo _quotationRepo;
        private readonly IMapper _mapper;

        public QuotationService(IQuotationRepo quotationRepo, IMapper mapper)
        {
            _quotationRepo= quotationRepo;
            _mapper = mapper;

        }
    }
}
