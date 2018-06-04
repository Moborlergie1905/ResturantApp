using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Web.Models
{
    public class ProductionModel
    {
        public Production Production { get; set; }
        public List<ProductionIngredient> Items { get; set; }
    }
}