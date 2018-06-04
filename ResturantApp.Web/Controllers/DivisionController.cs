using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class DivisionController : BaseController
    {
        public IEnumerable<Division> GetDivisions()
        {
            var divisions = UoW.Divisions.GetAll();
            return divisions.ToList();
        }

        public ActionResult ViewDivisions()
        {
            return View(GetDivisions());
        }

        public ActionResult Create(int id = 0)
        {
            ViewBag.CategoryID = new SelectList(UoW.Categories.GetAll(), "CatID", "Name");
            Division division = new Division();
            if (id != 0)
            {
                division = UoW.Divisions.Get(id);
            }
            return View(division);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Division division)
        {
            if (division.divID == 0)
                UoW.Divisions.Add(division);
            else
                UoW.Divisions.Update(division);
            await UoW.Complete();

            return RedirectToAction("ViewDivisions");
        }

        [HttpPost]
        public async Task<ActionResult> Update(Division division)
        {
            UoW.Divisions.Update(division);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var division = await UoW.Divisions.GetAsync(id);           
            UoW.Divisions.Remove(division);
            await UoW.Complete();
            
            return RedirectToAction("ViewDivisions");
        }
    }
}