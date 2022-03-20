using Billing.Business.Services;
using Billing.DTOs.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSoftware.Controllers
{
    public class SparePartController : Controller
    {
        private readonly ISparePartsService _sparePartsService;
        public SparePartController(ISparePartsService sparePartsService)
        {
            _sparePartsService = sparePartsService;
        }
        // GET: OrganizationController
        public IActionResult SparePart()
        {
            var model = _sparePartsService.GetAllSparePart();
            return View(model);
        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        [HttpGet]
        public IActionResult CreateSparePart()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]

        public async Task<IActionResult> CreateSparePart(SparePartDTO sparePartDTO)
        {
            try
            {
                bool result = false;
                if (sparePartDTO != null)
                {
                    result = await _sparePartsService.AddSparePart(sparePartDTO);
                }
                return RedirectToAction("SparePart", "SparePart");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> EditSparePart(long id)
        {
            var model = await _sparePartsService.GetSparePartById(id);

            return View(model);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        public async Task<IActionResult> EditSparePart(SparePartDTO sparePartDTO)
        {
            try
            {
                bool result = false;
                if (sparePartDTO != null)
                {
                    result = await _sparePartsService.UpdateSparePart(sparePartDTO);
                }
                return RedirectToAction("SparePart", "SparePart");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteSparePart(long id)
        {
            var model = await _sparePartsService.GetSparePartById(id);


            return View(model);
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteSparePart(SparePartDTO sparePArtDTO)
        {
            try
            {
                bool result = false;
                if (sparePArtDTO != null)
                {
                    result = await _sparePartsService.DeleteSparePart(sparePArtDTO);
                }
                return RedirectToAction("SparePart", "SparePart");
            }
            catch
            {
                return View();
            }
        }
    }
}
