using AutoMapper;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddQuotation(QuotationDTO entity)
        {
            try
            {
                var sparepart = await _quotationRepo.Get(entity?.Id);
                if (sparepart == null)
                {
                    sparepart = new();
                }
                sparepart = _mapper.Map<Quotation>(entity);
                if (entity?.Id == 0)
                {
                    await _quotationRepo.Add(sparepart);

                }
                else
                {
                    await _quotationRepo.Change(sparepart);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> DeleteQuotation(long id)
        {
            try
            {
                var model = await _quotationRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefaultAsync();
                model.IsDeleted = true;
                model.DeletedDate = DateTime.Now;
                await _quotationRepo.Change(model);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<QuotationDTO> GetAllQuotation()
        {
            try
            {
                var entity = _quotationRepo.GetAll().Where(x => x.IsDeleted != true)?.ToList();
                var sparepart = _mapper.Map<List<QuotationDTO>>(entity);
                return sparepart;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<QuotationDTO> GetQuotationById(long id)
        {
            try
            {
                var entity = _quotationRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefault();

                var sparepart = _mapper.Map<QuotationDTO>(entity);
                return sparepart;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdateQuotation(QuotationDTO QuotationDTO)
        {
            try
            {
                QuotationDTO.UpdatedDate = DateTime.Now;
                var entity = _mapper.Map<Quotation>(QuotationDTO);
                await _quotationRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
