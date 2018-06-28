using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class GroupController : BaseController
    {
        public IEnumerable<Group> GetGroups()
        {
            var groups = UoW.Groups.GetAll();

            return groups.ToList();
        }

        public ActionResult ViewGroups()
        {
            var chkGroup = GetGroups();
            if (chkGroup.Count() == 0)
                return View("Empty");
            else
                return View(chkGroup);
        }

        public ActionResult Create(int id = 0)
        {
            ViewBag.DivisionID = new SelectList(UoW.Divisions.GetAll(), "DivID", "Name");
            Group group = new Group();
            if (id != 0)
            {
                group = UoW.Groups.Get(id);
            }
            return View(group);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Group group)
        {
            if (group.GpID == 0)
                UoW.Groups.Add(group);
            else
                UoW.Groups.Update(group);
            await UoW.Complete();
            return RedirectToAction("ViewGroups");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var group = await UoW.Groups.GetAsync(id);
            if (group != null)
            {
                UoW.Groups.Remove(group);
                await UoW.Complete();
            }
            return RedirectToAction("Index");
        }
    }
}