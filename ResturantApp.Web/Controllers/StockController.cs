using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class StockController : BaseController
    {      
        public async Task<ActionResult> Index()
        {
            var stock = await UoW.Stocks.GetAllAsync();
            return View(stock);
        }

        [HttpGet]
        public ActionResult Create(int id = 0)
        {
            ViewBag.GroupID = new SelectList(UoW.Groups.GetAll(), "GpID", "Name");
            ViewBag.ProductID = new SelectList(UoW.Products.GetAll(), "ProdID", "Name");
            InventoryItem item = new InventoryItem();
            if (item.ItemID != 0)
                item = UoW.Stocks.Get(id);
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventoryItem stock)
        {           
            if (stock.ItemID != 0)
                UoW.Stocks.Update(stock);
            else
                UoW.Stocks.Add(stock);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<InventoryItem> stocks)
        {
            if (stocks != null)
            {
                UoW.Stocks.AddRange(stocks);
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
            var stock = await UoW.Stocks.GetAsync(id);
            if (stock != null)
            {
                return View(stock);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var stock = await UoW.Stocks.GetAsync(id);
            if (stock != null)
            {
                UoW.Stocks.Remove(stock);
                await UoW.Complete();
                // return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<InventoryItem> stocks)
        {
            if (stocks != null)
            {
                UoW.Stocks.RemoveRange(stocks);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}