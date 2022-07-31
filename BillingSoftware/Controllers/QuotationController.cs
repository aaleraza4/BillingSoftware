using Billing.Business.Services;
using Billing.Business.Services.RepairingService;
using Billing.Business.Services.ViewRenderService;
using Billing.Common.Helper;
using Billing.Data.Entities;
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

        public QuotationController(IQuotationService quotationSerivce,
            IOrganizationService organizationService,
            ISparePartsService sparePartsService,
            IRepairingService repairingService,
            UserManager<Users> userManager,
            SignInManager<Users> signInManager)
        {
            _quotationService = quotationSerivce;
            _organizationService = organizationService;
            _sparePartsService = sparePartsService;
            _repairingService = repairingService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _quotationService.GetAllQuotation();
            return View(model);
        }
        public IActionResult AddUpdateQuotationForm()
        {
            var model = new QuotationDTO();
            model.OrganizationList = _organizationService.GetAllOrganizationForDropdown();
            model.CustomerList = _organizationService.GetAllCustomerForDropdown();
            //model.QuotationNo = $"#{(Convert.ToInt64(SessionUser.QuotationNo.Split('#')?[1]) + 1)}";
            model.QuotationStatusList = Helper.GetEnumList<QuotationStatusEnum>();
            model.OrganizationTypeList = Helper.GetEnumList<OrganizationType>();
            model.SparePartList = _sparePartsService.GetAllSpareSpartForDropdown();
            model.RepairingWorkList = _repairingService.GetAllRepairingWorkForDropdown();
            return PartialView(model);
        }
        public async Task<IActionResult> GetSparePartFieldUI(string model)
        {
            var SparePartList = JsonConvert.DeserializeObject<List<SparePartFieldDTO>>(model);
            foreach (var item in SparePartList)
            {
                var price = await _sparePartsService.GetSparePartById(item.SparePartId);
                if(item.SparePartId == price.Id)
                    item.Price = price.Price;
            }
            return PartialView("_SparePartFieldPartialView",SparePartList);
        }
        public async Task<IActionResult> GetReparingWorkFieldsUI(string model)
        {
            var RepairWorkList = JsonConvert.DeserializeObject<IEnumerable<RepairingWorkFieldDTO>>(model);
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
                        if (User.Identity.IsAuthenticated)
                        {
                            ClaimsPrincipal cp = this.User;
                            var data = cp.Identities.ToList();
                            var QuotationId = data[0].FindFirst(c => c.Type == "QuotationNo").Value;

                        }
                        //var UserData = await _userManager.FindByIdAsync(SessionUser.UserId);
                        //var MyClaims = await _userManager.GetClaimsAsync(UserData);
                        //var OldQuotationNumber = MyClaims.Where(o => o.Type.Equals("QuotationNo")).FirstOrDefault();
                        //await _userManager.RemoveClaimAsync(UserData, OldQuotationNumber);
                        //var FirstNameClaim = new Claim("QuotationNo", OldQuotationNumber.Value+1);
                        //await _userManager.AddClaimAsync(UserData, FirstNameClaim);
                        //await _signInManager.RefreshSignInAsync(UserData);
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
            ViewBag.SparePartArray = model.SparePartArray;
            ViewBag.RepairingWorkArray = model.RepairingWorkArray;
            model.OrganizationList = _organizationService.GetAllOrganizationForDropdown();
            model.OrganizationTypeList = Helper.GetEnumList<OrganizationType>();
            model.CustomerList = _organizationService.GetAllCustomerForDropdown();
            model.RepairingWorkList = _repairingService.GetAllRepairingWorkForDropdown();
            return PartialView("AddUpdateQuotationForm",model);
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
        public async Task<List<QuotationListDTO>> GetAllQuotation()
        {
            var quotation = await _quotationService.GetAllQuotation();
            return quotation;
        }
        
    }
}
