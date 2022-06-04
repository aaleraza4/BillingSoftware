using Billing.Business.Services;
using Billing.Common.Helper;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Billing.Enum.OrganizationEnum;

namespace BillingSoftware.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        // GET: OrganizationController
        public IActionResult Organization()
        {
            var model =  _organizationService.GetAllOrganization();
            return View(model);
        }
        public async Task<IActionResult> EditOrganization(long Id)
        {
            var model = await _organizationService.GetOrganizationById(Id);
            return PartialView("AddUpdateOrganizationForm", model);
        }
        [HttpGet]
        public IActionResult AddUpdateOrganizationForm()
        {
            return PartialView(new OrganizationDTO());
        }
        [HttpPost]

        public async Task<IActionResult> AddUpdateOrganizationForm(OrganizationDTO organizationDTO)
        {
            try
            {
                bool result = false;
                if (organizationDTO != null)
                {
                    result = await _organizationService.AddOrganization(organizationDTO); ;
                }
                var organization = GetAllOrganization();
                return PartialView("_OrganizationGrid", organization);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IEnumerable<OrganizationDTO> GetAllOrganization()
        {
            var organization = _organizationService.GetAllOrganization().ToList();
            return organization;

        }
       
        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteOrganization(long id)
        {
            var model = await _organizationService.DeleteOrganization(id);
            var organization = GetAllOrganization();
            return PartialView("_OrganizationGrid", organization); 
        }

        
    }
}
