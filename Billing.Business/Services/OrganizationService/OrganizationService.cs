using AutoMapper;
using Billing.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class OrganizationService :IOrganizationService
    {
        private readonly IOrganizationRepo _organizationRepo;
        private readonly IMapper _mapper;

        public OrganizationService(IOrganizationRepo organizationRepo,IMapper mapper)
        {
            _organizationRepo = organizationRepo;
            _mapper = mapper;
        }

    }
}
