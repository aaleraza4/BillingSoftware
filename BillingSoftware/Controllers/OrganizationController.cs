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

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        [HttpGet]
        public IActionResult CreateOrganization()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
       
        public async Task<IActionResult> CreateOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                bool result = false;
                if (organizationDTO!=null)
                {
                    result = await _organizationService.AddOrganization(organizationDTO);
                }
                return RedirectToAction("Organization","Organization");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> EditOrganization(int id)
        {
            var model =await  _organizationService.GetOrganizationById(id);
           
            return View(model);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        public async Task<IActionResult> EditOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                bool result = false;
                if (organizationDTO != null)
                {
                    result = await _organizationService.UpdateOrganization(organizationDTO);
                }
                return RedirectToAction("Organization", "Organization");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteOrganization(long id)
        {
            var model = await _organizationService.GetOrganizationById(id);


            return View( model);
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteOrganization(OrganizationDTO organizationDTO)
        {
            try
            {
                bool result = false;
                if (organizationDTO != null)
                {
                    result = await _organizationService.DeleteOrganization(organizationDTO);
                }
                return RedirectToAction("Organization", "Organization");
            }
            catch
            {
                return View();
            }
        }
    }
}
