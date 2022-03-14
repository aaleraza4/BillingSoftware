using AutoMapper;
using Billing.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepo _taxRepo;
        private readonly IMapper _mapper;
        public TaxService(ITaxRepo taxRepo,IMapper mapper)
        {
            _taxRepo = taxRepo;
            _mapper = mapper;
        }
    }
}
