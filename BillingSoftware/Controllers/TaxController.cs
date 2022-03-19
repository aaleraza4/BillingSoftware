using Billing.Business.Services;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoftware.Controllers
{
    public class TaxController : Controller
    {
        private readonly ITaxService _taxService;
        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }
        // GET: OrganizationController
        public IActionResult Tax()
        {
            var model = _taxService.GetAllTax();
            return View(model);
        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        [HttpGet]
        public IActionResult CreateTax()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]

        public async Task<IActionResult> CreateTax(TaxDTO taxDTO)
        {
            try
            {
                bool result = false;
                if (taxDTO != null)
                {
                    result = await _taxService.AddTax(taxDTO);
                }
                return RedirectToAction("Tax", "Tax");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> EditTax(long id)
        {
            var model = await _taxService.GetTaxById(id);

            return View(model);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        public async Task<IActionResult> EditTax(TaxDTO taxDTO)
        {
            try
            {
                bool result = false;
                if (taxDTO != null)
                {
                    result = await _taxService.UpdateTax(taxDTO);
                }
                return RedirectToAction("Tax", "Tax");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteTax(long id)
        {
            var model = await _taxService.GetTaxById(id);


            return View(model);
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteTax(TaxDTO taxDTO)
        {
            try
            {
                bool result = false;
                if (taxDTO != null)
                {
                    result = await _taxService.DeleteTax(taxDTO);
                }
                return RedirectToAction("Tax", "Tax");
            }
            catch
            {
                return View();
            }
        }
    }
}
