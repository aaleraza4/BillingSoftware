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
        public async Task<IActionResult> EditSparePart(long Id)
        {
            var model = await _sparePartsService.GetSparePartById(Id);
            return PartialView("AddUpdateSparePartForm", model);
        }
        [HttpGet]
        public IActionResult AddUpdateSparePartForm()
        {
            return PartialView(new SparePartDTO());
        }
        [HttpPost]

        public async Task<IActionResult> AddUpdateSparePartForm(SparePartDTO sparePartDTO)
        {
            try
            {
                bool result = false;
                if (sparePartDTO != null)
                {
                    result = await _sparePartsService.AddSparePart(sparePartDTO); ;
                }
                var sparePart = GetAllSparePart();
                return PartialView("_SparePartGrid", sparePart);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IEnumerable<SparePartDTO> GetAllSparePart()
        {
            var sparePart = _sparePartsService.GetAllSparePart().ToList();
            return sparePart;

        }
       
        //// GET: OrganizationController/Delete/5
        [HttpGet]
        public async Task<IActionResult> DeleteSparePart(long id)
        {
            var result = await _sparePartsService.DeleteSparePart(id);
            var sparePart = GetAllSparePart();
            return PartialView("_SparePartGrid", sparePart);
        }

        //// POST: OrganizationController/Delete/5
        //[HttpPost]
        //public async Task<IActionResult> DeleteSparePart(SparePartDTO sparePArtDTO)
        //{
        //    try
        //    {
        //        bool result = false;
        //        if (sparePArtDTO != null)
        //        {
        //            result = await _sparePartsService.DeleteSparePart(sparePArtDTO);
        //        }
        //        return RedirectToAction("SparePart", "SparePart");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
