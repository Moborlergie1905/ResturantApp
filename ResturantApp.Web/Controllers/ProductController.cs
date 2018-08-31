using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ResturantApp.BOL;

namespace ResturantApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //Method that fetches all registered Products
        public IEnumerable<Product> GetProducts()
        {
            var products = UoW.Products.GetAll();
            return products;
        }

        //List registered products Action Method
        public ActionResult ViewProducts()
        {
            var products = GetProducts();
            if (products.Count() == 0)
                return View("Empty");
            return View(products);
        }

        [HttpGet]
        public ActionResult AddOrEditProduct(int id = 0)
        {
            Product product = new Product();
            if (id != 0)
                product = UoW.Products.Get(id);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEditProduct(Product product)
        {
            if(product.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImageUpload.FileName);
                string ext = Path.GetExtension(product.ImageUpload.FileName);
                string swap_fileName = fileName;
                fileName = product.Name.Trim();                
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + ext;
                product.ImagePath = "~/AppFiles/ProductImages/" + fileName;
                product.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/ProductImages/"), fileName));
            }

            if (product.ProdID != 0)
                UoW.Products.Update(product);
            else
                UoW.Products.Add(product);
            await UoW.Complete();
            return RedirectToAction("ViewProducts");
        }

        public async Task<ActionResult> ProductDetail(int id)
        {
            Product product = await UoW.Products.GetAsync(id);
            return View(product);
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await UoW.Products.GetAsync(id);
            UoW.Products.Remove(product);
            await UoW.Complete();
            return RedirectToAction("ViewProducts");
        }
    }
}