using Billing.Business.Services;
using Billing.Business.Services.ViewRenderService;
using Billing.Common.Helper;
using Billing.DTOs.DTOs;
using Billing.Enum;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoftware.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly IOrganizationService _organizationService;
        private readonly ISparePartsService _sparePartsService;
        private readonly ITaxService _taxService;
        private readonly IViewRenderService _viewRenderService;
        public QuotationController(IQuotationService quotationSerivce,
            IOrganizationService organizationService,
            ISparePartsService sparePartsService,
            ITaxService taxService,
            IViewRenderService viewRenderService)
        {
            _quotationService = quotationSerivce;
            _organizationService = organizationService;
            _sparePartsService = sparePartsService;
            _taxService = taxService;
            _viewRenderService = viewRenderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUpdateQuotationForm()
        {
            var model = new QuotationDTO();
            model.OrganizationList = _organizationService.GetAllOrganizationForDropdown();
            model.QuotationNo = "0000";
            model.QuotationStatusList = Helper.GetEnumList<QuotationStatusEnum>();
            model.SparePartList = _sparePartsService.GetAllSpareSpartForDropdown();
            model.TaxList = _taxService.GetAllTaxsForDropdown();
            return PartialView(model);
        }
        public async Task<IActionResult> GetSparePartFieldUI(string model)
        {
            var SparePartList = JsonConvert.DeserializeObject<IEnumerable<SparePartFieldDTO>>(model);
            return PartialView("_SparePartFieldPartialView",SparePartList);
        }
        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        [HttpGet]
        public IActionResult CreateQuotation()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]

        public async Task<IActionResult> CreateQuotation(QuotationDTO QuotationDTO)
        {
            try
            {
                bool result = false;
                if (QuotationDTO != null)
                {
                    result = await _quotationService.AddQuotation(QuotationDTO);
                }
                return RedirectToAction("Quotation", "Quotation");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> EditQuotation(long id)
        {
            var model = await _quotationService.GetQuotationById(id);

            return View(model);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        public async Task<IActionResult> EditQuotation(QuotationDTO QuotationDTO)
        {
            try
            {
                bool result = false;
                if (QuotationDTO != null)
                {
                    result = await _quotationService.UpdateQuotation(QuotationDTO);
                }
                return RedirectToAction("Quotation", "Quotation");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteQuotation(long id)
        {
            var model = await _quotationService.DeleteQuotation(id);
            var quotation = GetAllQuotation();
            return PartialView("_QuotationGrid", quotation);
        }
        public IEnumerable<QuotationDTO> GetAllQuotation()
        {
            var quotation = _quotationService.GetAllQuotation().ToList();
            return quotation;

        }
        
    }
}
