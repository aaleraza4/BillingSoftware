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

namespace Billing.Business.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepo _taxRepo;
        private readonly IMapper _mapper;
        public TaxService(ITaxRepo taxRepo, IMapper mapper)
        {
            _taxRepo = taxRepo;
            _mapper = mapper;
        }
        public async Task<bool> AddTax(TaxDTO entity)
        {
            try
            {
                var DBresult = await _taxRepo.GetAll().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                DBresult = DBresult == null ? new Tax() : DBresult;
                DBresult.Type = entity.Type;
                DBresult.Percent = entity.Percent;
                if (entity.Id == 0)
                {
                    await _taxRepo.Add(DBresult);
                }
                else
                {
                    await _taxRepo.Change(DBresult);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<TaxDTO> GetAllTax()
        {
            try
            {
                var entity = _taxRepo.GetAll().Where(x => x.IsDeleted != true)?.ToList();
                var tax = _mapper.Map<List<TaxDTO>>(entity);
                return tax;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<TaxDTO> GetTaxById(long id)
        {
            try
            {
                var entity = _taxRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefault();

                var tax = _mapper.Map<TaxDTO>(entity);
                return tax;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> DeleteTax(long id)
        {
            try
            {
                var model = await _taxRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefaultAsync();
                model.IsDeleted = true;
                model.DeletedDate = DateTime.Now;
                await _taxRepo.Change(model);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        public async Task<bool> UpdateTax(TaxDTO taxDTO)
        {
            try
            {
                taxDTO.UpdatedDate = DateTime.Now;
                var entity = _mapper.Map<Tax>(taxDTO);
                await _taxRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<SelectListItem> GetAllTaxsForDropdown()
        {
            return _taxRepo.GetAll().Where(x => x.IsDeleted != true).Select(x => new SelectListItem
            {
                Text = x.Type,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}
