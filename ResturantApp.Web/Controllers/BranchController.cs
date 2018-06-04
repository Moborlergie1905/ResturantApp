using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class BranchController : BaseController
    {        
        public async Task<ActionResult> Index()
        {
            TempData["msg"] = string.Empty;
            var branches = await UoW.Branches.GetAllAsync();
            if(branches != null)
            {
                return View(branches);
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
        public async Task<ActionResult> Create(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                UoW.Branches.Add(branch);
                await UoW.Complete();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var branch = await UoW.Branches.GetAsync(id);
            if (branch != null)
            {
                return View(branch);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(Branch branch)
        {
            UoW.Branches.Update(branch);
            await UoW.Complete();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var branch = await UoW.Branches.GetAsync(id);
            if (branch != null)
            {
                UoW.Branches.Remove(branch);
                await UoW.Complete();
                // return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}