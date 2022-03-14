using AutoMapper;
using Billing.Data.Entities;
using Billing.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Bill, BillDTO>();
            CreateMap<Organization, OrganizationDTO>();
            CreateMap<Quotation, QuotationDTO>();
            CreateMap<SpareParts, SparePartDTO>();
            CreateMap<Tax, TaxDTO>();

        }
    }
}
