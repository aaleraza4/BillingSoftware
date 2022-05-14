using AutoMapper;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services.RepairingService
{
    public class RepairingService:IRepairingService
    {
        private readonly IRepairingRepo _repairingRepo;
        private readonly IMapper _mapper;
        public RepairingService(IRepairingRepo repairingRepo, IMapper mapper)
        {
            _repairingRepo = repairingRepo;
            _mapper = mapper;
        }

        public async Task<bool> AddRepairigWork(RepairingDTO entity)
        {
            try
            {
                var DBresult = await _repairingRepo.GetAll().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                DBresult = DBresult == null ? new Repairing() : DBresult;
                DBresult.Name = entity.Name;
                if(entity.Id == 0)
                {
                    await _repairingRepo.Add(DBresult);
                }
                else
                {
                    await _repairingRepo.Change(DBresult);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<bool> DeleteRepairingWork(RepairingDTO repairingDTO)
        {
            throw new NotImplementedException();
        }

        public List<RepairingDTO> GetAllRepairingwWork()
        {
            try
            {
                var entity = _repairingRepo.GetAll().Where(x => x.IsDeleted != true)?.ToList();
                var repairWork = _mapper.Map<List<RepairingDTO>>(entity);
                return repairWork;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SelectListItem> GetAllRepairingWorkForDropdown()
        {
            return _repairingRepo.GetAll().Where(x => x.IsDeleted != true).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }

        public async Task<RepairingDTO> GetRepairingWorkById(long id)
        {
            return await _repairingRepo.GetAll().Where(x => x.Id == id).Select(x => new RepairingDTO
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public Task<bool> UpdateRepairingWork(RepairingDTO repairingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
