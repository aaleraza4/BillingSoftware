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
        public async Task<IActionResult> EditTax(long Id)
        {
            var model = await _taxService.GetTaxById(Id);
            return PartialView("AddUpdateTaxForm", model);
        }
        [HttpGet]
        public IActionResult AddUpdateTaxForm()
        {
            return PartialView(new TaxDTO());
        }
        [HttpPost]

        public async Task<IActionResult> AddUpdateTaxForm(TaxDTO taxDTO)
        {
            try
            {
                bool result = false;
                if (taxDTO != null)
                {
                    result = await  _taxService.AddTax(taxDTO); ;
                }
                var tax = GetAllTax();
                return PartialView("_TaxGrid", tax);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IEnumerable<TaxDTO> GetAllTax()
        {
            var tax = _taxService.GetAllTax().ToList();
            return tax;

        }

        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteTax(long id)
        {
            var model = await _taxService.DeleteTax(id);
            var tax = GetAllTax();
            return PartialView("_TaxGrid", tax);
        }

    }
}
