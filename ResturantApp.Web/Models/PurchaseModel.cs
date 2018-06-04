using ResturantApp.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantApp.Web.Models
{
    public class PurchaseModel
    {
        public Purchase Purchase { get; set; }
        public List<PurchaseItem> Items { get; set; }
    }
}