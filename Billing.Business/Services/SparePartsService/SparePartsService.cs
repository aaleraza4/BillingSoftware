using AutoMapper;
using Billing.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class SparePartsService : ISparePartsService
    {
        private readonly ISparePartsRepo _sparePartsRepo;
        private readonly IMapper _mapper;

        public SparePartsService(ISparePartsRepo sparePartsRepo, IMapper mapper)
        {
            _sparePartsRepo = sparePartsRepo;
            _mapper = mapper;

        }
    }
}
