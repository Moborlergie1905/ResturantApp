using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class CategoryController : BaseController
    {
        public async Task<IEnumerable<Category>> CategoriesAsync()
        {
            IEnumerable<Category> categories = await UoW.Categories.GetAllAsync();
            return categories.ToList();
        }
        public IEnumerable<Category> Categories()
        {
            List<Category> cats = CategoriesAsync().Result.ToList();
            return cats.ToList();
        }
        [HttpGet]
        public ActionResult ViewCategories()
        {
            var categories = UoW.Categories.GetAll();
            if (categories.Count() == 0)
                return View("Empty");
            return View(categories);
        }

        public ActionResult Create(int id = 0)
        {
            Category cat = new Category();
            if (id != 0)
            {
                cat = UoW.Categories.Get(id);
            }
            return View(cat);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Category category)
        {
            if (category.CatID == 0)
                UoW.Categories.Add(category);
            else
                UoW.Categories.Update(category);
            await UoW.Complete();
            return RedirectToAction("ViewCategories");

        }

        public ActionResult Delete(int id)
        {
            Category category = UoW.Categories.Get(id);
            UoW.Categories.Remove(category);
            UoW.Save();
            return RedirectToAction("ViewCategories");
        }
    }
}