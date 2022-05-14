using AutoMapper;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<bool> AddSparePart(SparePartDTO entity)
        {
            try
            {
                var sparepart = await _sparePartsRepo.Get(entity?.Id);
                if (sparepart == null)
                {
                    sparepart = new();
                }
                sparepart = _mapper.Map<SpareParts>(entity);
                if (entity?.Id == 0)
                {
                    await _sparePartsRepo.Add(sparepart);

                }
                else
                {
                    await _sparePartsRepo.Change(sparepart);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<SparePartDTO> GetAllSparePart()
        {
            try
            {
                var entity = _sparePartsRepo.GetAll().Where(x => x.IsDeleted != true)?.ToList();
                var sparepart = _mapper.Map<List<SparePartDTO>>(entity);
                return sparepart;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<SparePartDTO> GetSparePartById(long id)
        {
            try
            {
                var entity = _sparePartsRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefault();

                var sparepart = _mapper.Map<SparePartDTO>(entity);
                return sparepart;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> DeleteSparePart(SparePartDTO sparePartDTO)
        {
            try
            {
                sparePartDTO.IsDeleted = true;
                sparePartDTO.DeletedDate = DateTime.Now;
                var entity = _mapper.Map<SpareParts>(sparePartDTO);
                await _sparePartsRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateSparePart(SparePartDTO sparePartDTO)
        {
            try
            {
                sparePartDTO.UpdatedDate = DateTime.Now;
                var entity = _mapper.Map<SpareParts>(sparePartDTO);
                await _sparePartsRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<SelectListItem> GetAllSpareSpartForDropdown()
        {
            return _sparePartsRepo.GetAll().Where(x => x.IsDeleted != true).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
        }
    }
}
