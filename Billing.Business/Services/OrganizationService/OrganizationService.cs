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
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepo _organizationRepo;
        private readonly IMapper _mapper;

        public OrganizationService(IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _organizationRepo = organizationRepo;
            _mapper = mapper;
        }

        public async Task<bool> AddOrganization(OrganizationDTO entity)
        {
            try
            {
                var organization = await _organizationRepo.Get(entity?.Id);
                if (organization == null)
                {
                    organization = new();
                }
                organization = _mapper.Map<Organization>(entity);
                if (entity?.Id == 0)
                {
                    await _organizationRepo.Add(organization);

                }
                else
                {
                    await _organizationRepo.Change(organization);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<OrganizationDTO> GetAllOrganization()
        {
            try
            {
                var entity = _organizationRepo.GetAll().Where(x => x.IsDeleted != true)?.ToList();
                var organization = _mapper.Map<List<OrganizationDTO>>(entity);
                return organization;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<OrganizationDTO> GetOrganizationById(long id)
        {
            try
            {
                var entity = _organizationRepo.GetAll().Where(x => x.Id == id)?.FirstOrDefault();

                var organization = _mapper.Map<OrganizationDTO>(entity);
                return organization;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> DeleteOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                organizationDTO.IsDeleted = true;
                organizationDTO.DeletedDate = DateTime.Now;
                var entity = _mapper.Map<Organization>(organizationDTO);
                await _organizationRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<bool> UpdateOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                organizationDTO.UpdatedDate = DateTime.Now;
                var entity = _mapper.Map<Organization>(organizationDTO);
                await _organizationRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public IEnumerable<SelectListItem> GetAllOrganizationForDropdown()
        {
            return _organizationRepo.GetAll().Where(x => x.IsDeleted != true && x.OrganizationType == Enum.OrganizationEnum.OrganizationType.organization)
                .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).AsEnumerable();
        }
        public IEnumerable<SelectListItem> GetAllCustomerForDropdown()
        {
            return _organizationRepo.GetAll().Where(x => x.IsDeleted != true && x.OrganizationType == Enum.OrganizationEnum.OrganizationType.customer)
                .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).AsEnumerable();
        }
    }
}
