using ResturantApp.BOL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace ResturantApp.Web.Controllers
{
    public class SupplierController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            var suppliers = UoW.Suppliers.GetAll();
            return suppliers;
        }

        public ActionResult ViewSuppliers()
        {
            var suppliers = GetSuppliers();
            if (suppliers.Count() == 0)
                return View("Empty");
            return View(suppliers);
        }

        [HttpGet]
        public ActionResult AddOrEditSupplier(int id = 0)
        {
            ViewBag.CurrencyID = new SelectList(UoW.Currencies.GetAll(), "ID", "CurrencyType");
            Supplier supplier = new Supplier();
            if (id != 0)
                supplier = UoW.Suppliers.Get(id);
            return View(supplier);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEditSupplier(Supplier supplier)
        {
            if (supplier.SupID != 0)
                UoW.Suppliers.Update(supplier);
            else
                UoW.Suppliers.Add(supplier);
            await UoW.Complete();
            return RedirectToAction("ViewSuppliers");
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<Supplier> suppliers)
        {
            if (suppliers != null)
            {
                UoW.Suppliers.AddRange(suppliers);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Find(int id)
        {
            var supplier = await UoW.Suppliers.GetAsync(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
       

        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var supplier = await UoW.Suppliers.GetAsync(id);
            if (supplier != null)
            {
                UoW.Suppliers.Remove(supplier);
                await UoW.Complete();
                // return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<Supplier> suppliers)
        {
            if (suppliers != null)
            {
                UoW.Suppliers.RemoveRange(suppliers);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}