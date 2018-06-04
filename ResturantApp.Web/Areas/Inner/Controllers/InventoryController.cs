using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Areas.Inner.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inner/Inventory
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AddStock()
        {
            return View();
        }

        public ActionResult UpdateStock()
        {
            return View();
        }

        public ActionResult PrintStock()
        {
            return View();
        }
    }
}