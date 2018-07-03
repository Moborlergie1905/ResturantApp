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
        public IEnumerable<MeasurementUnit> GetUnits()
        {
            var units =  UoW.Units.GetAll();
            return units;  
        }

        public ActionResult ViewUnits()
        {
            var units = GetUnits();
            if (units.Count() == 0)
                return View("Empty");
            return View(units);
        }

        public ActionResult Create(int id = 0)
        {
            MeasurementUnit unit = new MeasurementUnit();
            if(id != 0)
            {
                unit = UoW.Units.Get(id);
            }
            return View(unit);
        }
        [HttpPost]
        public async Task<ActionResult> Create(MeasurementUnit unit)
        {
            if (unit.UnitID != 0)
                UoW.Units.Update(unit);
            else
                UoW.Units.Add(unit);
            await UoW.Complete();
            return RedirectToAction("ViewUnits");
        }
    }
}