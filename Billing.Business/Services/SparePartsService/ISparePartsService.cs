﻿using Billing.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public interface ISparePartsService
    {
        Task<bool> AddSparePart(SparePartDTO entity);
        List<SparePartDTO> GetAllSparePart();
        Task<SparePartDTO> GetSparePartById(long id);
        Task<bool> UpdateSparePart(SparePartDTO sparePartDTO);
        Task<bool> DeleteSparePart(SparePartDTO sparePartDTOs);
    }
}
