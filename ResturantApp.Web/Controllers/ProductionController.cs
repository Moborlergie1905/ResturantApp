using ResturantApp.BOL;
using ResturantApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class ProductionController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            TempData["msg"] = string.Empty;
            var productions = await UoW.Productions.GetAllAsync();
            if (productions != null)
            {
                return View(productions);
            }

            else
            {
                TempData["msg"] = "";
                return View();
            }
        }

        public async Task<List<ProductionIngredient>> Items(int id)
        {
            var items = await UoW.Ingredients.GetItems(id);
            return items.ToList();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductionModel production)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Productions.Add(production.Production);
                UoW.Ingredients.AddRange(production.Items);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<Production> productions)
        {
            if (productions != null)
            {
                UoW.Productions.AddRange(productions);
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
            var production = await UoW.Productions.GetAsync(id);
            if (production != null)
            {
                return View(production);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var production = await UoW.Productions.GetAsync(id);
            if (production != null)
            {
                return View(production);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Production production)
        {
            UoW.Productions.Update(production);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var production = await UoW.Productions.GetAsync(id);
            if (production != null)
            {
                var items = await UoW.Ingredients.GetItems(id);
                UoW.Productions.Remove(production);
                UoW.Ingredients.RemoveRange(items);
                await UoW.Complete();                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<Production> productions)
        {
            if (productions != null)
            {
                UoW.Productions.RemoveRange(productions);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}