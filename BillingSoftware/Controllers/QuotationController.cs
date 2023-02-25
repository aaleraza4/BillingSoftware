using Billing.Business.Services;
using Billing.Business.Services.QuotationRepairingService;
using Billing.Business.Services.QuotationSparePartService;
using Billing.Business.Services.RepairingService;
using Billing.Business.Services.ViewRenderService;
using Billing.Common.Helper;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Billing.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Billing.Enum.OrganizationEnum;

namespace BillingSoftware.Controllers
{
    public class QuotationController : BaseController
    {
        private readonly IQuotationService _quotationService;
        private readonly IOrganizationService _organizationService;
        private readonly ISparePartsService _sparePartsService;
        private readonly IRepairingService _repairingService;
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IQuotationRepairingService _quotationRepairingService;
        private readonly IQuotationSparePartService _quotationSparePartService;
        private readonly IQuotationGeneratorRepo _quotationGeneratorRepo;

        public QuotationController(IQuotationService quotationSerivce,
            IOrganizationService organizationService,
            ISparePartsService sparePartsService,
            IRepairingService repairingService,
            UserManager<Users> userManager,
            SignInManager<Users> signInManager,
            IQuotationRepairingService quotationRepairingService,
            IQuotationSparePartService quotationSparePartService,
            IQuotationGeneratorRepo quotationGeneratorRepo)
        {
            _quotationService = quotationSerivce;
            _organizationService = organizationService;
            _sparePartsService = sparePartsService;
            _repairingService = repairingService;
            _userManager = userManager;
            _signInManager = signInManager;
            _quotationRepairingService = quotationRepairingService;
            _quotationSparePartService = quotationSparePartService;
            _quotationGeneratorRepo = quotationGeneratorRepo;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _quotationService.GetAllQuotation();
            return View(model);
        }
        public async Task<IActionResult> AddUpdateQuotationForm()
        {
            var model = new QuotationDTO();
            model.OrganizationList = _organizationService.GetAllOrganizationForDropdown();
            model.CustomerList = _organizationService.GetAllCustomerForDropdown();
            //model.QuotationNo = $"#{(Convert.ToInt64(SessionUser.QuotationNo.Split('#')?[1]) + 1)}";
            model.QuotationStatusList = Helper.GetEnumList<QuotationStatusEnum>();
            model.OrganizationTypeList = Helper.GetEnumList<OrganizationType>();
            model.SparePartList = _sparePartsService.GetAllSpareSpartForDropdown();
            model.RepairingWorkList = _repairingService.GetAllRepairingWorkForDropdown();
            var id = await _quotationGeneratorRepo.GetLastQuotationNumber();
            model.QuotationNo = string.Format("{0:D4}",id++);
            return PartialView(model);
        }
        public async Task<IActionResult> GetSparePartFieldUI(string model, long QuotationId = 0)
        {
            var SparePartList = JsonConvert.DeserializeObject<List<SparePartFieldDTO>>(model);
            foreach (var item in SparePartList)
            {
                var QuotationWithFinancialInfo = await _quotationSparePartService.GetSparePartAndQuotationInfo(QuotationId, item.SparePartId);
                item.Price = QuotationWithFinancialInfo.Price;
                item.TaxApply = QuotationWithFinancialInfo.TaxApplied;
                item.SparePartQuantity = QuotationWithFinancialInfo.Quantity;
                item.QuotationSparePartId = QuotationWithFinancialInfo.Primarykey;
            }
            return PartialView("_SparePartFieldPartialView", SparePartList);
        }
        public async Task<IActionResult> GetReparingWorkFieldsUI(string model, long QuotationId = 0)
        {
            var RepairWorkList = JsonConvert.DeserializeObject<IEnumerable<RepairingWorkFieldDTO>>(model);
            foreach (var item in RepairWorkList)
            {
                var QuotationWithFinancialInfo = await _quotationRepairingService.GetRepairingWorkAndQuotationInfo(QuotationId, item.RepairingWorkId);
                item.RepairingWorkPrice = QuotationWithFinancialInfo.Price;
                item.TaxApply = QuotationWithFinancialInfo.TaxApplied;
                item.QuotationRepairingWorkId = QuotationWithFinancialInfo.PrimaryKey;
            }
            return PartialView("_ReparingFieldsPartialView", RepairWorkList);
        }

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
        public async Task<IActionResult> AddUpdateQuotationForm(string QuotationDTO)
        {
            var model = JsonConvert.DeserializeObject<RequestQuotationDTO>(QuotationDTO);
            model.SparePartList = JsonConvert.DeserializeObject<List<SparePartFieldDTO>>(model.SparePartSerializeString);
            model.RepairWorkList = JsonConvert.DeserializeObject<List<RepairingWorkFieldDTO>>(model.RepairingSerializeString);
            if (QuotationDTO != null)
            {
                var Response = await _quotationService.AddUpdateQuotation(model);
                if (Response.IsSuccessful)
                {
                    await _quotationGeneratorRepo.AddNewQuotaionNumber(Convert.ToInt64(model.QuotationNo));
                    return Json(Response);
                }
                return Json(Response);
            }
            return RedirectToAction("Quotation", "Quotation");
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> EditQuotation(long id)
        {
            var model = await _quotationService.GetQuotationById(id);
            model.OrganizationList = _organizationService.GetAllOrganizationForDropdown();
            model.OrganizationTypeList = Helper.GetEnumList<OrganizationType>();
            model.CustomerList = _organizationService.GetAllCustomerForDropdown();
            model.RepairingWorkList = _repairingService.GetAllRepairingWorkForDropdown();
            model.SparePartList = _sparePartsService.GetAllSpareSpartForDropdown();
            model.ReparingIds = model.WorkTypeId == WorkTypeEnum.All.GetHashCode() || model.WorkTypeId == WorkTypeEnum.Repair.GetHashCode() ?
                await _quotationRepairingService.GetAllRepairingWorkByQuotationId(id) : string.Empty;
            model.SparepartIds = model.WorkTypeId == WorkTypeEnum.All.GetHashCode() || model.WorkTypeId == WorkTypeEnum.SparePart.GetHashCode() ?
                await _quotationSparePartService.GetAllSparePartsByQuotationId(id) : string.Empty;
            return PartialView("AddUpdateQuotationForm", model);
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
            return await GetAllQuotation();
        }
        public async Task<IActionResult> GetAllQuotation()
        {
            var quotation = await _quotationService.GetAllQuotation();
            return PartialView("_QuotationGrid", quotation);
        }

        public async Task<IActionResult> GetAllReparingAgainstQuotation(long QuotationId)
        {
            var Response = await _quotationRepairingService.GetAllRepairingWorkAgainstQuotation(QuotationId);
            return Json(Response);
        }
        public async Task<IActionResult> GetAllSparePartAgainstQuotation(long QuotationId)
        {
            var Response = await _quotationRepairingService.GetAllRepairingWorkAgainstQuotation(QuotationId);
            return Json(Response);
        }

    }
}
