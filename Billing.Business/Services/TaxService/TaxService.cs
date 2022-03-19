using AutoMapper;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
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
        public async Task<bool> AddTax(TaxDTO entity)
        {
            try
            {
                var tax = await _taxRepo.Get(entity?.Id);
                if (tax == null)
                {
                    tax = new();
                }
                tax = _mapper.Map<Tax>(entity);
                if (entity?.Id == 0)
                {
                    await _taxRepo.Add(tax);

                }
                else
                {
                    await _taxRepo.Change(tax);
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
        public async Task<bool> DeleteTax(TaxDTO taxDTO)
        {
            try
            {
                taxDTO.IsDeleted = true;
                taxDTO.DeletedDate = DateTime.Now;
                var entity = _mapper.Map<Tax>(taxDTO);
                await _taxRepo.Change(entity);
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
    }
}
