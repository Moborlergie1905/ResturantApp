using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class MeasurementController : BaseController
    {       
        public async Task<List<MeasurementUnit>> Units()
        {
            var units = await UoW.Units.GetAllAsync();
            if(units != null)
            {
                return units.ToList();
            }
            else
            {
                return ViewBag.msg = "";
            }           
        }

        [HttpPost]
        public async Task<ActionResult> Create(MeasurementUnit unit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Units.Add(unit);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }
    }
}