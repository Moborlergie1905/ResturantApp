using System.Collections.Generic;
using System.Web.Mvc;
using ResturantApp.BOL;
using System.Threading.Tasks;

namespace ResturantApp.Web.Controllers
{
    public class CustomerController : BaseController
    {      
        public async Task<ActionResult> Index()
        {
            TempData["msg"] = string.Empty;
            var customers = await UoW.Customers.GetAllAsync();
            if (customers != null)
            {               
                return View(customers);
            }

            else
            {
                TempData["msg"] = "";
                return View();
            }
               
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Customers.Add(customer);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddMultiple(IEnumerable<Customer> customers)
        {
            if(customers != null)
            {
                UoW.Customers.AddRange(customers);
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
            var customer = await UoW.Customers.GetAsync(id);
            if(customer != null)
            {
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var customer = await UoW.Customers.GetAsync(id);
            if(customer != null)
            {
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Customer customer)
        {
            UoW.Customers.Update(customer);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var customer = await UoW.Customers.GetAsync(id);
            if(customer != null)
            {
                UoW.Customers.Remove(customer);
                await UoW.Complete();
               // return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMany(IEnumerable<Customer> customers)
        {
            if(customers != null)
            {
                UoW.Customers.RemoveRange(customers);
                await UoW.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}