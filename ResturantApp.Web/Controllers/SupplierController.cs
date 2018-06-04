using ResturantApp.BOL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class SupplierController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var suppliers = await UoW.Suppliers.GetAllAsync();
            return View(suppliers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Suppliers.Add(supplier);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
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

        [HttpGet]
        public async Task<ActionResult> Update(int id)
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

        [HttpPost]
        public async Task<ActionResult> Update(Supplier supplier)
        {
            UoW.Suppliers.Update(supplier);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
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