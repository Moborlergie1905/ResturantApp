using ResturantApp.BOL;
using ResturantApp.Web.ViewModel;
//using ResturantApp.Web.ViewModel;
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewItems()
        {
            var stocks = GetItems();
            if (stocks.Count() == 0)
                return View("Empty");
            return View(stocks);
        }

        public IEnumerable<InventoryItem> GetItems()
        {
            var stocks = UoW.Stocks.GetAll();
            return stocks;
        }

        [HttpGet]
        public ActionResult AddOrEditItem(int id = 0)
        {
            ViewBag.Locations = UoW.Locations.GetAll();
            ViewBag.GroupID = new SelectList(UoW.Groups.GetAll(), "GpID", "Name");
            ViewBag.Products = UoW.Products.GetAll();
            ViewBag.Unit = new SelectList(UoW.Units.GetAll(), "Notation", "Notation");
            // InventoryItem item = new InventoryItem();
            ItemViewVM itemVM = new ItemViewVM();
           // itemVM.Locations = UoW.Locations.GetAll();
            itemVM.Item = new InventoryItem();
            itemVM.Products = UoW.Products.GetAll();
            if (itemVM.Item.ItemID != 0)
                itemVM.Item = UoW.Stocks.Get(id);
            return View(itemVM);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEditItem(InventoryItem item)
        {           
            if (item.ItemID != 0)
            {
                UoW.Stocks.Update(item);
                //UoW.Expirations.Update(item.Expiry);
            }

            else
            {               
                UoW.Stocks.Add(item);
               // item.Expiry.InvItemId = item.Item.ItemID;
               // UoW.Expirations.Add(item.Expiry);
            }
              
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