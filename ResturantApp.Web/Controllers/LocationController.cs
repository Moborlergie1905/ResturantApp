using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class LocationController : BaseController
    {
        public ActionResult ViewLocations()
        {
            var locations = GetLocations();
            if (locations.Count() == 0)
                return View("Empty");
            else
                return View(locations);
        }

        public IEnumerable<Location> GetLocations()
        {
            var locations = UoW.Locations.GetAll();
            return locations;
        }

        public ActionResult Create(int id = 0)
        {
            var location = new Location();
            if (id != 0)
                location = UoW.Locations.Get(id);
            return View(location);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Location location)
        {
            if (location.LocID == 0)
                UoW.Locations.Add(location);
            else
                UoW.Locations.Update(location);
            await UoW.Complete();
            return RedirectToAction("ViewLocations");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var location = await UoW.Locations.GetAsync(id);

            UoW.Locations.Remove(location);
            await UoW.Complete();
            return RedirectToAction("ViewLocations");
        }

        //public async Task<ActionResult> LocationItem(int id)
        //{
        //    var items = await UoW.Stocks.GetByLocation(id);
        //    if(items != null)
        //    {
        //        return View(items);
        //    }
        //    return View();
        //}     
    }
}