using Billing.Business.Services.RepairingService;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoftware.Controllers
{
    public class RepairingController : Controller
    {
        private readonly IRepairingService _repairingService;
        public RepairingController(IRepairingService repairingService)
        {
            _repairingService = repairingService;
        }
        public IActionResult Index()
        {
            var AllRepariWork = GetAllRepairWork();
            return View(AllRepariWork);
        }
        public async Task<IActionResult> EditRepairWork(long Id)
        {
            var model = await _repairingService.GetRepairingWorkById(Id);
            return PartialView("AddUpdateRepairingForm", model);
        }
        [HttpGet]
        public IActionResult AddUpdateRepairingForm()
        {
            return PartialView(new RepairingDTO());
        }
        [HttpPost]

        public async Task<IActionResult> AddUpdateRepairingForm(RepairingDTO repairingDTO)
        {
            try
            {
                bool result = false;
                if (repairingDTO != null)
                {
                    result = await _repairingService.AddRepairigWork(repairingDTO);
                }
                var AllRepariWork = GetAllRepairWork();
                return PartialView("_RepairingGrid", AllRepariWork);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IEnumerable<RepairingDTO> GetAllRepairWork()
        {
            var RepairWork =  _repairingService.GetAllRepairingwWork().ToList();
            return RepairWork;

        }
    }
}
