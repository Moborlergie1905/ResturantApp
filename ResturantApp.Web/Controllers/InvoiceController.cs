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
    public class InvoiceController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            TempData["msg"] = string.Empty;
            var invoices = await UoW.SalesInvoices.GetAllAsync();
            if (invoices != null)
            {
                return View(invoices);
            }

            else
            {
                TempData["msg"] = "";
                return View();
            }
        }

        public async Task<List<SalesInvoiceItem>> Items(int id)
        {
            var items = await UoW.SalesInvoiceItems.GetItems(id);
            return items.ToList();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(InvoiceModel invoice)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.SalesInvoices.Add(invoice.Invoice);
                UoW.SalesInvoiceItems.AddRange(invoice.Items);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<SalesInvoice> invoices)
        {
            if (invoices != null)
            {
                UoW.SalesInvoices.AddRange(invoices);
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
            var invoice = await UoW.SalesInvoices.GetAsync(id);
            if (invoice != null)
            {
                return View(invoice);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var invoice = await UoW.SalesInvoices.GetAsync(id);
            if (invoice != null)
            {
                return View(invoice);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(SalesInvoice invoice)
        {
            UoW.SalesInvoices.Update(invoice);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var invoice = await UoW.SalesInvoices.GetAsync(id);
            if (invoice != null)
            {
                var items = await UoW.Ingredients.GetItems(id);
                UoW.SalesInvoices.Remove(invoice);
                UoW.Ingredients.RemoveRange(items);
                await UoW.Complete();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<SalesInvoice> invoices)
        {
            if (invoices != null)
            {
                UoW.SalesInvoices.RemoveRange(invoices);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}