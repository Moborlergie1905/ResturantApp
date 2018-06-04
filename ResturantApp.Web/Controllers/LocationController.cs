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
        public async Task<ActionResult> Index()
        {
            var locations = await UoW.Locations.GetAllAsync();
            return View(locations);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Locations.Add(location);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }
               
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var location = await UoW.Locations.GetAsync(id);
            if (location != null)
            {
                return View(location);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Location location)
        {
            UoW.Locations.Update(location);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var location = await UoW.Locations.GetAsync(id);
            if (location != null)
            {
                UoW.Locations.Remove(location);
                await UoW.Complete();
                // return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        } 
        
        public async Task<ActionResult> LocationItem(int id)
        {
            var items = await UoW.Stocks.GetByLocation(id);
            if(items != null)
            {
                return View(items);
            }
            return View();
        }     
    }
}