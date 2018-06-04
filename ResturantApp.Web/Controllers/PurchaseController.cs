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
    public class PurchaseController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            TempData["msg"] = string.Empty;
            var purchases = await UoW.Purchases.GetAllAsync();
            if (purchases != null)
            {
                return View(purchases);
            }

            else
            {
                TempData["msg"] = "";
                return View();
            }
        }

        public async Task<List<PurchaseItem>> Items(int id)
        {
            var items = await UoW.PurchaseItems.GetItems(id);
            return items.ToList();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PurchaseModel purchase)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Purchases.Add(purchase.Purchase);
                UoW.PurchaseItems.AddRange(purchase.Items);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<Purchase> purchases)
        {
            if (purchases != null)
            {
                UoW.Purchases.AddRange(purchases);
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
            var purchase = await UoW.Purchases.GetAsync(id);
            if (purchase != null)
            {
                return View(purchase);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var purchase = await UoW.Purchases.GetAsync(id);
            if (purchase != null)
            {
                return View(purchase);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Purchase purchase)
        {
            UoW.Purchases.Update(purchase);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var purchase = await UoW.Purchases.GetAsync(id);
            if (purchase != null)
            {
                var items = await UoW.Ingredients.GetItems(id);
                UoW.Purchases.Remove(purchase);
                UoW.Ingredients.RemoveRange(items);
                await UoW.Complete();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<Purchase> purchases)
        {
            if (purchases != null)
            {
                UoW.Purchases.RemoveRange(purchases);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}