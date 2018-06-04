using Repository.UnitOfWork;
using ResturantApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UoW;
        public BaseController()
        {
            UoW = new UnitOfWork(new RestaurantContext());
        }       
    }
}